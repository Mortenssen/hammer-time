using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public float levelTime = 120.0f;
    public float timeLeft;

    public Image timeImage;

    private void Start()
    {
        timeLeft = levelTime;
    }

    // Update is called once per frame
    void Update()
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
}
