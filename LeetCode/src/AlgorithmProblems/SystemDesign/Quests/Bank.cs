using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmProblems.SystemDesign.Quests
{
    /// <summary>
    ///     Q1. Simple Bank System
    ///     <see cref="https://leetcode.com/problems/simple-bank-system/?envType=problem-list-v2&envId=ssd-ssd4-business-system-simulation"/>
    /// </summary>
    public class Bank
    {
        private readonly long[] _balance;
        public Bank(long[] balance)
        {
            _balance = balance;
        }

        public bool Transfer(int account1, int account2, long money)
        {
            if (account1 > _balance.Length || account2 > _balance.Length)
                return false;

            if (_balance[account1 - 1] < money)
                return false;

            _balance[account1 - 1] -= money;
            _balance[account2 - 1] += money;

            return true;
        }

        public bool Deposit(int account, long money)
        {
            if (account > _balance.Length)
                return false;
            
            _balance[account - 1] += money;
            return true;
        }

        public bool Withdraw(int account, long money)
        {
            if (account > _balance.Length || _balance[account - 1] < money)
                return false;
            
            _balance[account - 1] -= money;

            return true;
        }
    }
}
