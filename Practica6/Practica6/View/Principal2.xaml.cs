using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Practica6.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Principal2 : ContentPage
    {
        public ObservableCollection<TESHDatos> items { get; set; }
        public static IMobileServiceTable<TESHDatos> Tabla;
        public Principal2()
        {
            InitializeComponent();
            Tabla = View.Log_in.cliente.GetTable<TESHDatos>();
            LeerTablaU();
        }
        private async void LeerTablaU()
        {
            IEnumerable<TESHDatos> elementos = await Tabla.IncludeDeleted().Where(DatosBD => DatosBD.Deleted == true).ToCollectionAsync();
            items = new ObservableCollection<TESHDatos>(elementos);
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

        async void ma_Clicked(object sender, EventArgs e)
        {
            if (registrosLV.SelectedItem == null)
            {
                await DisplayAlert("HOLA!", "Selecciona un registro", "Aceptar");
            }
            else
            {
                await Navigation.PushAsync(new MM2(registrosLV.SelectedItem as TESHDatos));
            }
        }

        private void registrosLV_Refreshing(object sender, EventArgs e)
        {
            Device.StartTimer(new TimeSpan(0, 0, 10), () =>
            {
                return true;
            });
        }

        private void mtodo_Toggled(object sender, ToggledEventArgs e)
        {
            if (mtodo.IsToggled == false)
            {
                Navigation.PushAsync(new Principal());
            }
        }
    }
}