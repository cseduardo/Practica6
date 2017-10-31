using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Globalization;
using Practica6.ViewModel;
using Microsoft.WindowsAzure.MobileServices;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;

namespace Practica6.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DatosSociales : ContentPage
    {
        SQLiteAsyncConnection database;
        public DatosSociales()
        {
            InitializeComponent();
            string db;
            db = DependencyService.Get<ISQLite>().GetLocalFilePath("TESHDB.db");
            database = new SQLiteAsyncConnection(db);
        }
        async void nextPagen(object sender, EventArgs e)
        {
           
            var email = correo.Text;
            var git = github.Text;
            var em = correo.Text;

            //var emailPattern = "^(?(\")(\").+?(?<!\\\\)\"@)|(([0-9a-z]((\\.(?!\\.))|[-!#\\$%&\'\\*\\+/=\\?\\^`\\{\\}\\|~\\w])*)(?<=[0-9a-z])@))(?(\\[)(\\[(\\d{1.3}\\.){3}\\d{1,3}\\])|(([0-9a-z][-\\w]*[0-9a-z]*\\.)+[a-z0-9][\\-a-z0-9]{0,22}[a-z0-9]))$";
            var emailPattern2 = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";
            if (correo == null)
            {
                correo.Text = "Ingresa un correo";
            }
            else
            {
                if (Regex.IsMatch(em, emailPattern2))
                {
                    //aqui va el codigo si el correo valido                
                    var elementos = new TESHDatos
                    {
                        Matricula = locals.id,
                        Nombre = locals.nombre,
                        Ape_Pat = locals.ape_pat,
                        Ape_Mat = locals.ape_mat,
                        Calle = locals.calle,
                        Num_calle = locals.num_calle,
                        Colonia = locals.colonia,
                        Municipio = locals.municipio,
                        Estado = locals.estado,
                        Cod_Postal = locals.cod_postal,
                        Telefono = locals.num_telefono,
                        Carrera = locals.carrera,
                        Semestre = locals.semestre,
                        Email = email,
                        Git = git
                    };
                    await Practica6.View.Principal.Tabla.InsertAsync(elementos);
                    await Navigation.PushAsync(new View.DatosPersonales());
                }
                else
                {
                    //aqui va el codigo si el correo es invalido
                    evalid.Text = "Corrreo NO valido";
                }
            }
                

        }

        private void finalizarR_Clicked(object sender, EventArgs e)
        {
            var email = correo.Text;
            var git = github.Text;
            var em = correo.Text;

            //var emailPattern = "^(?(\")(\").+?(?<!\\\\)\"@)|(([0-9a-z]((\\.(?!\\.))|[-!#\\$%&\'\\*\\+/=\\?\\^`\\{\\}\\|~\\w])*)(?<=[0-9a-z])@))(?(\\[)(\\[(\\d{1.3}\\.){3}\\d{1,3}\\])|(([0-9a-z][-\\w]*[0-9a-z]*\\.)+[a-z0-9][\\-a-z0-9]{0,22}[a-z0-9]))$";
            var emailPattern2 = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";
            if (correo == null)
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
                        Matricula = locals.id,
                        Nombre = locals.nombre,
                        Ape_Pat = locals.ape_pat,
                        Ape_Mat = locals.ape_mat,
                        Calle = locals.calle,
                        Num_calle = locals.num_calle,
                        Colonia = locals.colonia,
                        Municipio = locals.municipio,
                        Estado = locals.estado,
                        Cod_Postal = locals.cod_postal,
                        Telefono = locals.num_telefono,
                        Carrera = locals.carrera,
                        Semestre = locals.semestre,
                        Email = email,
                        Git = git
                    };
                    try
                    {
                        database.InsertAsync(elementos).Wait();
                    }catch(SQLiteException ex)
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