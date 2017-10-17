using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Text.RegularExpressions;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Practica6.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DatosPersonales : ContentPage
    {
        public DatosPersonales()
        {
            InitializeComponent();
            SQLiteAsyncConnection database;
            string db;
            db = DependencyService.Get<ISQLite>().GetLocalFilePath("TESHDB.db");
            database = new SQLiteAsyncConnection(db);
            database.CreateTableAsync<TESHDatos>().Wait();
        }
        public void nextPage(object sender, EventArgs e)
        {
            /*the variables created in the locals class are called to save the value contained in the entry*/
            ViewModel.locals.nombre = name.Text;
            ViewModel.locals.ape_pat = lastname.Text;
            ViewModel.locals.ape_mat = surname.Text;
            ViewModel.locals.calle = street.Text;
            ViewModel.locals.colonia = col.Text;
            ViewModel.locals.municipio = mun.Text;
            ViewModel.locals.estado = state.Text;
            ViewModel.locals.cod_postal = Convert.ToInt32(cod_p.Text);
            ViewModel.locals.num_calle = Convert.ToInt32(street_num.Text);
            ViewModel.locals.num_telefono = Convert.ToInt32(telephone.Text);
            /*as in the class locals you are assigned a type of variable in specific, if in the XAML it is indicated that the entry is 
             * of type number must be converted to variables of type int, double, float, any type variable of number before gardarla in 
             * the variable*/
            Navigation.PushModalAsync(new DatosEscolares());
        }
        public void only_num(object sender, TextChangedEventArgs e)
        {
            int result;
            bool isValid = int.TryParse(e.NewTextValue, out result);
            ((Entry)sender).TextColor = isValid ? Color.Default : Color.Red;
            if (isValid)
            {
                nextp.IsEnabled = true;
            }
            else
            {
                DisplayAlert("", "Solo Numeros", "Aceptar");
                nextp.IsEnabled = false;
            }
        }
    }
}