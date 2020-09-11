namespace CarRentalSystem.Domain.Models.Dealers
{
    using CarRentalSystem.Domain.Common;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class PhoneNumber : ValueObject
    {
        internal PhoneNumber(string number)
        {
            this.Validate(number);

            this.Number = number;
        }

        public string Number { get; }

        private void Validate(string number)
        {
            throw new NotImplementedException();
        }
    }
}
