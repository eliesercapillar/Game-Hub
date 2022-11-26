using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class TeleportPlayer : MonoBehaviour
{
    [SerializeField] private TMP_InputField input;
    [SerializeField] private Image img;

    private Wizard wizard;
    private Transform player;

    private string[] hutNames = {"Arcade", "Build", "RPG", "FPS", "MOBA", "RTS", "Puzzle", "Racing", "Sports", "VR"};
    private Vector3[] hutCoords = {new Vector3(-9, 1, 0), new Vector3(9, 1, 0), new Vector3(-19, -10, 0),
                                   new Vector3(-5, -10, 0), new Vector3(5, -10, 0), new Vector3(19, -10, 0),
                                   new Vector3(-20, -21, 0), new Vector3(-6, -21, 0), new Vector3(8, -21, 0),
                                   new Vector3(18, -21, 0)};

    void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
        wizard = GameObject.FindGameObjectWithTag("Wizard").GetComponent<Wizard>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            string text = input.text;
            int index = 0;
            Debug.Log("Checking for hut: " + text);
            foreach (string name in hutNames)
            {
                Debug.Log("Comparing: " + text + " to: " + name.ToLower());
                if (text.ToLower() == name.ToLower())
                {
                    telePlayer(index);
                    return;
                }
                index++;
            }
            StartCoroutine(displayRed());
        }
    }

    private IEnumerator displayRed()
    {
        img.color = Color.red;
        yield return new WaitForSeconds(0.5f);
        img.color = Color.white;
    }

    private void telePlayer(int index)
    {
        Debug.Log("Teleporting Player");
        player.position = hutCoords[index];
        wizard.setNextDialogue(7);
        Destroy(this.gameObject);
    }

    public void cancel()
    {
        wizard.setNextDialogue(8);
        Destroy(this.gameObject);
    }
}
