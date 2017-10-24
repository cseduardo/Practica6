using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practica6.ViewModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;

namespace Practica6.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DatosEscolares : ContentPage
    {
        SQLiteAsyncConnection database;
        public DatosEscolares()
        {
            InitializeComponent();
        }
        public void nextPaged(object sender, EventArgs e)
        {
            if (career.SelectedItem == null)
            {
                DisplayAlert("Te falta", "Selecciona una Carrera", "Aceptar");
            }
            else
            {
                if (picker.SelectedItem == null)
                {
                    DisplayAlert("Te falta", "Selecciona ", "Aceptar");
                }
                else
                {
                    if (matricula.Text == null)
                    {
                        DisplayAlert("Te falta", "Ingresa tú Matricula", "Aceptar");
                    }
                    else
                    {
                        locals.carrera = Convert.ToInt32(career.SelectedIndex);
                        locals.semestre = Convert.ToInt32(picker.SelectedIndex);
                        locals.id = Convert.ToInt32(matricula.Text);
                        Navigation.PushAsync(new DatosSociales());
                    }
                }
            }           
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