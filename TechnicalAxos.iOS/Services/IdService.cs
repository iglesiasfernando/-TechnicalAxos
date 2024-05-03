using Foundation;
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
            return NSBundle.MainBundle.BundleIdentifier;
        }
    }
}