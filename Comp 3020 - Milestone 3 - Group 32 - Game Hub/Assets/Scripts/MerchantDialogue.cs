using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MerchantDialogue : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textComponent;
    [SerializeField] private string[] lines;
    [SerializeField] private float textSpeed;
    [SerializeField] private sceneloader sl;

    [SerializeField] private string destination;

    private int index;
    void Start()
    {
        textComponent.text = "";
        StartWelcomeDialogue();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    private void StartWelcomeDialogue()
    {
        index = 0;
        StartCoroutine(DisplayLine());
    }

    private IEnumerator DisplayLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    private void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = "";
            StartCoroutine(DisplayLine());
        }
        else
        {
            sl.loadScene(destination);
            //Destroy(this.gameObject);
        }
    }
}

