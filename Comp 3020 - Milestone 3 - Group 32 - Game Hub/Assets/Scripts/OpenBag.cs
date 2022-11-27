using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenBag : MonoBehaviour
{
    [SerializeField] private Cainos.PixelArtTopDown_Basic.TopDownCharacterController controller;

    public void openBag()
    {
        DataPersistency.setPriorBPScene("Game World");
        controller.recordPlayerCoords();
        SceneManager.LoadScene("Backpack");
    }
}
