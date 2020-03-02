using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Json_TestAsync.Models;
using SQLite;

namespace Json_TestAsync.ViewModels
{
    public class PostsDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public PostsDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Post>().Wait();
        }

        public Task<List<Post>> GetPostAsync()
        {
            return _database.Table<Post>().ToListAsync();
        }

        public Task<Post> GetPostAsync(int id)
        {
            return _database.Table<Post>()
                            .Where(i => i.Id == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SavePostAsync(Post post)
        {
            if (post.Id != 0)
            {
                return _database.UpdateAsync(post);
            }
            else
            {
                return _database.InsertAsync(post);
            }
        }

        public Task<int> DeletePostAsync(Post post)
        {
            return _database.DeleteAsync(post);
        }
    }
}
