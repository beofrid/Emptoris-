﻿using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Views;
using Microsoft.Maui.Controls.PlatformConfiguration.AndroidSpecific;
using Android.Views.InputMethods;

namespace Emptoris
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, LaunchMode = LaunchMode.SingleTop, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {
      
    }
}
