using System;
using System.Collections.Generic;
using System.Linq;
using SQLite;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Practica6.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Principal : ContentPage
    {
        SQLiteConnection database;
        public ObservableCollection<TESHDatos> items { get; set; }

        public Principal()
        {
            InitializeComponent();

            string db;
            db = DependencyService.Get<ISQLite>().GetLocalFilePath("TESHDB.db");
            database = new SQLiteConnection(db);
            database.CreateTable<TESHDatos>();
            items = new ObservableCollection<TESHDatos>(database.Table<TESHDatos>());
            BindingContext = this;
        }

        private void buscarRegistrosSB_SearchButtonPressed(object sender, EventArgs e)
        {
            
        }

        private void buscarRegistrosSB_TextChanged(object sender, TextChangedEventArgs e)
        {
            var teclado = buscarRSB.Text;
            var sugNom = items.Where(n => n.Nombre.Contains(buscarRSB.Text.ToUpper()));
            registrosLV.ItemsSource = sugNom;
        }

        private void registrosLV_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;
        }

        private void Agregar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DatosPersonales());
        }

        private void delete_Clicked(object sender, EventArgs e)
        {
            if (registrosLV.SelectedItem == null)
            {
                DisplayAlert("HOLA!", "Selecciona un registro", "Aceptar");
            }
            else
            {
                var datos = new TESHDatos
                {

                };
                database.Delete(registrosLV.SelectedItem);
                Navigation.PushAsync(new Principal()).Wait();
            }           
        }

        async void ma_Clicked(object sender, EventArgs e)
        {
            if (registrosLV.SelectedItem == null)
            {
                await DisplayAlert("HOLA!", "Selecciona un registro", "Aceptar");
            }
            else
            {
                await Navigation.PushAsync(new MM(registrosLV.SelectedItem as TESHDatos));
            }  
        }

        private void registrosLV_Refreshing(object sender, EventArgs e)
        {
            Device.StartTimer(new TimeSpan(0, 0, 10), () =>
               {
                   return true;
               });

        }
    }
}