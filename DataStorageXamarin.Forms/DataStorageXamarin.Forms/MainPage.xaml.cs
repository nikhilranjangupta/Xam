using DataStorageXamarin.Forms.ViewModals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DataStorageXamarin.Forms
{
    public partial class MainPage : ContentPage
    {
        SettingsViewModal viewModal = new SettingsViewModal();
        public MainPage(string dbPath)
        {
            InitializeComponent();
            //BindingContext = viewModal;
            Path.Text = dbPath;
        }

        private async void OnRightButtonClicked(string arg1, string arg2)
        {
            //LoginFormView.IsVisible = true;
            BasicDataStorage.BasicUrl = string.Format("http://{0}:{1}", arg1, arg2);
            string basicurl = BasicDataStorage.BasicUrl;


            if (App.UseAsync)
            {
                //await App.settingsRepository.AddNewSettingsAsync("Ip", arg1);
                // await App.settingsRepository.AddNewSettingsAsync("Port", arg2);

                string status = App.settingsRepository.StatusMessage;
                ActInd.IsVisible = true;
                ActInd.IsRunning = true;
                await Task.Run(async () =>
                {
                    List<SettingsModel> settings = await App.settingsRepository.GetAllSettingsAsync();

                });

                await App.settingsRepository.UpdateSettingsAsync("Ip", "Asdffdgdfhfgcffdf");
                await Task.Run(async () =>
                {
                    List<SettingsModel> settings = await App.settingsRepository.GetAllSettingsAsync();

                });

                await App.settingsRepository.UpdateSettingsAsync("Por34tt", "Asdffdgdfhfgcffdf");
                await Task.Run(async () =>
                {
                    List<SettingsModel> settings = await App.settingsRepository.GetAllSettingsAsync();

                });
            }
            else
            {
                App.settingsRepository.AddNewSettings("Ip", arg1);
                App.settingsRepository.AddNewSettings("Port", arg2);

                string status = App.settingsRepository.StatusMessage;
                List<SettingsModel> settings = App.settingsRepository.GetAllSettings();
            }
        }

        private void OnLeftButtonClicked()
        {
            //LoginFormView.IsVisible = false;
        }

        //private void OnLoginClicked(string arg1, string arg2)
        //{
        //    SettingsFormView.IsVisible = false;
        //}

        //private void OnCancelClicked()
        //{
        //    SettingsFormView.IsVisible = true;
        //}
    }
}
