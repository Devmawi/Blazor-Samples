using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Components.WebView.WindowsForms;
using BlazorWinFormsApp.BlazorApp;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;

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
            //            serviceCollection.AddBlazorWebViewDeveloperTools(); // Comes later: https://github.com/dotnet/maui/commit/cfc3fab4b07db3c5aeabf20819efc7b140144215
            //#endif
            //            var services2 = new ServiceCollection();
            //            services2.AddWindowsFormsBlazorWebView();
            //#if DEBUG
            //            services2.AddBlazorWebViewDeveloperTools();
            //#endif
           
            mainBlazorWebView.HostPage = "wwwroot\\index.html";
            mainBlazorWebView.Services = serviceCollection.BuildServiceProvider();
            mainBlazorWebView.RootComponents.Add<App>("#app");

            // See also https://github.com/dotnet/maui/issues/3861
            var userData = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "BlazorWinFormsApp");
            var creationProperties = new CoreWebView2CreationProperties()
            {
                UserDataFolder = userData
            };
            Directory.CreateDirectory(userData);
            //MessageBox.Show(userData);
            mainBlazorWebView.WebView.CreationProperties = creationProperties;
        }
       
    }
}