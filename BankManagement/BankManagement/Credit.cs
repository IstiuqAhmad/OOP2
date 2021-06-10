using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagement
{
    class Credit : Account 
    {
        protected int creditAmount = 20000;
        private double remain;

        public int CreditAmount
        {
            get
            {
                return this.creditAmount;
            }
            set
            {
                creditAmount = value;
            }
        }
        public Credit()
        {

        }
        public Credit(string acType, string acName, string acNo)
            : base(acType, acName, acNo)
        {

        }
        public Credit(double balance, double deposit, double remaining, double withdraw, double amount)
            : base(balance, deposit, remaining, withdraw, amount)
        {

        }

        public override void DepositMoney()
        {
            base.Show();
            Console.WriteLine("Enter the amount you want to Deposit:");
            deposit = double.Parse(Console.ReadLine());
            amount = balance + deposit;
            Console.WriteLine("BDT " + deposit + " is deposited in your " + acType + ".Your account balance is {0}", amount);
        }

        public override void WithdrawMoney()
        {

            Console.WriteLine("Enter the amount you want too Withdraw:");
            withdraw = double.Parse(Console.ReadLine());

            if (amount >= withdraw)
            {
                remaining = amount - withdraw;
                Console.WriteLine("Successful transaction of BDT " + withdraw + " by AC no " + acNo + " current balance is BDT {0}", remaining);
            }

            else if (creditAmount > withdraw)
            {
                remain = creditAmount - withdraw;
                Console.WriteLine("Credited " + withdraw + " BDT from your credit Limit.Remaining credit limit is BDT {0}", remain);
            }
            else
            {
                Console.WriteLine("Sorry,your credit limit is over");
            }

        }
    }
}
