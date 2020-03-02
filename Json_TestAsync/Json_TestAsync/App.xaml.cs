using System;
using System.IO;
using Json_TestAsync.ViewModels;
using Json_TestAsync.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Json_TestAsync
{
    public partial class App : Application
    {
        static PostsDatabase database;

        public static PostsDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new PostsDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "posts.db3"));
                }
                return database;
            }
        }

        public App(string dbPath)
        {
            InitializeComponent();
            MainPage = new NavigationPage(new ItemListPage());

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
