using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransactionButton : MonoBehaviour
{
    private bool isToggled = false;
    private Image image;

    void Start()
    {
        image = GetComponent<Image>();
    }

    public void ToggleTransactionButton()
    {
        if(isToggled)
        {
            isToggled = false;
            image.color = new Color(1, 1, 1, 0.39f);
        }
        else if(!isToggled)
        {
            isToggled = true;
            image.color = new Color(1, 1, 1, 1);
        }
    }
}
