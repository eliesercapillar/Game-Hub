using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDialogue : MonoBehaviour
{
    public Wizard wiz;
    public GameObject parent;

    public void pressBtn()
    {
        wiz = GameObject.FindGameObjectWithTag("Wizard").GetComponent<Wizard>();
        wiz.setNextDialogue(-1);

        Destroy(parent);
    }
}
