using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practica6.ViewModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Text.RegularExpressions;

namespace Practica6.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MM : ContentPage
	{
        SQLiteConnection database;
        public MM (object selectedItem)
		{
            var dato = selectedItem as TESHDatos;
            BindingContext = dato;
			InitializeComponent ();
            string db;
            db = DependencyService.Get<ISQLite>().GetLocalFilePath("TESHDB.db");
            database = new SQLiteConnection(db);
            matricula.Text=Convert.ToString(dato.Matricula);
            name.Text=dato.Nombre;
            lastname.Text=dato.Ape_Pat;
            surname.Text=dato.Ape_Mat;
            street.Text=dato.Calle;
            street_num.Text=Convert.ToString(dato.Num_calle);
            col.Text=dato.Colonia;
            mun.Text=dato.Municipio;
            state.Text=dato.Estado;
            cod_p.Text=Convert.ToString(dato.Cod_Postal);
            telephone.Text=Convert.ToString(dato.Telefono);
            career.SelectedIndex=dato.Carrera;
            picker.SelectedIndex=dato.Semestre;
            correo.Text=dato.Email;
            github.Text = dato.Git;
        }
        public void actualizar_Clicked(object sender, EventArgs e)
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
                                                }
                                                else
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
                                                                var email = correo.Text;
                                                                var git = github.Text;
                                                                var em = correo.Text;

                                                                //var emailPattern = "^(?(\")(\").+?(?<!\\\\)\"@)|(([0-9a-z]((\\.(?!\\.))|[-!#\\$%&\'\\*\\+/=\\?\\^`\\{\\}\\|~\\w])*)(?<=[0-9a-z])@))(?(\\[)(\\[(\\d{1.3}\\.){3}\\d{1,3}\\])|(([0-9a-z][-\\w]*[0-9a-z]*\\.)+[a-z0-9][\\-a-z0-9]{0,22}[a-z0-9]))$";
                                                                var emailPattern2 = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                                                                    @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";
                                                                if (correo.Text == null)
                                                                {
                                                                    evalid.Text = "Ingresa un correo";
                                                                }
                                                                else
                                                                {
                                                                    if (Regex.IsMatch(em, emailPattern2))
                                                                    {
                                                                        //aqui va el codigo si el correo valido                
                                                                        var elementos = new TESHDatos
                                                                        {
                                                                            Matricula = Convert.ToInt32(matricula.Text),
                                                                            Nombre = name.Text,
                                                                            Ape_Pat = lastname.Text,
                                                                            Ape_Mat = surname.Text,
                                                                            Calle = street.Text,
                                                                            Num_calle = Convert.ToInt32(street_num.Text),
                                                                            Colonia = col.Text,
                                                                            Municipio = mun.Text,
                                                                            Estado = state.Text,
                                                                            Cod_Postal = Convert.ToInt32(cod_p.Text),
                                                                            Telefono = telephone.Text,
                                                                            Carrera = career.SelectedIndex,
                                                                            Semestre = picker.SelectedIndex,
                                                                            Email = email,
                                                                            Git = git,
                                                                        };
                                                                        try
                                                                        {
                                                                            database.Update(elementos);
                                                                        }
                                                                        catch (SQLiteException ex)
                                                                        {
                                                                            DisplayAlert("Error", "No se pudo ingresar el registro", "Aceptar");
                                                                        }
                                                                        Navigation.PushAsync(new View.Principal()).Wait();
                                                                    }
                                                                    else
                                                                    {
                                                                        //aqui va el codigo si el correo es invalido
                                                                        evalid.Text = "Corrreo NO valido";
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