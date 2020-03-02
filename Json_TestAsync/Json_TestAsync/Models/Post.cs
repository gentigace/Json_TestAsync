using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using SQLite;

namespace Json_TestAsync.Models
{
    public class Post
    {
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("userId")]
        public int UserId { get; set; }
        [PrimaryKey, AutoIncrement]
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("body")]
        public string Body { get; set; }
    }
}
