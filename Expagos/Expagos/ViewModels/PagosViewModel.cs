using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using Expagos.Models;
using Expagos.Views;
using ExPagos.DTOs;
using Xamarin.Forms;

namespace Expagos.ViewModels
{
    public class PagosViewModel : BaseViewModel
    {
        public ObservableCollection<VMPago> Pagos { get; set; }
        public Command ListarPagosCommand { get; set; }
        public byte? Autorizado { get; set; }


        public PagosViewModel()
        {
            Title = "";
            Pagos = new ObservableCollection<VMPago>();
            ListarPagosCommand = new Command(async () =>
            {
                if (IsBusy)
                    return;

                IsBusy = true;

                try
                {
                    Pagos.Clear();
                    var items = await DataStore.GetItemsAsync<PAGO>("Pago", "ListaElementosConCliente", "autorizacion", Autorizado);
                    foreach (var item in items)
                    {
                        Pagos.Add(new VMPago
                        {
                            Pago = item
                        });
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
                finally
                {
                    IsBusy = false;
                }
            });

            MessagingCenter.Unsubscribe<VMPago, bool>(this, "Aceptado");
            MessagingCenter.Subscribe<VMPago, bool>(this, "Aceptado", (obj, item) =>
             {
                 if (item)
                     ListarPagosCommand.Execute(null);
             });

            MessagingCenter.Unsubscribe<VMPago, PAGO>(this, "PorComentar");
            MessagingCenter.Subscribe<VMPago, PAGO>(this, "PorComentar", async (obj, item) =>
            {
                MessagingCenter.Send(this, "AbrirComentario", item);
            });
        }
    }
}
