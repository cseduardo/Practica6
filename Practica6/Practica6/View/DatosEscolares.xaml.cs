using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practica6.ViewModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Practica6.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DatosEscolares : ContentPage
    {
        public DatosEscolares()
        {
            InitializeComponent();
        }
        public void nextPaged(object sender, EventArgs e)
        {
            locals.carrera = Convert.ToString(career.SelectedItem);
            locals.semestre = Convert.ToString(picker.SelectedItem);
            locals.id = Convert.ToInt32(matricula.Text);
            Navigation.PushModalAsync(new DatosSociales());
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