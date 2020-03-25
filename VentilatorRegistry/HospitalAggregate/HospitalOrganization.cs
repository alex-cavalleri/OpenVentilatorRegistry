using System;
using System.Collections.Generic;

namespace VentilatorRegistry.HospitalAggregate
{
    public class HospitalOrganization
    {
        public virtual int Id { get; protected set; }
        public virtual string Name { get; protected set; }
        private List<Hospital> _Hospitals { get; set; }
        public virtual IReadOnlyCollection<Hospital> Hospitals => _Hospitals.AsReadOnly();

        protected HospitalOrganization()
        {
            _Hospitals = new List<Hospital>();
        }

        public HospitalOrganization(string name) : this()
        {
            if (string.IsNullOrEmpty(name = name?.Trim()))
            {
                throw new ArgumentNullException("name cannot be null or empty");
            }

            Name = name;
        }

        public virtual Hospital AddHospital(string name, int nationalProviderIdentifier, string streetAddress, string city, string state, string country)
        {
            var hospital = new Hospital(this, name, nationalProviderIdentifier, streetAddress, city, state, country);
            _Hospitals.Add(hospital);
            return hospital;
        }

        public virtual void SetId(int id)
        {
            if (Id != default)
            {
                throw new InvalidOperationException("id already set");
            }

            Id = id;
        }
    }
}