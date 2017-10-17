using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Globalization;
using Practica6.ViewModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Practica6.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DatosSociales : ContentPage
    {
        public DatosSociales()
        {
            InitializeComponent();
        }
        public void nextPagen(object sender, EventArgs e)
        {

            locals.email = correo.Text;
            locals.git = github.Text;
            var em = correo.Text;

            var emailPattern = "^(?(\")(\").+?(?<!\\\\)\"@)|(([0-9a-z]((\\.(?!\\.))|[-!#\\$%&\'\\*\\+/=\\?\\^`\\{\\}\\|~\\w])*)(?<=[0-9a-z])@))(?(\\[)(\\[(\\d{1.3}\\.){3}\\d{1,3}\\])|(([0-9a-z][-\\w]*[0-9a-z]*\\.)+[a-z0-9][\\-a-z0-9]{0,22}[a-z0-9]))$";
            var emailPattern2 = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";
                if (Regex.IsMatch(em, emailPattern2))
            {
                //aqui va el codigo si el correo valido
                Navigation.PushModalAsync(new MDatos());
            }
            else
            {
                //aqui va el codigo si el correo es invalido
                evalid.Text = "Corrreo NO valido";
            }

        }
    }
}