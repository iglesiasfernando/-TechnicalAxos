using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalAxos.ViewModels;
using Xamarin.Forms;

namespace TechnicalAxos
{
    public partial class MainPage : ContentPage
    {
        MainPageViewModel MainPageViewModel;
        public MainPage()
        {
            InitializeComponent();
            BindingContext = MainPageViewModel = new MainPageViewModel();
        }
    }
}
