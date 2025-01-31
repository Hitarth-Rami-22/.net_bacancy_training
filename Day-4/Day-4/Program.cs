// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using System;
{
    Console.WriteLine("Downloading Running files......\n");

    // Start all downloads parallel
    Task file1 = DownloadFileAsync("File - 1");
    Task file2 = DownloadFileAsync("File - 2");
    Task file3 = DownloadFileAsync("File - 3");

    // Wait for all downloads file to complete
    await Task.WhenAll(file1, file2, file3);
    
    Console.WriteLine("\nAll Files downloads completed sucssesfully");
}

static async Task DownloadFileAsync(string fileName)
{
    Console.WriteLine("Starting" + fileName + ".....");

    await Task.Delay(5000); // Simulate 5 seconds download time

    Console.WriteLine($"{fileName} finished downloading!");
}