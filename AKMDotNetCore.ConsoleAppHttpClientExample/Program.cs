// See https://aka.ms/new-console-template for more information

using AKMDotNetCore.ConsoleAppHttpClientExample;

HttpClientExample httpClientExample = new HttpClientExample();
await httpClientExample.Run();

Console.ReadLine();
