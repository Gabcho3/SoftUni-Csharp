﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLoan.Models.Banks
{
    public class BranchBank : Bank
    {
        private const int capacity = 25;

        public BranchBank(string name) 
            : base(name, capacity){}
    }
}
