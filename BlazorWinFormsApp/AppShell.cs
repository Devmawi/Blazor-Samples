using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Components.WebView.WindowsForms;
using BlazorWinFormsApp.BlazorApp;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;
using System.Diagnostics;

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
            serviceCollection.AddWindowsFormsBlazorWebView();
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
            var userData = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "BlazorWinFormsApp");
            //Directory.CreateDirectory(userData);
            var creationProperties = new CoreWebView2CreationProperties()
            {
                UserDataFolder = userData
            };
            mainBlazorWebView.WebView.CreationProperties = creationProperties;
            mainBlazorWebView.WebView.CoreWebView2InitializationCompleted += WebView_CoreWebView2InitializationCompleted;
        }

        private void WebView_CoreWebView2InitializationCompleted(object? sender, CoreWebView2InitializationCompletedEventArgs e)
        {
            Debug.Print(mainBlazorWebView.WebView.CreationProperties.BrowserExecutableFolder);
        }

        private void AppShell_Load(object sender, EventArgs e)
        {
            
        }
    }
}