using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonValues : MonoBehaviour
{
    public string name;
    public float paidAmount;

    public void ChangeName()
    {
        name = this.text;
        Debug.Log(name);
    }
}
