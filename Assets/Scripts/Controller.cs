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
        DestroyOldTransactions();
    }

    public void ShowTransactions(List<Transaction> transactions)
    {
        DestroyOldTransactions();
        foreach (Transaction transaction in transactions)
        {
            GameObject newTransaction = Instantiate(transactionPrefab, transactionContainer);
            TextMeshProUGUI transactionText = newTransaction.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            transactionText.SetText(transaction.debtor + " -> " + transaction.creditor + " " + transaction.amount);
        }
    }

    public void DestroyOldTransactions()
    {
        List<GameObject> transactionObjects = new List<GameObject>();
        foreach(Transform transaction in transactionContainer)
        {
            transactionObjects.Add(transaction.gameObject);
        }

        for(int i = transactionObjects.Count - 1 ; i >= 0; i--)
        {
            Destroy(transactionObjects[i]);
        }
        /*
        if(transactionContainer.transform.childCount > 0){
            for (int i = 0; i <= transactionContainer.transform.childCount; i++)
            {
                Destroy(transactionContainer.transform.GetChild(0).gameObject);
                Debug.Log(transactionContainer.transform.childCount);
            }
        }*/
    }
}