using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace HelloWorld.Models
{
    class User : IDataErrorInfo, INotifyPropertyChanged
    {
        private string name = string.Empty;
        private string password = string.Empty;
        private string nameError;
        private string passwordError;

        public override string ToString()
        {
            return name;
        }

        // This represents the error string for a uxName data validation.  This string
        // is provided via the IDataErrorInfo interface and will be either:
        //     "Name cannot be empty." or
        //     "Name cannot be longer than 12 characters.".
        public string NameError
        {
            get
            {
                return nameError;
            }
            set
            {
                if (nameError != value)
                {
                    nameError = value;
                    OnPropertyChanged("NameError");
                }
            }
        }

        public string PasswordError
        {
            get
            {
                return passwordError;
            }
            set
            {
                if (passwordError != value)
                {
                    passwordError = value;
                    OnPropertyChanged("PasswordError");
                }
            }
        }

        // Getter and setter for the User.cs name field.
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        // Getter and setter for the User.cs password field.
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                if (password != value)
                {
                    password = value;
                    OnPropertyChanged("Password");
                }
            }
        }

        // IDataErrorInfo interface
        public string Error
        {
            get
            {
                // return NameError;
                return null;
            }
        }

        // This serves as our data validation event.  It is called when
        // ValidatesOnDataErrors=True in MainWindow.xaml is set.
        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case "Name":
                    {
                        NameError = "";
                        if (string.IsNullOrEmpty(Name))
                        {
                            NameError = "Name cannot be empty.";
                        }
                        if (Name.Length > 12)
                        {
                            NameError = "Name cannot be longer than 12 characters.";
                        }
                        return NameError;
                    }
                    case "Password":
                    {
                        PasswordError = "";
                        if (string.IsNullOrEmpty(Password))
                        {
                            PasswordError = "Password cannot be empty.";
                        }
                        return PasswordError;
                    }
                }
                return null;
            }
        }

        // INotifyPropertyChanged interface.
        public event PropertyChangedEventHandler PropertyChanged;

        // This triggers the above IDataErrorInfo interface data validations to occur.  It
        // occurs when a property value changes.  The event is processed in XAML, which updates
        // any fields that is bound to it, such as NameError. 
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
