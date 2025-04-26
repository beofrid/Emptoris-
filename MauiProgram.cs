using Emptoris.Data;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Handlers;
using System.Diagnostics;

namespace Emptoris
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {

                    fonts.AddFont("Lexend.ttf", "Lexend");
                    fonts.AddFont("Allison-Regular.ttf", "Allison");
                    fonts.AddFont("MonaSans-Light.ttf", "MonaSans");
                    fonts.AddFont("Montserrat-Thin.ttf", "Montserrat");
                    fonts.AddFont("Quicksand-Light.ttf", "Quicksand");

                });

            builder.Logging.AddDebug();
            builder.Services.AddSingleton<DBAccess>();
            builder.ConfigureMauiHandlers(handlers =>
            {
                EntryHandler.Mapper.AppendToMapping("CustomEntry", (handler, view) =>
                {
#if ANDROID
                handler.PlatformView.BackgroundTintList =
                    Android.Content.Res.ColorStateList.ValueOf(Android.Graphics.Color.ParseColor("#060606"));

                handler.PlatformView.SetTextCursorDrawable(Resource.Drawable.custom_cursor); // custom cursor if needed
#endif

#if IOS
                    handler.PlatformView.TintColor = UIKit.UIColor.DarkGray;
#endif
                });
            });

            return builder.Build();
        }
    }
}