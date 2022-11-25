using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class TeleportPlayer : MonoBehaviour
{
    [SerializeField] private TMP_InputField input;

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
            foreach (string name in hutNames)
            {
                if (text == name.ToLower())
                {
                    telePlayer(index);
                    return;
                }
                index++;
            }
        }
    }

    private void telePlayer(int index)
    {
        player.position = hutCoords[index];
    }

    public void cancel()
    {
        wizard.setNextDialogue(7);
        Destroy(this.gameObject);
    }
}
