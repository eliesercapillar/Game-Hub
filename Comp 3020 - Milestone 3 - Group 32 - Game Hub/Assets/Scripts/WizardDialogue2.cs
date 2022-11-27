using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class WizardDialogue2 : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textComponent;
    [SerializeField] private string[] lines;
    [SerializeField] private float textSpeed;

    private Cainos.PixelArtTopDown_Basic.TopDownCharacterController controller;

    private int index;
    private void Awake()
    {
        controller = GameObject.Find("Player").GetComponent<Cainos.PixelArtTopDown_Basic.TopDownCharacterController>();
    }
    void Start()
    {
        textComponent.text = "";
        StartWelcomeDialogue();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            this.gameObject.SetActive(false);
        }

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
            SceneManager.LoadScene("Wizard Search");
            controller.recordPlayerCoords();
            Destroy(this.gameObject);
        }
    }
}
