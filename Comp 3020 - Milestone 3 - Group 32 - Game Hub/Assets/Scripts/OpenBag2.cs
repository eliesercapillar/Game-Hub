using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenBag2: MonoBehaviour
{
    public void openBag(string priorScene)
    {
        DataPersistency.setPriorBPScene(priorScene);
        SceneManager.LoadScene("Backpack");
    }
}
