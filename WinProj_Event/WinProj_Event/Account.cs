using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WinProj_Event
{
    class Account
    {
        public event EventHandler AccountInDeficit;
        public event EventHandler AccountInCredit;

        private double _balance;

        public void Deposit(double amount) 
        {
            _balance += amount;

            EventHandler handler = AccountInCredit;

            if (handler != null) 
            {
                AccountEventArgs args = new AccountEventArgs(_balance);
                handler(this, args);//this代表這個帳戶產生的資料 arg代表現在存款餘額傳入方法中
            }

        }

        public void Withdraw(double amount) 
        {
            _balance -= amount;

            EventHandler handler = AccountInDeficit;

            if (handler != null)
            {
                AccountEventArgs args = new AccountEventArgs(_balance);
                handler(this, args);//透過account最後金額跟最後存款餘額值傳入方法中
            }
        }
    }

    //Custom event argument Class.
    public class AccountEventArgs : EventArgs
    {
        private double _balance;
        public AccountEventArgs(double b) 
        {
            _balance = b;
        }
        public double Balance 
        {
            get { return _balance; }
        }
    }
}
