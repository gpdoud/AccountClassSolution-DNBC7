﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AccountClassProject {

    public class Account {

        private static int nextAccountNbr = 0;
        public int AccountNumber { get; private set; }
        private decimal Balance { get; set; } = 0.0m;
        public string Description { get; set; }
        public Customer CustomerInstance { get; set; } = null;

        public string Print() {
            return $"{this.GetType().Name} Nbr: {AccountNumber}, Desc: {Description}, Bal: {GetBalance().ToString("C")}";
        }

        public void Transfer(Account acct, decimal amount) {
            var withdrawSuccessful = this.Withdraw(amount);
            if(withdrawSuccessful) {
                acct.Deposit(amount);
            }
        }
        public Account(Customer customer) : this() {
            this.CustomerInstance = customer;
        }
        private Account() {
            AccountNumber = ++nextAccountNbr;
        }
        public Account(string Description, Customer customer) : this() {
            this.Description = Description;
            this.CustomerInstance = customer;
        }
        public decimal GetBalance() {
            return Balance;
        }
        private bool CheckAmountIsPositive(decimal amount) {
            if(amount < 0) {
                Console.WriteLine("Amount cannot be negative.");
                return false;
            }
            return true;
        }
        public bool Deposit(decimal Amount) {
            var valid = CheckAmountIsPositive(Amount);
            if(valid == true) {
                Balance += Amount;
                return true;
            }
            return false;
        }
        public bool Withdraw(decimal Amount) {
            var valid = CheckAmountIsPositive(Amount);
            if(valid == true) {
                if(Amount > Balance) {
                    Console.WriteLine("Insufficient funds!");
                } else {
                    Balance -= Amount;
                    return true;
                }
            }
            return false;
        }
    }
}
