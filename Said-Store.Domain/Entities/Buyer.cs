using System;
using System.Collections.Generic;

namespace Said_Store.Domain.Entities
{
    public class Buyer
    {
        public int Id { get; private set; }
        public string? Name { get; private set; }
        public string? Email { get; private set; }
        public string? Address { get; private set; }
        public ICollection<Order> Orders { get; private set; }

        public Buyer(string name, string email, string address)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name is required", nameof(name));
            if (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
                throw new ArgumentException("Valid email is required", nameof(email));
            if (string.IsNullOrWhiteSpace(address))
                throw new ArgumentException("Address is required", nameof(address));

            Name = name;
            Email = email;
            Address = address;
            Orders = new List<Order>();
        }

        public void AddOrder(Order order)
        {
            if (order == null) throw new ArgumentNullException(nameof(order));
            Orders.Add(order);
        }

        public void UpdateDetails(string name, string email, string address)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name is required", nameof(name));
            if (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
                throw new ArgumentException("Valid email is required", nameof(email));
            if (string.IsNullOrWhiteSpace(address))
                throw new ArgumentException("Address is required", nameof(address));

            Name = name;
            Email = email;
            Address = address;
        }
    }
}
