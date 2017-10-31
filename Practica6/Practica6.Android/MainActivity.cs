using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;

namespace Practica6.Droid
{
    [Activity(Label = "Practica6", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity/*, ISQLAzure*/
    {
        private MobileServiceUser usuario;
        //public async Task<MobileServiceUser> Authenticate()
        //{
        //    var message=string.Empty;
        //    try
        //    {
        //        usuario = await Practica6.View.Principal.cliente.LoginAsync(this, MobileServiceAuthenticationProvider.Facebook,);
        //        if (usuario != null)
        //        {

        //        }
        //    }
        //}

        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }
    }
}

