using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Json_TestAsync.Models;
using Newtonsoft.Json;

namespace Json_TestAsync.Helpers
{
    public static class JsonPlaceholderHelper
    {
        const string BASE_URL = "https://jsonplaceholder.typicode.com/posts";


        public static async Task<List<Post>> GetPostsAsync()
        {
            using (var httpClient = new HttpClient())
            {
                var jsonString = await httpClient.GetStringAsync(BASE_URL);
                var posts = JsonConvert.DeserializeObject<List<Post>>(jsonString);
                return posts;
            }
        }
    }
}
