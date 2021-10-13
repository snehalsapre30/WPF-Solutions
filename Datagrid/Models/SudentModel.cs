using System;

namespace GitSpecificApp.Models
{
    public class SudentModel : BaseModel
    {
        private string _city;
        private string _name;
        private DateTime _birthDate;

        public string City
        {
            get
            {
                return _city;
            }
            set
            {
                _city = value;
            }
        }

        public DateTime BirthDate
        {
            get
            {
                return _birthDate;
            }
            set
            {
                _birthDate = value;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
    }

}
