using System;
using System.Collections.Generic;
using System.Text;
using Expagos.Views;
using ExPagos.DTOs;
using Xamarin.Forms;

namespace Expagos.ViewModels
{
    public class VMPago : BaseViewModel
    {
        public PAGO Pago { get; set; }

        public Command<int> AceptarCommand { get; set; }
        public Command<int> RechazarCommand { get; set; }

        public VMPago()
        {
            MessagingCenter.Unsubscribe<ComentarioPAge, PAGO>(this, "Comentado");
            MessagingCenter.Subscribe<ComentarioPAge, PAGO>(this, "Comentado", async (obj, item) =>
            {
                var newItem = item as PAGO;
                await DataStore.UpdateItemAsync<PAGO>(newItem, "Pago", "ActualizarElementoConFecha");
                MessagingCenter.Send(this, "Aceptado", true);
            });

            MessagingCenter.Unsubscribe<ComentarioPAge, PAGO>(this, "NoComentado");
            MessagingCenter.Subscribe<ComentarioPAge, PAGO>(this, "NoComentado", async (obj, item) =>
            {
                MessagingCenter.Send(this, "Aceptado", false);
            });


            AceptarCommand = new Command<int>(async i =>
            {
                var encontrado = await DataStore.GetItemAsync<PAGO>(i, "Pago");
                encontrado.Autorizacion = 1;
                MessagingCenter.Send(this, "PorComentar", encontrado);
            });

            RechazarCommand = new Command<int>(async i =>
            {
                var encontrado = await DataStore.GetItemAsync<PAGO>(i, "Pago");
                encontrado.Autorizacion = 0;
                MessagingCenter.Send(this, "PorComentar", encontrado);
            });
        }
    }
}
