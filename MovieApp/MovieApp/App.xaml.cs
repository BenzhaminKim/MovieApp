using System;
using MovieApp.View;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MovieApp.ViewModel;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MovieApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage =  new NavigationPage( new MainPage());
            ((MainPage as NavigationPage).CurrentPage as TabbedPage).Children[0].BindingContext =  new SpeakerVM();
            ((MainPage as NavigationPage).CurrentPage as TabbedPage).Children[1].BindingContext = new DiaryListVM();
            ((MainPage as NavigationPage).CurrentPage as TabbedPage).Children[2].BindingContext = new WriteDiaryVM();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
