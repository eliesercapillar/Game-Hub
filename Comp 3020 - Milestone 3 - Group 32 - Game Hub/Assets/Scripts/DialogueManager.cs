using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private GameObject[] dialoguePrefabs;
    [SerializeField] private Transform parent;

    private bool inGameWorld;
    private bool inHut;
    private int hutIndex;
    
    void Awake()
    {
        inHut = DataPersistency.inHut();
        hutIndex = DataPersistency.getHutIndex();

        inGameWorld = !inHut;
    }

    void Start()
    {
        inHut = DataPersistency.inHut();
        hutIndex = DataPersistency.getHutIndex();
        inGameWorld = !inHut;

        if (inGameWorld && !DataPersistency.isWelcomeFinished())
        {
            showDialogue(0);
            StartCoroutine(waitOneSecond());
        }
        else if (inHut)
        {
            showDialogue(hutIndex);
        }
    }

    private void showDialogue(int index)
    {
        GameObject dialogue = Instantiate(dialoguePrefabs[index]);
        dialogue.GetComponent<Transform>().SetParent(parent);

        RectTransform dialogueTransform = dialogue.GetComponent<RectTransform>();

        dialogueTransform.anchoredPosition = new Vector2(0, 100);
    }

    private IEnumerator waitOneSecond()
    {
        yield return new WaitForSeconds(1f);
        DataPersistency.setWelcomeFinished(true);
    }
}
