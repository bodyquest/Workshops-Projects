namespace CarRentalSystem.Domain.Models.CarAds
{
    using Common;
    using System;

    public class CarAd : Entity<int>, IAggregateRoot
    {
        public CarAd(
            Manufacturer manufacturer,
            Category category,
            Options options,
            string model,
            string imageUrl,
            decimal pricePerDay,
            bool isAvailable)
        {
            this.Validate(model, imageUrl, pricePerDay);

            this.Manufacturer = manufacturer;
            this.Category = category;
            this.Options = options;
            this.Model = model;
            this.ImageUrl = imageUrl;
            this.PricePerDay = pricePerDay;

            this.isAvailable = isAvailable;
        }

        public Manufacturer Manufacturer { get; }

        public Category Category { get; }

        public Options Options { get; }

        public string Model { get; }

        public string ImageUrl { get; }

        public decimal PricePerDay { get; }

        public bool isAvailable { get; private set; }

        private void Validate(string model, string imageUrl, decimal pricePerDay)
        {
            throw new NotImplementedException();
        }
    }
}
