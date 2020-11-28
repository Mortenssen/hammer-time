using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{

    public void LoadGame()
    {
        
    }
    public void SaveGame()
    {
        //Guardar oro
        //Guardar nivel máximo alcanzado
    }

    public void TutorialCompleted()
    {
        PlayerPrefs.SetInt("TutorialCompleted", 1);
    }

    public bool IsTutorialCompleted()
    {
        if(PlayerPrefs.HasKey("TutorialCompleted"))
        {
            int tutorialCompleted = PlayerPrefs.GetInt("TutorialCompleted");
            if (tutorialCompleted == 1)
            {
                return true;
            }
        }
        return false;
    }
}
