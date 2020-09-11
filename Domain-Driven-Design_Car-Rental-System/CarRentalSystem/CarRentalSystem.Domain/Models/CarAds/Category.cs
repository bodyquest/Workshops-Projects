namespace CarRentalSystem.Domain.Models.CarAds
{
    using CarRentalSystem.Domain.Common;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Category: Entity<int>
    {
        internal Category(string name, string description)
        {
            this.Validate(name, description);

            this.Name = name;
            this.Description = description;
        }

        public string Name { get; }

        public string Description { get; }

        private void Validate(string name, string description)
        {
            throw new NotImplementedException();
        }
    }
}
