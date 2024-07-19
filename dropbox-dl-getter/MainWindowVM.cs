using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace dropbox_dl_getter
{
    internal class MainWindowVM : BindableBase
    {
        private string _originalUrl = "";

        public string OriginalUrl {
            get => _originalUrl;
            set
            {
                if (_originalUrl != value)
                {
                    _originalUrl = value;
                    OnPropertyChanged();
                    OnOriginalUrlChanged();
                }
            }
        }

        private string _convertedUrl = "";

        public string ConvertedUrl {
            get => _convertedUrl;
            set
            {
                if (_convertedUrl != value)
                {
                    _convertedUrl = value;
                    OnPropertyChanged();
                }
            }
        }

        public void OnOriginalUrlChanged()
        {
            if (OriginalUrl == "")
            {
                return;
            }

            ConvertedUrl = Regex.Replace(OriginalUrl.Replace("www.dropbox.com", "dl.dropboxusercontent.com"), @"[\?\&]dl=0", "");
        }
    }
}
