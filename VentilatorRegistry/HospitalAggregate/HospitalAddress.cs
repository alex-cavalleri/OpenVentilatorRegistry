using System;

namespace VentilatorRegistry.HospitalAggregate
{
    public class HospitalAddress
    {
        public virtual int Id { get; protected set; }
        public virtual string StreetAddress { get; protected set; }
        public virtual string City { get; protected set; }
        public virtual string State { get; protected set; }
        public virtual string Country { get; protected set; }

        protected HospitalAddress()
        {

        }

        internal HospitalAddress(string streetAddress, string city, string state, string country) : this()
        {
            if (string.IsNullOrEmpty(streetAddress = streetAddress?.Trim()))
            {
                throw new ArgumentNullException("name cannot be null or empty");
            }

            if (string.IsNullOrEmpty(city = city?.Trim()))
            {
                throw new ArgumentNullException("city cannot be null or empty");
            }

            if (string.IsNullOrEmpty(state = state?.Trim()))
            {
                throw new ArgumentNullException("state cannot be null or empty");
            }

            if (string.IsNullOrEmpty(country = country?.Trim()))
            {
                throw new ArgumentNullException("country cannot be null or empty");
            }

            StreetAddress = streetAddress;
            City = city;
            State = state;
            Country = country;
        }
    }
}