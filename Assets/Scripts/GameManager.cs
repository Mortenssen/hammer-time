using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> PNJList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Instantiate(PNJList[Random.Range(0, PNJList.Count)]);
    }

    // Update is called once per frame
    void Update()
    {
        if(AssemblingScript.current.recipeComplete)
        {
            Debug.Log("You won");
        }
        if(Input.GetKey(KeyCode.LeftControl))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        if(Input.GetKeyUp(KeyCode.LeftControl))
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
