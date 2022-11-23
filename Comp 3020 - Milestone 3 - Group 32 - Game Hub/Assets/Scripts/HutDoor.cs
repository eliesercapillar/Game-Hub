using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HutDoor : MonoBehaviour
{
    [SerializeField] private string hutGenre;
    [SerializeField] private GameObject prompt;

    private bool inTrigger = false;

    void Update()
    {
        if (inTrigger && Input.GetKeyDown(KeyCode.Space))
        {
            Navigation.enterHut(hutGenre);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("IM AT A HUT DOOR");
            prompt.SetActive(true);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            inTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            inTrigger = false;
            prompt.SetActive(false);
        }
    }
}
