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
    private List<GameObject> persons = new List<GameObject>();

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
        persons.Add(newPerson);
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
    }

    public void InputDoneButton()
    {
        if(CheckForAtMinimumPersons() && CheckForEmptyInputFields())
        {
            ShowCalculateScreen();
        }
    }

    public void DeletePerson(GameObject person)
    {
        persons.Remove(person);
    }

    public bool CheckForEmptyInputFields()
    {
        foreach(GameObject person in persons)
        {
            PersonValues personValues = person.GetComponent<PersonValues>();
            if(string.IsNullOrWhiteSpace(personValues.name))
            {
                // ADD ERROR MESSAGE
                Debug.Log("Add a name to all persons");
                return false;
            }
            if(personValues.paidAmount <= 0.0f){
                Debug.Log("Add expenses to all persons");
                return false;
            }
        }
        return true;
    }
    public bool CheckForAtMinimumPersons()
    {
        if(persons.Count < 2)
        {
            Debug.Log("Add at least two persons!");
            return false;
        }
        return true;
    }
    
}