using IsacMobile.Services;
using PropertyChanged;
using Refit;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using TechnicalAxos.Interfaces;
using TechnicalAxos.Models;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace TechnicalAxos.ViewModels
{
    [AddINotifyPropertyChangedInterface]

    public class MainPageViewModel
    {
        public string BundleId { get; set; }
        public Command SelectPictureCommand { get; set; }
        public ObservableCollection<Country> Countries { get; set; }

        //this string can be in a config file, i think its not necessary for the test
        public string ImageUrl { get; set; } = "https://random.dog/af70ad75-24af-4518-bf03-fec4a997004c.jpg";
        public MainPageViewModel() {

            Countries = new ObservableCollection<Country>();
            SelectPictureCommand = new Command(() => SelectPictureClick());

            this.BundleId = GetId();
            GetCountries();
            
        }  

        /**
         * Returns a list of countries from the server
         * */
        public async void GetCountries()
        {
            try
            {
                var current = Connectivity.NetworkAccess;

                if (current == NetworkAccess.Internet)
                {
                    var countryList = await ApiService.GetCountries(); //here we can implement a pagination method
                    foreach (Country country in countryList)
                    {
                        this.Countries.Add(country);
                    }
                }
                else
                {
                    //Without internet I do nothing, here we can alert to the user
                    Console.WriteLine("You dont have internet connection");
                }
            }
            catch (ApiException){
                //error handling
                Console.WriteLine("It was an error with the API connection");
            }
            
        }

        /**
         * Select a picture from  the gallery
         * */
        private async void SelectPictureClick()
        {
            var status = await Permissions.RequestAsync<Permissions.Photos>();
            if(status == PermissionStatus.Granted)
            {
                FileResult selectedFile = await MediaPicker.PickPhotoAsync();
                if (selectedFile != null)
                {
                    this.ImageUrl = selectedFile.FullPath;
                }
            }
                
        }

        /**
         * Get the id of the bundle or package name
         * */
        public string GetId()
        {
            try
            {
                return DependencyService.Get<IIdService>().GetId();

            }
            catch (Exception e)
            {
                //error handling, not used yet
                Console.WriteLine("It was an error getting the app id " + e.Message);

                return "";
    
            }
        }
    }


}
