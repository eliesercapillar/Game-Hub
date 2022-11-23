using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Navigation : MonoBehaviour
{
    // RHS Buttons

    // LHS Buttons
    public void summonWizard()
    {

    }

    public void openBackpack()
    {

    }

    public void logout()
    {

    }

    // Entering a hut
    public static void enterHut(string hutName)
    {
        SceneManager.LoadScene(hutName);
    }
}
