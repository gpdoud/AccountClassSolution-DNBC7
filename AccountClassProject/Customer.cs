using System;
using System.Collections.Generic;
using System.Text;

namespace AccountClassProject {

    public class Customer {

        private static int nextIdNbr = 0;

        public int Id { get; private set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public decimal Sales { get; private set; } = 0;
        public bool Active { get; set; } = true;

        private bool CheckAmountPositive(decimal amount) {
            if(amount < 0) {
                Console.WriteLine("Amount cannot be negative");
                return false;
            }
            return true;
        }

        public decimal AddSales(decimal salesAmount) {
            var valid = CheckAmountPositive(salesAmount);
            if(valid == true) {
                Sales += salesAmount;
            }
            return Sales;
        }
        private void Initialize() {
            this.Id = ++nextIdNbr;
        }

        public Customer(string name, string city, string state) {
            this.Name = name;
            this.State = state;
            this.City = city;
            Initialize();
        }
        public Customer() {
            Initialize();
        }
    }
}
