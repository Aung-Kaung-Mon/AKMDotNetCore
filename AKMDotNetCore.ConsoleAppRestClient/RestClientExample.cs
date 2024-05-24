using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace AKMDotNetCore.ConsoleAppRestClient
{
    internal class RestClientExample
    {
        private readonly RestClient _client = new RestClient(new Uri("https://localhost:7184/"));
        private readonly string _baseEndPoint = "api/blog";

        public async Task Run()
        {
            //await EditAsync(25);
            //await PostAsync("hey", "how are you", "good");
            await ReadAsync();
            //await PutAsync(25, "gg", "hh", "jj");
            //await DeleteAsync(25);
        }

        private async Task ReadAsync()
        {
            RestRequest request = new RestRequest(_baseEndPoint , Method.Get);
            var response = await _client.ExecuteAsync(request);
            if (response.IsSuccessStatusCode)
            {
                string jsonStr =  response.Content!;
                List<BlogDto> list = JsonConvert.DeserializeObject<List<BlogDto>>(jsonStr)!;

                foreach (BlogDto blog in list)
                {
                    Console.WriteLine(JsonConvert.SerializeObject(blog));
                    Console.WriteLine($"BlogTitle => {blog.BlogTitle}");
                    Console.WriteLine($"BlogAuthor => {blog.BlogArthur}");
                    Console.WriteLine($"BlogContent => {blog.BlogContent}");
                }
            }

        }

        private async Task EditAsync(int id)
        {
            RestRequest request = new RestRequest($"{_baseEndPoint}/{id}", Method.Get);
            var response = await _client.ExecuteAsync(request);

            if (response.IsSuccessStatusCode)
            {
                string jsonStr = response.Content!;
                BlogDto blog = JsonConvert.DeserializeObject<BlogDto>(jsonStr)!;

                Console.WriteLine(JsonConvert.SerializeObject(blog));
                Console.WriteLine($"BlogTitle => {blog.BlogTitle}");
                Console.WriteLine($"BlogAuthor => {blog.BlogArthur}");
                Console.WriteLine($"BlogContent => {blog.BlogContent}");
            }
        }

        private async Task PostAsync(string title, string author, string content)
        {
            BlogDto blogDto = new BlogDto()
            {
                BlogTitle = title,
                BlogArthur = author,
                BlogContent = content
            };

            RestRequest request = new RestRequest(_baseEndPoint, Method.Post);
            request.AddJsonBody(blogDto);

            var response = await _client.ExecuteAsync(request);

            if (response.IsSuccessStatusCode)
            {
                string message =  response.Content!;
                Console.WriteLine(message);
            }
            else
            {
                string message = response.Content!;
                Console.WriteLine(message);
            }

        }

        private async Task PutAsync(int id, string title, string author, string content)
        {
            BlogDto blogDto = new BlogDto()
            {
                BlogTitle = title,
                BlogArthur = author,
                BlogContent = content
            };

            RestRequest request = new RestRequest($"{_baseEndPoint}/{id}", Method.Put);
            request.AddJsonBody(blogDto);

            var response = await _client.ExecuteAsync(request);

            if (response.IsSuccessStatusCode)
            {
                string message =  response.Content!;
                Console.WriteLine(message);
            }
            else
            {
                string message = response.Content!;
                Console.WriteLine(message);
            }
        }

        private async Task DeleteAsync(int id)
        {
            RestRequest request = new RestRequest($"{_baseEndPoint}/{id}", Method.Delete);

            var response = await _client.DeleteAsync(request);

            if (response.IsSuccessStatusCode)
            {
                string message =  response.Content!;
                Console.WriteLine(message);
            }
            else
            {
                string message = response.Content!;
                Console.WriteLine(message);
            }
        }

    }
}
