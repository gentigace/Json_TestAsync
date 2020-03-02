using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Json_TestAsync.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Json_TestAsync.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewPostPage : ContentPage
    {
        public NewPostPage()
        {
            InitializeComponent();
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var post = (Post)BindingContext;
            await App.Database.SavePostAsync(post);
            await Navigation.PopAsync();
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var post = (Post)BindingContext;
            await App.Database.DeletePostAsync(post);
            await Navigation.PopAsync();
        }
    }
}