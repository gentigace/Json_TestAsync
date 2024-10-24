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

        public ItemListPage()
        {
            InitializeComponent();
            itemListViewModel = new ItemListViewModel();
            BindingContext = itemListViewModel;
        }

        // Called when the page appears
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            postsListView.ItemsSource = await App.Database.GetPostAsync();
        }

        // Add new post through toolbar button
        async void NewToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewPostPage
            {
                BindingContext = new Post()
            });
        }

        // Local connection using SQLite (Triggered when the local connection checkbox is checked/unchecked)
        async void OnCheckedChanged_L(object sender, CheckedChangedEventArgs e)
        {
            if (e.Value) // If checkbox is checked
            {
                postsListView.ItemsSource = await App.Database.GetPostAsync();
                Additem.IsEnabled = true;
            }
            else
            {
                // Handle unchecked state if needed
            }
        }

        // Remote connection using jsonplaceholder.typicode.com/posts (Triggered when the remote connection checkbox is checked/unchecked)
        async void OnCheckedChanged_R(object sender, CheckedChangedEventArgs e)
        {
            if (e.Value) // If checkbox is checked
            {
                await itemListViewModel.UpdatePostsAsync();
                postsListView.ItemsSource = await itemListViewModel.Fetchpost();
                Additem.IsEnabled = false;
            }
            else
            {
                // Handle unchecked state if needed
            }
        }

        // Handle item selection from the list
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
