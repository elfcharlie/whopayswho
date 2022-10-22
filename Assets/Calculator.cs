using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calculator : MonoBehaviour
{
    private Dictionary<string, float> payments = new Dictionary<string, float>();
    private Dictionary<string, float> balance = new Dictionary<string, float>();
    private float totalSum = 0;
    private GameObject[] persons;

    public void GetAllPayments()
    {
        persons = GameObject.FindGameObjectsWithTag("Person");

        foreach (GameObject person in persons)
        {
            PersonValues personValues = person.GetComponent<PersonValues>();
            payments.Add(personValues.name, personValues.paidAmount);
            totalSum += personValues.paidAmount;
        }
            CalculateBalance();
    }
    public void CalculateBalance()
    {
        foreach (KeyValuePair<string, float> payment in payments)
        {
            balance.Add(payment.Key, totalSum/persons.Length - payment.Value);
            Debug.Log(totalSum/persons.Length - payment.Value);
        }
    }
}
