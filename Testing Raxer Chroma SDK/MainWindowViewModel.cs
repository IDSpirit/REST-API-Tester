using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using Testing_Raxer_Chroma_SDK.Annotations;

namespace Testing_Raxer_Chroma_SDK
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        #region Contructor

        public MainWindowViewModel()
        {
            RequestType = new ObservableCollection<httpVerbObject>()
            {
                new httpVerbObject(httpVerb.GET, "GET"),
                new httpVerbObject(httpVerb.POST, "POST"),
                new httpVerbObject(httpVerb.PUT, "PUT"),
                new httpVerbObject(httpVerb.DELETE, "DELETE")
            };
        }

        #endregion

        #region Event Handlers

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;


        public void OnButtonClickHandler(RoutedEventArgs o)
        {
            AccessRESTAPI(UserTextbox, SelectedRequestType.HttpVerb, POSTTextbox);
        }

        public void OnClearButtonClickHandler(RoutedEventArgs o)
        {
            PrintTextbox = null;
            POSTTextbox = null;

        }

        #endregion

        #region Helper Methods

        private void AccessRESTAPI(string url, httpVerb httpVerb, string postJSON)
        {
            if (UserTextbox != null)
            {
                RESTClient rClient = new RESTClient(url, httpVerb, postJSON);

                PrintTextbox = "RESTClient Object created.";

                PrintTextbox = rClient.makeRequest();
            }
            else
            {
                MessageBox.Show("You forgot to add a url silly", "Error", MessageBoxButton.OKCancel, MessageBoxImage.Error, MessageBoxResult.OK);
            }

        }

        #endregion

        #region Binding Properties

        private string printTextbox = "Awaiting API Call\n";

        public string PrintTextbox
        {
            get
            {
                return printTextbox;
            }
            set
            {
                if (value == null)
                {
                    printTextbox = string.Empty;
                }
                else
                {
                    if (printTextbox == "Cleared\n")
                    {
                        printTextbox = string.Empty;
                    }
                    printTextbox += value + "\n";
                }
                OnPropertyChanged("PrintTextbox");
            }
        }

        private string userTextbox;

        public string UserTextbox
        {
            get
            {
                return userTextbox;
            }
            set
            {
                userTextbox = value;

                OnPropertyChanged("UserTextbox");
            }
        }

        private string pOSTTextbox;

        public string POSTTextbox
        {
            get
            {
                return pOSTTextbox;
            }
            set
            {
                if (value == null)
                {
                    pOSTTextbox = string.Empty;
                }
                else
                {
                    pOSTTextbox = value;
                }
                OnPropertyChanged("POSTTextbox");
            }
        }

        private ObservableCollection<httpVerbObject> requestType;

        public ObservableCollection<httpVerbObject> RequestType
        {
            get
            {
                return requestType;
            }
            set
            {
                requestType = value;
                OnPropertyChanged("RequestType");
            }
        }

        private httpVerbObject selectedRequestType;

        public httpVerbObject SelectedRequestType
        {
            get
            {
                return selectedRequestType;
            }
            set
            {
                if (value.HttpVerb != httpVerb.GET)
                {
                    IsPOSTTxtEnabled = true;
                }
                else
                {
                    IsPOSTTxtEnabled = false;
                }
                selectedRequestType = value;
                IsButtonsEnabled = true;
                OnPropertyChanged("selectedRequestType");
            }
        }

        private bool isPOSTTxtEnabled = false;

        public bool IsPOSTTxtEnabled
        {
            get
            {
                return isPOSTTxtEnabled;
            }
            set
            {
                isPOSTTxtEnabled = value;
                OnPropertyChanged("IsPOSTTxtEnabled");

            }
        }

        private bool isButtonsEnabled = false;

        public bool IsButtonsEnabled
        {
            get
            {
                return isButtonsEnabled;
            }
            set
            {
                isButtonsEnabled = value;
                OnPropertyChanged("IsButtonsEnabled");
            }
        }

        #endregion
    }
}
