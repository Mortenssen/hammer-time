using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(AssemblingScript.current.recipeComplete)
        {
            Debug.Log("You won");
        }
    }
}
