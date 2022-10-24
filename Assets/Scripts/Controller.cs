using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static Transaction;

public class Controller : MonoBehaviour
{
    public GameObject personPrefab;
    public GameObject transactionPrefab;
    public GameObject groupPrefab;
    private int personNumber = 1;
    private Transform personContainer;
    private Transform transactionContainer;
    private Transform groupContainer;
    private Animator addPersonsMenuAnim;
    private Animator calculateMenuAnim;
    private Animator groupMenuAnim;
    private Calculator calculator;
    private List<GameObject> persons = new List<GameObject>();
    private List<GameObject> groups = new List<GameObject>();

    void Start()
    {
        personContainer = GameObject.FindWithTag("PersonContainer").transform;
        transactionContainer = GameObject.FindWithTag("TransactionContainer").transform;
        groupContainer = GameObject.FindWithTag("GroupContainer").transform;
        addPersonsMenuAnim = GameObject.FindWithTag("AddPersonsMenu").GetComponent<Animator>();
        calculateMenuAnim = GameObject.FindWithTag("CalculateMenu").GetComponent<Animator>();
        groupMenuAnim = GameObject.FindWithTag("GroupMenu").GetComponent<Animator>();
        calculator = GameObject.FindWithTag("Calculator").GetComponent<Calculator>();
    }
    public void AddPerson()
    {
        GameObject newPerson = Instantiate(personPrefab, personContainer);
        persons.Add(newPerson);
    }


    public void ShowCalculateScreen()
    {
        addPersonsMenuAnim.SetTrigger("MoveLeft");
        calculateMenuAnim.SetTrigger("MoveLeft");
        ShowTransactions(calculator.GetTransactions());
    }

    public void ShowAddPersonsMenu()
    {
        addPersonsMenuAnim.SetTrigger("MoveRight");
        calculateMenuAnim.SetTrigger("MoveRight");
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
            if(personValues.paidAmount < 0.0f){
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

    public void AddGroup()
    {
        GameObject newGroup = Instantiate(groupPrefab, groupContainer);
        groups.Add(newGroup);
    }   

    public void GoToGroup()
    {
        addPersonsMenuAnim.SetTrigger("MoveLeft");
        groupMenuAnim.SetTrigger("MoveLeft");
    }
    public void GoToGroupMenu()
    {
        addPersonsMenuAnim.SetTrigger("MoveRight");
        groupMenuAnim.SetTrigger("MoveRight");
    }
}