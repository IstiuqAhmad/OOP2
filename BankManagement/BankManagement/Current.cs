using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagement
{
    class Current : Account
    {
        public Current()
        {

        }
        public Current(string acType, string acName, string acNo)
            : base(acType, acName, acNo)
        {

        }
        public Current(double balance, double deposit, double remaining, double withdraw, double amount)
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
            else
            {
                Console.WriteLine("Sorry,Insufficient Balance");
            }
        }

    }
}
