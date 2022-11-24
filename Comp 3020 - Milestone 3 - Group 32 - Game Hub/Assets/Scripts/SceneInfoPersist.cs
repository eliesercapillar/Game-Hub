using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SceneInfoPersist
{
    public static void savePlayerLocation(float posX, float posY)
    {
        PlayerPrefs.SetFloat("PlayerPosX", posX);
        PlayerPrefs.SetFloat("PlayerPosY", posY);
    }

    public static float[] loadPlayerLocation()
    {
        float[] coords = new float[2];
        coords[0] = PlayerPrefs.GetFloat("PlayerPosX");
        coords[1] = PlayerPrefs.GetFloat("PlayerPosY");

        return coords;
    }

    public static void saveWizardDialogueState(bool b)
    {
        PlayerPrefs.SetInt("WizardDialogueState", (b ? 1 : 0));
    }

    public static bool loadWizardDialogueState()
    {
        return PlayerPrefs.GetInt("WizardDialogueState") == 1;
    }
}
