using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErrorMessage : MonoBehaviour
{
    public void SetErrorMessageBoolFalse()
    {
        GetComponent<Animator>().SetBool("ErrorMessage", false);
    }
}
