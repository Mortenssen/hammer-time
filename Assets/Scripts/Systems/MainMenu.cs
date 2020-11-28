using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button playBtn;
    public Button tutorialBtn;
    void Start()
    {
        tutorialBtn.onClick.AddListener(GameManager.instance.LoadTutorial);
        if (GameManager.instance.saveManager.IsTutorialCompleted())
        {
            playBtn.onClick.AddListener(GameManager.instance.LoadGame);
        }
        else
        {
            playBtn.interactable = false;
        }
        
    }
}
