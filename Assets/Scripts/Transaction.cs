using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transaction
{
    public string debtor;
    public string creditor;
    public float amount;
    public Transaction(string _debtor, string _creditor, float _amount)
    {
        this.debtor = _debtor;
        this.creditor = _creditor;
        this.amount = _amount;
    }
}
