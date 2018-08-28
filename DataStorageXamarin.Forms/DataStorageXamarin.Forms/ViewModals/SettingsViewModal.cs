using System;
using System.Collections.Generic;
using System.Text;

namespace DataStorageXamarin.Forms.ViewModals
{
    public class SettingsViewModal : BaseViewModal
    {
        string ip="";
        string port="";
        readonly string baseurl = "http://{0}:{1}";
        string enteredUrl;

        public string EnteredUrl
        {
            get => enteredUrl;

            set
            {
                SetProperty(ref enteredUrl, value);
            }
        }
        public string Ip
        {
            get => ip;
            set
            {
                SetProperty(ref ip, value);
                EnteredUrl = string.Format(baseurl, ip, "");
            }
        }
        public string Port
        {
            get => port;
            set
            {
                SetProperty(ref port, value);
                EnteredUrl = string.Format(baseurl, Ip,port);
            }
        }

        public SettingsViewModal()
        {

        }
    }
}
