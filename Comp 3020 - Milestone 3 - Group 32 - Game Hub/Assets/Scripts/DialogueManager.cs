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

    private GameObject currentDialogue;
    void Awake()
    {
        inHut = DataPersistency.inHut();
        hutIndex = DataPersistency.getHutIndex();
        inGameWorld = !inHut;

        currentDialogue = null;
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

    public GameObject showDialogue(int index)
    {
        if (currentDialogue != null)
        {
            Destroy(currentDialogue);
            currentDialogue = null;
        }

        currentDialogue = Instantiate(dialoguePrefabs[index]);
        currentDialogue.GetComponent<Transform>().SetParent(parent);

        RectTransform dialogueTransform = currentDialogue.GetComponent<RectTransform>();

        dialogueTransform.anchoredPosition = new Vector2(0, 100);

        return currentDialogue;
    }

    private IEnumerator waitOneSecond()
    {
        yield return new WaitForSeconds(1f);
        DataPersistency.setWelcomeFinished(true);
    }
}
