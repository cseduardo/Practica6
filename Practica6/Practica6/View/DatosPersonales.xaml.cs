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
        }
        public void nextPage(object sender, EventArgs e)
        {
            if (name.Text == null)
            {
                DisplayAlert("Te falta", "Ingresa tú Nombre", "Aceptar");
            }
            else
            {
                if (lastname.Text == null)
                {
                    DisplayAlert("Te falta", "Ingresa tú Apellido Paterno", "Aceptar");
                }
                else
                {
                    if (surname.Text == null)
                    {
                        DisplayAlert("Te falta", "Ingresa tú Apellido Materno", "Aceptar");
                    }
                    else
                    {
                        if (street.Text == null)
                        {
                            DisplayAlert("Te falta", "Ingresa la calle en donde vives", "Aceptar");
                        }
                        else
                        {
                            if (street_num.Text == null)
                            {
                                DisplayAlert("Te falta", "Ingresa el numero de tú casa", "Aceptar");
                            }
                            else
                            {
                                if (col.Text == null)
                                {
                                    DisplayAlert("Te falta", "Ingresa el nombre de tú colonia", "Aceptar");
                                }
                                else
                                {
                                    if (cod_p.Text == null)
                                    {
                                        DisplayAlert("Te falta", "Ingresa el codigo postal de donde vives", "Aceptar");
                                    }
                                    else
                                    {
                                        if (mun.Text == null)
                                        {
                                            DisplayAlert("Te falta", "Ingresa el Municipio ó Delegacion en donde vives", "Aceptar");
                                        }
                                        else
                                        {
                                            if (state.Text == null)
                                            {
                                                DisplayAlert("Te falta", "Ingresa el Estado donde vives", "Aceptar");
                                            }
                                            else
                                            {
                                                if (telephone.Text == null)
                                                {
                                                    DisplayAlert("Te falta", "Ingresa tú numero telefonico", "Aceptar");
                                                }else
                                                {
                                                    ViewModel.locals.nombre = name.Text;
                                                    ViewModel.locals.ape_pat = lastname.Text;
                                                    ViewModel.locals.ape_mat = surname.Text;
                                                    ViewModel.locals.calle = street.Text;
                                                    ViewModel.locals.colonia = col.Text;
                                                    ViewModel.locals.municipio = mun.Text;
                                                    ViewModel.locals.estado = state.Text;
                                                    ViewModel.locals.cod_postal = Convert.ToInt32(cod_p.Text);
                                                    ViewModel.locals.num_calle = Convert.ToInt32(street_num.Text);
                                                    ViewModel.locals.num_telefono = telephone.Text;
                                                    /*as in the class locals you are assigned a type of variable in specific, if in the XAML it is indicated that the entry is 
                                                     * of type number must be converted to variables of type int, double, float, any type variable of number before gardarla in 
                                                     * the variable*/
                                                    Navigation.PushAsync(new DatosEscolares());
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
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

            }
            else
            {
                DisplayAlert("", "Solo Numeros", "Aceptar");
            }
            
        }

        private void name_TextChanged(object sender, TextChangedEventArgs e)
        {
            name.Text = name.Text.ToUpper();
        }

        private void lastname_TextChanged(object sender, TextChangedEventArgs e)
        {
            lastname.Text = lastname.Text.ToUpper();
        }

        private void surname_TextChanged(object sender, TextChangedEventArgs e)
        {
            surname.Text = surname.Text.ToUpper();
        }

        private void street_TextChanged(object sender, TextChangedEventArgs e)
        {
            street.Text = street.Text.ToUpper();
        }

        private void col_TextChanged(object sender, TextChangedEventArgs e)
        {
            col.Text = col.Text.ToUpper();
        }

        private void mun_TextChanged(object sender, TextChangedEventArgs e)
        {
            mun.Text = mun.Text.ToUpper();
        }

        private void state_TextChanged(object sender, TextChangedEventArgs e)
        {
            state.Text = state.Text.ToUpper();
        }
    }
}