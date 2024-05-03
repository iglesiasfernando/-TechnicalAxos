using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechnicalAxos.Droid.Services;
using TechnicalAxos.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(IdService))]
namespace TechnicalAxos.Droid.Services
{
    public class IdService : IIdService
    {
        public string GetId()
        {
            return Android.App.Application.Context.PackageName;
        }
    }
}