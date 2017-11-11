﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace Practica6.UWP
{
    public sealed partial class MainPage:ISQLAzure
    {
        private MobileServiceUser usuario;//debe de ser privada por la seguridad de los datos del usuario q se va autenticar
        public async Task<MobileServiceUser> Authenticate()
        {
            try
            {
                usuario = await Practica6.View.Log_in.cliente.LoginAsync(MobileServiceAuthenticationProvider.Facebook, "registrosbdedtesh.azurewebsites.net");
                if (usuario != null)
                {
                    await new MessageDialog(usuario.UserId, "Bienvenido").ShowAsync();
                }
            }
            catch(Exception ex)
            {
                await new MessageDialog(ex.Message, "Error").ShowAsync();
            }
            return usuario;
        }
        public MainPage()
        {
            this.InitializeComponent();
            Practica6.App.Init((ISQLAzure)this);
            LoadApplication(new Practica6.App());
        }
    }
}
