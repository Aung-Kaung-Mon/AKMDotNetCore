// See https://aka.ms/new-console-template for more information


using AKMDotNetCore.ConsoleApp;

AkmDotNetCore aKMDotNetCore = new AkmDotNetCore();

//aKMDotNetCore.Retrieve();
//aKMDotNetCore.Create("jj", "nn", "kk");
//aKMDotNetCore.Update(13, "title", "author name", "content");
//aKMDotNetCore.Delete(15);
aKMDotNetCore.Edit(13);

Console.ReadKey();