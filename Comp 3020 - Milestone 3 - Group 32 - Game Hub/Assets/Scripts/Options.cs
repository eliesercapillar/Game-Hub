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
        wizard.setNextDialogue(4);
        Destroy(this.gameObject);
        Debug.Log("Option 1");
    }

    public void Option2()
    {
        wizard.setNextDialogue(5);
        Destroy(this.gameObject);
        Debug.Log("Option 2");
    }

    public void Option3()
    {
        //wizard.setNextDialogue(6);
        Destroy(this.gameObject);
        Debug.Log("Option 3");
    }

    public void Option4()
    {
        //wizard.setNextDialogue(7);
        Destroy(this.gameObject);
        Debug.Log("Option 4");
    }
}
