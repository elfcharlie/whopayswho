using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static Transaction;

public class Controller : MonoBehaviour
{
    public GameObject personPrefab;
    public GameObject transactionPrefab;
    private int personNumber = 1;
    private Transform personContainer;
    private Transform transactionContainer;
    private Animator addPersonsMenuAnim;
    private Animator calculateMenuAnim;
    private Calculator calculator;

    void Start()
    {
        personContainer = GameObject.FindWithTag("PersonContainer").transform;
        transactionContainer = GameObject.FindWithTag("TransactionContainer").transform;
        addPersonsMenuAnim = GameObject.FindWithTag("AddPersonsMenu").GetComponent<Animator>();
        calculateMenuAnim = GameObject.FindWithTag("CalculateMenu").GetComponent<Animator>();
        calculator = GameObject.FindWithTag("Calculator").GetComponent<Calculator>();
    }
    public void AddPerson()
    {
        GameObject newPerson = Instantiate(personPrefab, personContainer);
        GameObject[] persons = GameObject.FindGameObjectsWithTag("Person");
    }


    public void ShowCalculateScreen()
    {
        addPersonsMenuAnim.SetTrigger("HideAddPersonsMenu");
        calculateMenuAnim.SetTrigger("ShowCalculateMenu");
        ShowTransactions(calculator.GetTransactions());
    }

    public void ShowAddPersonsMenu()
    {
        addPersonsMenuAnim.SetTrigger("ShowAddPersonsMenu");
        calculateMenuAnim.SetTrigger("HideCalculateMenu");
    }

    public void ShowTransactions(List<Transaction> transactions)
    {
        foreach (Transaction transaction in transactions)
        {
            GameObject newTransaction = Instantiate(transactionPrefab, transactionContainer);
            TextMeshProUGUI transactionText = newTransaction.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            transactionText.SetText(transaction.debtor + " -> " + transaction.creditor + " " + transaction.amount);
        }
    }
}