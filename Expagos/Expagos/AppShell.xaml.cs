using System;
using System.Collections.Generic;
using Expagos.ViewModels;
using ExPagos.DTOs;
using Xamarin.Forms;

namespace Expagos
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public static PagosViewModel VmPagosViewModel;
        public AppShell()
        {
            InitializeComponent();
            VmPagosViewModel = new PagosViewModel();
        }
    }
}
