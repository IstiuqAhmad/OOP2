using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagement
{
    abstract class Account
    {
        protected string acType;
        protected string acName;
        protected string acNo;
        protected double balance=0;
        protected double deposit;
        protected double remaining;
        protected double withdraw;
        protected double amount;

        public string AcType
        {
            get
            {
                return this.acType;
            }
            set
            {
                acType = value;
            }
        }

        public string Acname
        {
            get
            {
                return this.acName;
            }
            set
            {
                acName = value;
            }
        }

        public string AcNo
        {
            get
            {
                return this.acNo;
            }
            set
            {
                acNo = value;
            }
        }

        public Account()
        {

        }

        public Account(string acType,string acName,string acNo)
        {
            this.acType = acType;
            this.acName = acName;
            this.acNo = acNo;
            
        }
        public Account(double balance,double deposit,double remaining,double withdraw,double amount)
        {
           
            this.balance = balance;
            this.deposit = deposit;
            this.remaining = remaining;
            this.withdraw = withdraw;
            this.amount = amount;

        }
        public abstract void DepositMoney();

        public abstract void WithdrawMoney();
   
        public void Show()
        {
            Console.WriteLine("Account Type: " + this.acType);
            Console.WriteLine("Account Holder: " + this.acName);
            Console.WriteLine("Account NO: " + this.acNo);
           
        }

       
    }  

}
