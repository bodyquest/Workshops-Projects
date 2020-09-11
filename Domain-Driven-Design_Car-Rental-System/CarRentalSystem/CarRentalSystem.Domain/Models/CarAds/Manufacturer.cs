namespace CarRentalSystem.Domain.Models.CarAds
{
    using Common;
    using System;

    public class Manufacturer : Entity<int>
    {
        internal Manufacturer(string name)
        {
            this.Validate(name);

            this.Name = name;
        }

        public string Name { get; }

        public void Validate (string name)
        {

            throw new NotImplementedException();
        }
    }
}
