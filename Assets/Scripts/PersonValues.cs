using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PersonValues : MonoBehaviour
{
    public string name;
    public float paidAmount;
    private TMP_InputField nameInput;
    private TMP_InputField amountInput;
    private Controller controller;
    

    void Start()
    {
        nameInput = gameObject.transform.Find("NameInput").GetComponent<TMP_InputField>();
        amountInput = gameObject.transform.Find("AmountInput").GetComponent<TMP_InputField>();
        controller = GameObject.FindWithTag("Controller").GetComponent<Controller>();
        
    }
    public void ChangeName()
    {
        name = nameInput.text;
    }
    public void ChangeAmount()
    {
        float.TryParse(amountInput.text, out paidAmount);
    }
    public void DeleteSelf()
    {
        controller.DeletePerson(gameObject);
        Destroy(gameObject);
    }

}
