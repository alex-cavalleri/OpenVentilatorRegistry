using System;

namespace VentilatorRegistry.HospitalAggregate
{
    public class Hospital
    {
        public virtual int Id { get; protected set; }
        public virtual string Name { get; protected set; }
        public virtual int NationalProviderIdentifier { get; protected set; }
        public virtual HospitalAddress Address { get; protected set; }
        public virtual HospitalOrganization Organization { get; protected set; }
        public virtual bool IsVerified { get; protected set; }

        protected Hospital()
        {
            IsVerified = false;
        }

        internal Hospital(HospitalOrganization organization, string name, int nationalProviderIdentifier, string streetAddress, string city, string state, string country) : this()
        {
            if (string.IsNullOrEmpty(name = name?.Trim()))
            {
                throw new ArgumentNullException("name cannot be null or empty");
            }
            //Hospital owns HospitalAddress so it should be hospital's responsability to create a hospitalAdd
            Address = new HospitalAddress(streetAddress, city, state, country);
            Organization = organization;
            NationalProviderIdentifier = nationalProviderIdentifier;
            Name = name;
        }
    }
}
