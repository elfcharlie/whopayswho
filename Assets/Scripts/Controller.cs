using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public GameObject personPrefab;
    private int personNumber = 1;
    private Transform personContainer;
    private Animator addPersonsMenuAnim;
    private Animator calculateMenuAnim;

    void Start()
    {
        personContainer = GameObject.FindWithTag("PersonContainer").transform;
        addPersonsMenuAnim = GameObject.FindWithTag("AddPersonsMenu").GetComponent<Animator>();
        calculateMenuAnim = GameObject.FindWithTag("CalculateMenu").GetComponent<Animator>();
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
    }

    public void ShowAddPersonsMenu()
    {
        addPersonsMenuAnim.SetTrigger("ShowAddPersonsMenu");
        calculateMenuAnim.SetTrigger("HideCalculateMenu");
    }
}