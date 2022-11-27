using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class sceneloader : MonoBehaviour
{

    private void Awake()
    {
        Screen.SetResolution(1280, 720, true);
    }

    public void loadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        DataPersistency.setHutIndex(-1);
    }
}
