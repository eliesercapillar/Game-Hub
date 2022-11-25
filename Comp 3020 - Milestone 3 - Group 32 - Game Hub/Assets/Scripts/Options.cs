using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Options : MonoBehaviour
{
    private Wizard wizard;

    void Awake()
    {
        wizard = GameObject.FindWithTag("Wizard").GetComponent<Wizard>();
    }

    public void Option1()
    {
        wizard.playDialogue(4);
        Debug.Log("Option 1");
    }

    public void Option2()
    {
        wizard.playDialogue(5);
        Debug.Log("Option 2");
    }

    public void Option3()
    {
        wizard.playDialogue(6);
        Debug.Log("Option 3");
    }
}
