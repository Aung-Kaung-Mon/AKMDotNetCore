using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace AKMDotNetCore.ConsoleAppHttpClientExample
{
    internal class HttpClientExample
    {
        private readonly HttpClient _client = new HttpClient() { BaseAddress = new Uri("https://localhost:7184/") };
        private readonly string _baseEndPoint = "api/blog";

        public async Task Run()
        {
            //await EditAsync(25);
            //await PostAsync("hey", "how are you", "good");
            //await ReadAsync();
            //await PutAsync(25, "gg", "hh", "jj");
            //await DeleteAsync(25);
        }

        private async Task ReadAsync()
        {
            HttpResponseMessage response = await _client.GetAsync(_baseEndPoint);
            if(response.IsSuccessStatusCode)
            {
                string jsonStr = await response.Content.ReadAsStringAsync();
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
            HttpResponseMessage response = await _client.GetAsync($"{_baseEndPoint}/{id}");

            if(response.IsSuccessStatusCode)
            {
                string jsonStr = await response.Content.ReadAsStringAsync();
                BlogDto blog = JsonConvert.DeserializeObject<BlogDto>(jsonStr)!;

                Console.WriteLine(JsonConvert.SerializeObject(blog));
                Console.WriteLine($"BlogTitle => {blog.BlogTitle}");
                Console.WriteLine($"BlogAuthor => {blog.BlogArthur}");
                Console.WriteLine($"BlogContent => {blog.BlogContent}");
            }
        }

        private async Task PostAsync(string title, string author, string content)
        {
            BlogDto blogDto = new BlogDto() {
                BlogTitle = title,
                BlogArthur = author,
                BlogContent = content
            };

            string blogJson = JsonConvert.SerializeObject(blogDto);
            HttpContent httpContent = new StringContent(blogJson, Encoding.UTF8, Application.Json);

            HttpResponseMessage response = await _client.PostAsync(_baseEndPoint, httpContent);

            if(response.IsSuccessStatusCode)
            {
                string message = await response.Content.ReadAsStringAsync();  
                Console.WriteLine(message);
            }
            else
            {
                string message = await response.Content.ReadAsStringAsync();
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

            string blogJson = JsonConvert.SerializeObject(blogDto);
            HttpContent httpContent = new StringContent(blogJson, Encoding.UTF8, Application.Json);

            HttpResponseMessage response = await _client.PutAsync($"{_baseEndPoint}/{id}", httpContent);

            if (response.IsSuccessStatusCode)
            {
                string message = await response.Content.ReadAsStringAsync();
                Console.WriteLine(message);
            }
            else
            {
                string message = await response.Content.ReadAsStringAsync();
                Console.WriteLine(message);
            }

        }

        private async Task DeleteAsync(int id)
        {
            HttpResponseMessage response = await _client.DeleteAsync($"{_baseEndPoint}/{id}");

            if (response.IsSuccessStatusCode)
            {
                string message = await response.Content.ReadAsStringAsync();
                Console.WriteLine(message);
            }
            else
            {
                string message = await response.Content.ReadAsStringAsync();
                Console.WriteLine(message);
            }
        }

    }
}
