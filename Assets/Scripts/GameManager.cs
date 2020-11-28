using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    //public float levelTime = 120.0f;
    //public float timeLeft;
    //public Image timeImage;

    public GameObject UI_Loading;
    public GameObject UI_Menu;
    public SaveManager saveManager;
    public STATES currentState;

    List<AsyncOperation> loadOperations = new List<AsyncOperation>();
    string previousSceneName, currentSceneName;

    public enum STATES
    {
        MENU, PLAYING, LOADING
    }
    

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogError("[GameManager] Ya existe una instancia de GameManager y se está intentando crear otra");
        }
    }

    private void Start()
    {
        LoadLevel("MainMenu", true);
        //timeLeft = levelTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentState == STATES.PLAYING && Input.GetKeyDown(KeyCode.Escape))
        {
            if (UI_Menu.activeSelf) DeactivateMenu();
            else ActiveMenu();
        }

        /*
        if (currentSceneName == "SampleScene_Fran" || currentSceneName == "Tutorial")
        {
            timeLeft -= Time.deltaTime;
            timeImage.fillAmount = timeLeft / levelTime;

            if(timeLeft <= 0.0f)
            {
                timeLeft = 0.0f;
                Debug.Log("You Lost");
            }

            if(AssemblingScript.current.recipeComplete)
            {
                Debug.Log("You won");
            }
        }
        */
    }


    public void LoadLevel(string levelName, bool useLoadingScreen)
    {
        currentState = STATES.LOADING;
        AsyncOperation ao = SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Additive);
        if (ao == null)
        {
            Debug.Log("[GameManager] No se puede cargar el nivel");
            return;
        }
        if (useLoadingScreen)
        {
            //Empezar corutina de barra de carga
        }
        UI_Loading.transform.parent.gameObject.SetActive(true);
        UI_Loading.SetActive(true);
        ao.completed += OnLoadOperationComplete;
        loadOperations.Add(ao);
        previousSceneName = currentSceneName;
        currentSceneName = levelName;
        
    }

    void UnloadLevel(string levelName)
    {
        SceneManager.UnloadSceneAsync(levelName);
    }

    void OnLoadOperationComplete (AsyncOperation ao)
    {
        if (loadOperations.Contains(ao))
        {
            loadOperations.Remove(ao);
        }
        UI_Loading.SetActive(false);
        UI_Loading.transform.parent.gameObject.SetActive(false);
        if (previousSceneName != null) UnloadLevel(previousSceneName);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(currentSceneName));

        switch (currentSceneName)
        {
            case "MainMenu":
                currentState = STATES.MENU;
                break;

            default:
                currentState = STATES.PLAYING;
                break;
        }
    }


    public void LoadMainMenu()
    {
        LoadLevel("MainMenu", true);
    }

    public void LoadGame()
    {
        LoadLevel("SampleScene_Fran", true);
    }

    public void LoadTutorial()
    {
        LoadLevel("Tutorial", true);
    }

    public void ActiveMenu()
    {
        UI_Menu.transform.parent.gameObject.SetActive(true);
        UI_Menu.SetActive(true);
    }
    
    public void DeactivateMenu()
    {
        UI_Menu.SetActive(false);
        UI_Menu.transform.parent.gameObject.SetActive(false);
    }
}
