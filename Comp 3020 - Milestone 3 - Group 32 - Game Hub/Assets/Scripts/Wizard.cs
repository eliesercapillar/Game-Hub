using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : MonoBehaviour
{
    private DialogueManager dm;
    private Cainos.PixelArtTopDown_Basic.TopDownCharacterController controller;

    private GameObject currentDialogue;

    private int nextDialogue = -1;

    void Awake()
    {
        dm = GameObject.Find("Dialogue Manager").GetComponent<DialogueManager>();
        controller = GameObject.Find("Player").GetComponent<Cainos.PixelArtTopDown_Basic.TopDownCharacterController>();
        controller.enabled = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        nextDialogue = 2;
        currentDialogue = dm.showDialogue(nextDialogue);
    }

    void Update()
    {
        if (currentDialogue == null)
        {
            /*if (nextDialogue == 7)
            {
                controller.enabled = true;
                currentDialogue = dm.showDialogue(nextDialogue);
                Destroy(this.gameObject);
            }

            else*/ if (nextDialogue == 2)
            {
                nextDialogue = 3;
                currentDialogue = dm.showDialogue(nextDialogue);
            }
            else if (nextDialogue == 5)
            {
                currentDialogue = dm.showDialogue(nextDialogue);
                nextDialogue = 6;
            }
            else if (nextDialogue == 7)
            {
                currentDialogue = dm.showDialogue(nextDialogue);
                nextDialogue = 3;
            }
            else
            {
                currentDialogue = dm.showDialogue(nextDialogue) ;
                nextDialogue = 7;
            }
        }
    }

    public void setNextDialogue(int i)
    {
        nextDialogue = i;
    }
}
