using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Json_TestAsync.Helpers;
using Json_TestAsync.Models;
using Newtonsoft.Json;

namespace Json_TestAsync.ViewModels
{
    public class ItemListViewModel : BaseViewModel
    {
        public ObservableCollection<Post> Posts { get; set; }

        public ItemListViewModel()
        {
            this.Posts = new ObservableCollection<Post>();
        }

   public async Task UpdatePostsAsync()  
        {
            var newPosts = await JsonPlaceholderHelper.GetPostsAsync();
            this.Posts.Clear();
            newPosts.ForEach((post) =>
            {
                this.Posts.Add(post);
            });
        
           

        }
            
        public async Task<List<Post>> Fetchpost()
        {
            using (var httpClient = new HttpClient())
            {
                var jsonString = await httpClient.GetStringAsync("https://jsonplaceholder.typicode.com/posts");
                var posts = JsonConvert.DeserializeObject<List<Post>>(jsonString);
                return posts;
            }
        }

    }
}
