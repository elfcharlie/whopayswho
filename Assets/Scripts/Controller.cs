using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public GameObject personPrefab;
    private int personNumber = 1;
    private Transform personContainer;

    void Start()
    {
        personContainer = GameObject.FindWithTag("PersonContainer").transform;
    }
    public void AddPerson()
    {
        GameObject newPerson = Instantiate(personPrefab, personContainer);
        GameObject[] persons = GameObject.FindGameObjectsWithTag("Person");
    }

    private void findPosition()
    {
        
    }
}