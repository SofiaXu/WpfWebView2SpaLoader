using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace WpfWebView2SpaLoader
{
    public partial class App : Application, IAsyncDisposable
    {
        public WebApplication? WebApplication { get; private set; }

        public async ValueTask DisposeAsync()
        {
            if (WebApplication is not null)
            {
                await WebApplication.DisposeAsync();
            }
            GC.SuppressFinalize(this);
        }

        private async void ApplicationStartup(object sender, StartupEventArgs e)
        {
            // 这里是创建 ASP.NET 版通用主机的代码
            var builder = WebApplication.CreateBuilder(Environment.GetCommandLineArgs());
            // 注册主窗口和其他服务
            builder.Services.AddSingleton<MainWindow>();
            builder.Services.AddSingleton(this);
            var app = builder.Build();
            // 这里是文件类型映射，如果你的静态文件在浏览器中加载报 404，那么需要在这里注册，这里我加载一个 3D 场景文件的类型
            var contentTypeProvider = new FileExtensionContentTypeProvider();
            contentTypeProvider.Mappings[".glb"] = "model/gltf-binary";
            app.UseStaticFiles(new StaticFileOptions
            {
                ContentTypeProvider = contentTypeProvider,
            });
            // 你如果使用了 Vue Router 或者其他前端路由了，需要在这里添加这句话让路由返回前端，而不是 ASP.NET Core 处理
            app.MapFallbackToFile("/index.html");
            WebApplication = app;
            // 处理退出事件，退出 App 时关闭 ASP.NET Core
            Exit += async (s, e) => await WebApplication.StopAsync();
            // 显示主窗口
            MainWindow = app.Services.GetRequiredService<MainWindow>();
            MainWindow.Show();
            await app.RunAsync().ConfigureAwait(false);
        }
    }
}
