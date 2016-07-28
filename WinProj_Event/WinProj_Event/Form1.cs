using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinProj_Event
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Account acc1 = new Account();
            acc1.AccountInCredit += OnAccountInCredit;
            acc1.AccountInDeficit += OnAccountInCredit;

            acc1.Deposit(50);
            acc1.Deposit(70);
            acc1.Withdraw(100);

                //Result
              //Account in credit, new balance NT$50.00
              //Account in credit, new balance NT$120.00
              //Account in credit, new balance NT$20.00
        }

        void OnAccountInCredit(object sender, EventArgs args) 
        {
            AccountEventArgs e = (AccountEventArgs)args;
            double balance = e.Balance;
            Console.WriteLine("Account in credit, new balance {0:c}", balance);
        }
    }    
}
