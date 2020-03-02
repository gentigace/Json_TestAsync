using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Json_TestAsync.Models;
using Json_TestAsync.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Json_TestAsync.Views
{
    public partial class ItemListPage
    {
        ItemListViewModel itemListViewModel;
        async void NewToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewPostPage
            {
                BindingContext = new Post()
            });
        }
        private void PostsListView_ItemSelected(object sender, EventArgs e) { }



        public ItemListPage()
        {
            InitializeComponent();
            itemListViewModel = new ItemListViewModel();
            BindingContext = itemListViewModel;
        }

        protected override async void OnAppearing()
        {

            base.OnAppearing();
            postsListView.ItemsSource = await App.Database.GetPostAsync();

        }

        // Local connection using SQLite ;
        async void OnToggled_L(object sender, EventArgs e)
        {
            postsListView.ItemsSource = await App.Database.GetPostAsync();
            Additem.IsEnabled = true;
        }

        // Remote connection using jsonplaceholder.typicode.com/posts;
        async void OnToggled_R(object sender, EventArgs e)
        {
            await itemListViewModel.UpdatePostsAsync();
            postsListView.ItemsSource = await itemListViewModel.Fetchpost();
            Additem.IsEnabled = false;
        }


        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new NewPostPage
                {
                    BindingContext = e.SelectedItem as Post
                });
            }
        }
    }
}