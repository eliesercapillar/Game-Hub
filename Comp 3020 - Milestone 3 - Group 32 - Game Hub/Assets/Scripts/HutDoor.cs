using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HutDoor : MonoBehaviour
{
    [SerializeField] private string hutGenre;
    [SerializeField] private GameObject prompt;
    [SerializeField] private Cainos.PixelArtTopDown_Basic.TopDownCharacterController controller;
    [SerializeField] private int hutIndex;

    private AudioSource audio;

    private bool inTrigger = false;

    private void Awake()
    {
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (inTrigger && Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(waitForAnim());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            inTrigger = true;
            prompt.SetActive(true);
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

    private IEnumerator waitForAnim()
    {
        audio.Play();
        yield return new WaitForSeconds(0.65f);
        controller.recordPlayerCoords();
        DataPersistency.setHutIndex(hutIndex);
        Navigation.enterHut(hutGenre);
    }
}
