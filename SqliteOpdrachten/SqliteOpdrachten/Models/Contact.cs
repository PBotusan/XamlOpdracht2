using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SqliteOpdrachten.Models
{
   public class Contact : INotifyPropertyChanged
    {
        private string _firstName;
        private string _lastName;
        private string _phone;
        private string _email;


        public int Id { get; set;}
        public string FirstName
        {
            get { return _firstName; }

            set
            {
                if (_firstName == value)
                    return;

                _firstName = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FirstName)));
            }

        }

        public string LastName
        {
            get { return _lastName; }

            set
            {
                if (_lastName == value)
                    return;

                _lastName = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LastName)));
            }

        }


        public string Phone
        {
            get { return _phone; }

            set
            {
                if (_phone == value)
                    return;

                _phone = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Phone)));
            }
        }


        public string Email
        {
            get { return _email; }

            set
            {
                if (_email == value)
                    return;

                _email = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Email)));
            }
        }

        public bool IsBlocked { get; set; }

        public string FullName
        {
            get { return $"{FirstName} {LastName}"; }
        }

        
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
