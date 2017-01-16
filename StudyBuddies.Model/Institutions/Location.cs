using System.IO;

namespace StudyBuddies.Domain.Institutions
{
    public class Location : BaseEntity
    {
        private string _address;
        private string _city;
        private string _country;

        protected Location() { }

        public Location(string address, string city, string country)
        {
            if (address == null || address.Trim().Length == 0)
                throw new InvalidDataException(nameof(address));

            if (city == null || city.Trim().Length == 0)
                throw new InvalidDataException(nameof(city));

            if (country == null || country.Trim().Length == 0)
                throw new InvalidDataException(nameof(country));

            _address = address;
            _city = city;
            _country = country;
        }

        #region Properties

        public virtual string Address => _address;
        public virtual string City => _city;
        public virtual string Country => _country;

        #endregion

        #region Public Methods

        public virtual void SetAddress(string address)
        {
            if (address == null || address.Trim().Length == 0)
                throw new InvalidDataException(nameof(address));

            _address = address;
        }

        public virtual void SetCity(string city)
        {
            if (city == null || city.Trim().Length == 0)
                throw new InvalidDataException(nameof(city));

            _city = city;
        }

        public virtual void SetCountry(string country)
        {
            if (country == null || country.Trim().Length == 0)
                throw new InvalidDataException(nameof(country));

            _country = country;
        }

        #endregion
    }
}
