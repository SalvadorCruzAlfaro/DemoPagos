using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExPagos.DTOs;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Expagos.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ComentarioPAge : ContentPage
    {
        public ComentarioPAge(PAGO entidad)
        {
            InitializeComponent();
            BindingContext = entidad;
        }

        private async void Aceptar_OnClicked(object sender, EventArgs e)
        {            
            await Navigation.PopModalAsync();
            MessagingCenter.Send(this, "Comentado", (PAGO)BindingContext);
        }

        private async void Cancelar_OnClicked(object sender, EventArgs e)
        {            
            await Navigation.PopModalAsync();
            MessagingCenter.Send(this, "NoComentado", (PAGO)BindingContext);
        }
    }
}