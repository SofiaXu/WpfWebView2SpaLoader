# WpfWebView2SpaLoader

这是一个用于加载单页应用（SPA）的 WPF 示例项目，使用了 WebView2 控件和 ASP.NET Core Web API。

## 项目结构

- `WpfWebView2SpaLoader`：WPF 项目，用于加载 SPA。
  - `MainWindow.xaml`：主窗口，包含 WebView2 控件。
  - `MainWindow.xaml.cs`：主窗口的代码文件。
  - `App.xaml`：应用程序的入口。
  - `App.xaml.cs`：应用程序的代码文件。
  - `wwwroot`：SPA 项目的输出目录。
- `test-spa-vue`：Vue.js SPA 项目。

## 使用方法

0. wwwroot 中已包含编译完成的 SPA 项目，若要重新编译 SPA 项目，请安装 pnpm（`npm install -g pnpm`）并在 `test-spa-vue` 目录下运行 `pnpm install` 和 `pnpm run build`。
1. 打开 `WpfWebView2SpaLoader.sln`。
2. 在 Visual Studio 中启动项目。
3. 等待项目启动完成，即可看到 SPA 项目被加载到 WebView2 控件中。

或者

1. 在 `WpfWebView2SpaLoader` 目录下运行 `dotnet run`。

## 许可证

MIT

## 介绍博客

[在 WPF 中集成 ASP.NET Core 和 WebView2 用于集成 SPA 应用](https://www.cnblogs.com/aobaxu/p/18186785)
