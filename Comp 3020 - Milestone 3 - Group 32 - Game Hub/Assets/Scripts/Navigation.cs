using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Navigation
{
    // RHS Buttons

    // LHS Buttons
    public static void summonWizard()
    {

    }

    public static void openBackpack()
    {

    }


    // Entering a hut
    public static void enterHut(string hutName)
    {
        SceneManager.LoadScene(hutName);
    }
}
