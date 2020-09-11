namespace CarRentalSystem.Domain.Models.Dealers
{
    using CarAds;
    using Common;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Dealer: Entity<int>, IAggregateRoot
    {
        private readonly HashSet<CarAd> carAds;

        public Dealer(string name, string phoneNumber)
        {
            this.Validate(name);

            this.Name = name;
            this.PhoneNumber = phoneNumber;

            this.carAds = new HashSet<CarAd>();
        }

        public string Name { get; }

        public PhoneNumber PhoneNumber { get; }

        public IReadOnlyCollection<CarAd> CarAds => this.carAds.ToList().AsReadOnly();

        public void AddCarAd(CarAd carAd) => this.carAds.Add(carAd);

        private void Validate(string name)
        {
            throw new NotImplementedException();
        }
    }
}
