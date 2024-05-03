// See https://aka.ms/new-console-template for more information


using AKMDotNetCore.ConsoleApp.EFCoreExamples;

//AkmDotNetCore aKMDotNetCore = new AkmDotNetCore();

//aKMDotNetCore.Retrieve();
//aKMDotNetCore.Create("jj", "nn", "kk");
//aKMDotNetCore.Update(13, "title", "author name", "content");
//aKMDotNetCore.Delete(15);
//aKMDotNetCore.Edit(13);

//DapperExample dapperExample = new DapperExample();
//dapperExample.Run();

EFCoreExample eFCoreExample = new EFCoreExample();
eFCoreExample.Run();

Console.ReadKey();