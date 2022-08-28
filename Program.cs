// See https://aka.ms/new-console-template for more information
using Dapr.Client;

const string storeName = "statestore";
const string key = "counter";

var daprClinet = new DaprClientBuilder().Build();
var counter = await daprClinet.GetStateAsync<int>(storeName,key);

while(true){
    Console.WriteLine($"Counter {counter++}");
    await daprClinet.SaveStateAsync(storeName,key,counter);
    await Task.Delay(1000);
}