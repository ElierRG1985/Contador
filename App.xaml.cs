using System.Diagnostics.CodeAnalysis;
using Contador.Views;
//using Microsoft.Maui.Controls.Compatibility.Platform.Android;
#if WINDOWS
    using Microsoft.UI;
    using Microsoft.UI.Windowing;
#endif

namespace Contador
{
    public partial class App : Application
    {
        public static ViewModel.ViewModel ViewModel;

        public App()
        {
            InitializeComponent();

            ViewModel = new ViewModel.ViewModel();

            MainPage = new AppTabbedPage();

#if WINDOWS
                            SetWinNoResizable();
#endif

        }

        protected override Window CreateWindow(IActivationState activationState)
        {
            var window = base.CreateWindow(activationState);

            const int newWidth = 400;
            const int newHeight = 800;

            window.Width = newWidth;
            window.Height = newHeight;

            return window;
        }

        private void SetWinNoResizable()
        {
            Microsoft.Maui.Handlers.WindowHandler.Mapper.AppendToMapping(nameof(IWindow),
                (handler, view) =>
                {
#if WINDOWS
                            var nativeWindow = handler.PlatformView;
                            var windowHandle = WinRT.Interop.WindowNative.GetWindowHandle(nativeWindow);
                            var windowId = Win32Interop.GetWindowIdFromWindow(windowHandle);
                            var appWindow = AppWindow.GetFromWindowId(windowId);
                            var presenter = appWindow.Presenter as OverlappedPresenter;
                            presenter.IsResizable = false;
                            presenter.IsMaximizable = false;
                            presenter.IsMinimizable = false;
#endif
                });
        }
    }
}
