using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using static Transaction;

public class Calculator : MonoBehaviour
{
    private Dictionary<string, float> payments = new Dictionary<string, float>();
    private Dictionary<string, float> balance = new Dictionary<string, float>();
    private List<Transaction> transactions = new List<Transaction>();
    private float totalSum = 0;
    private GameObject[] persons;

    public void GetAllPayments()
    {
        persons = GameObject.FindGameObjectsWithTag("Person");
        payments.Clear();
        totalSum = 0f;
        foreach (GameObject person in persons)
        {
            PersonValues personValues = person.GetComponent<PersonValues>();
            payments.Add(personValues.name, personValues.paidAmount);
            totalSum += personValues.paidAmount;
        }
    }

    public void CalculateBalance()
    {
        GetAllPayments();
        balance.Clear();
        foreach (KeyValuePair<string, float> payment in payments)
        {
            balance.Add(payment.Key, totalSum/persons.Length - payment.Value);
        }
    }

    public string GetDebtor()
    {
        return balance.Aggregate((x, y) => x.Value > y.Value ? x : y).Key;
    }

    public string GetCreditor(){
        return balance.Aggregate((x, y) => x.Value < y.Value ? x : y).Key;
    }

    public float GetTransferAmount(string debtor, string creditor)
    {
        return Math.Min(balance[debtor], Math.Abs(balance[creditor]));
    }

    public void CalculateTransactions()
    {
        CalculateBalance();
        transactions.Clear();
        int i = 0;
        while (balance.Count > 1 || i > 10)
        {
        string debtor = GetDebtor();
        string creditor = GetCreditor();
        float amount = GetTransferAmount(debtor, creditor);

            transactions.Add(new Transaction(debtor, creditor, amount));

            AdjustBalance(debtor, creditor, amount); // Step 3.

            // Remove the one with zero balance. Step 4.
            if (balance[debtor] == 0)
            {
                balance.Remove(debtor);
            }
            // Step 5.
            if (balance[creditor] == 0)
            {
                balance.Remove(creditor);
            }
                i++;
        }
    }

    public void AdjustBalance(string debtor, string creditor, float amount)
    {
        balance[debtor] -= amount; 
        balance[creditor] += amount;
    }

    public List<Transaction> GetTransactions()
    {
        CalculateTransactions();
        return transactions;
    }
}
