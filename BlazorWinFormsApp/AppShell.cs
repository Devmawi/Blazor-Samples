using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Components.WebView.WindowsForms;
using BlazorWinFormsApp.BlazorApp;

namespace BlazorWinFormsApp
{
    public partial class AppShell : Form
    {
       
        public AppShell()
        {
            InitializeComponent();
            InitializeBlazorWebView();
        }
        public void InitializeBlazorWebView() {
            
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddBlazorWebView();
            serviceCollection.AddScoped(sp => new HttpClient { BaseAddress = new Uri("") });

            //#if DEBUG
            //            services1.AddBlazorWebViewDeveloperTools();
            //#endif
            //            var services2 = new ServiceCollection();
            //            services2.AddWindowsFormsBlazorWebView();
            //#if DEBUG
            //            services2.AddBlazorWebViewDeveloperTools();
            //#endif

            mainBlazorWebView.HostPage = "wwwroot\\index.html";
            mainBlazorWebView.Services = serviceCollection.BuildServiceProvider();
            mainBlazorWebView.RootComponents.Add<App>("#app");

        }
    }
}