using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wizard : MonoBehaviour
{
    private DialogueManager dm;
    private Cainos.PixelArtTopDown_Basic.TopDownCharacterController controller;
    private Button btn;

    private GameObject currentDialogue;

    public int nextDialogue = -1;

    void Awake()
    {
        dm = GameObject.Find("Dialogue Manager").GetComponent<DialogueManager>();
        controller = GameObject.Find("Player").GetComponent<Cainos.PixelArtTopDown_Basic.TopDownCharacterController>();
        controller.enabled = false;
        btn = GameObject.FindGameObjectWithTag("summonWizardBtn").GetComponent<Button>();
        btn.interactable = false;
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
            if (nextDialogue == 7 || nextDialogue == -1)
            {
                controller.isMovable(true);
                controller.enabled = true;
                btn.interactable = true;
                if (nextDialogue == 7)
                {
                    currentDialogue = dm.showDialogue(nextDialogue);
                }
                Destroy(this.gameObject);
            }
            else if (nextDialogue == 2)
            {
                nextDialogue = 3;
                currentDialogue = dm.showDialogue(nextDialogue);
            }
            else if (nextDialogue == 5)
            {
                currentDialogue = dm.showDialogue(nextDialogue);
                nextDialogue = 6;
            }
            else if (nextDialogue == 8)
            {
                currentDialogue = dm.showDialogue(nextDialogue);
                nextDialogue = 3;
            }
            else
            {
                currentDialogue = dm.showDialogue(nextDialogue) ;
                nextDialogue = 8;
            }
        }
    }

    public void setNextDialogue(int i)
    {
        nextDialogue = i;
    }
}
