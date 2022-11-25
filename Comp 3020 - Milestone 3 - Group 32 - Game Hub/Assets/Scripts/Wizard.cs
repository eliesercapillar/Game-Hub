using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : MonoBehaviour
{
    private DialogueManager dm;
    private Cainos.PixelArtTopDown_Basic.TopDownCharacterController controller;

    private GameObject currentDialogue;

    private bool allDialoguesFinished = false;
    private bool playingOptions = false;

    void Awake()
    {
        dm = GameObject.Find("Dialogue Manager").GetComponent<DialogueManager>();
        controller = GameObject.Find("Player").GetComponent<Cainos.PixelArtTopDown_Basic.TopDownCharacterController>();
        controller.enabled = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        currentDialogue = dm.showDialogue(2);
        StartCoroutine(startChatting());
    }

    // Update is called once per frame
    void Update()
    {
        if (allDialoguesFinished)
        {
            controller.enabled = true;
            currentDialogue = dm.showDialogue(3); //Play cya dialogue
            Destroy(this.gameObject);
        }
    }

    private IEnumerator startChatting()
    {
        while (!allDialoguesFinished)
        {
            if (currentDialogue == null && !playingOptions)
            {
                playingOptions = true;
                dm.showDialogue(3);
            }

            yield return null;
        }
    }

    public void playDialogue(int i)
    {
        dm.showDialogue(i);
    }
}
