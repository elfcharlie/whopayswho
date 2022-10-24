using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GroupValues : MonoBehaviour
{
    public string name;
    private TextMeshProUGUI groupText;
    private TouchScreenKeyboard keyboard;
    private Controller controller;

    void Start()
    {
        groupText = GameObject.FindWithTag("GroupText").GetComponent<TextMeshProUGUI>();
        controller = GameObject.FindWithTag("Controller").GetComponent<Controller>();

    }

    void Update()
    {
        
        // Update group name with keyboard input
        if (keyboard != null && keyboard.active)
        {
            groupText.text = keyboard.text;
            name = groupText.text;
        }
    }

    public void EditGroupName()
    {
        keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
    }
    
    public void GroupButton()
    {
        controller.GoToGroup();
    }
}
