using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Expagos.ViewModels;
using ExPagos.DTOs;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Expagos.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PagosNoAutorizadosPage : ContentPage
    {
        public PagosNoAutorizadosPage()
        {
            InitializeComponent();

            MessagingCenter.Unsubscribe<PagosViewModel, PAGO>(this, "AbrirComentario");

            MessagingCenter.Subscribe<PagosViewModel, PAGO>(this, "AbrirComentario", async (obj, item) =>
            {
                await Navigation.PushModalAsync(new ComentarioPAge(item), true);
            });
            BindingContext = AppShell.VmPagosViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
                AppShell.VmPagosViewModel.Autorizado = 0;
                AppShell.VmPagosViewModel.ListarPagosCommand.Execute(null);
        }

        protected override void OnDisappearing()
        {
            MessagingCenter.Unsubscribe<PagosViewModel, PAGO>(this, "AbrirComentario");
        }
    }
}