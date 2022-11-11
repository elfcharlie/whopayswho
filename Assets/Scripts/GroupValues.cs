using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GroupValues : MonoBehaviour
{
    public string name;
    public GameObject groupTextObject;
    private TextMeshProUGUI groupText;
    private TouchScreenKeyboard keyboard;
    private bool editName = false;
    private Controller controller;
    private List<GameObject> persons = new List<GameObject>();

    void Start()
    {
        groupText = groupTextObject.GetComponent<TextMeshProUGUI>();
        controller = GameObject.FindWithTag("Controller").GetComponent<Controller>();
    }

    void Update()
    {
        // Update group name with keyboard input
        if (keyboard != null && keyboard.active && editName)
        {
            groupText.text = keyboard.text;
            name = groupText.text;
        }
        else if (keyboard != null && !keyboard.active)
        {
            editName = false;
        }
        if (keyboard != null && (keyboard.text == "" || keyboard.text == null) && editName)
        {
            groupText.text = "Group Name";
        }
        Debug.Log(persons.Count);
    }

    public void EditGroupName()
    {
        editName = true;
        keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
    }
    
    public void GroupButton()
    {
        controller.SetActiveGroup(GetComponent<GroupValues>());
        controller.GoToGroup();
    }
    public void DeleteSelf()
    {
        controller.DeleteGroup(gameObject);
        Destroy(gameObject);
    }

    public void AddPersonToGroup(GameObject person)
    {
        persons.Add(person);
    }
    public List<GameObject> GetPersons()
    {
        return persons;
    }
}
