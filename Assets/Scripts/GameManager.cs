using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
<<<<<<< Updated upstream
<<<<<<< Updated upstream
    public List<GameObject> PNJList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Instantiate(PNJList[Random.Range(0, PNJList.Count)]);
=======
    public static GameManager current;
=======
    public float levelTime = 120.0f;
    public float timeLeft;
>>>>>>> Stashed changes

    public Text hammerLvlTxt;
    public int hammerLevel;
    private int hammerMaxLevel = 3;

    private void Awake()
    {
        current = this;
>>>>>>> Stashed changes
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

    public void HammerLevelUpdate()
    {
        if(hammerLevel < hammerMaxLevel)
        {
            hammerLevel += 1;
            hammerLvlTxt.text = "Hammer Level : " + hammerLevel;
        }
        else
        {
            Debug.Log("Hammer already at max level");
        }

        if(Input.GetKeyDown(KeyCode.F))
        {
            MoneyCount.current.GiveMoney(Random.Range(70, 151));
        }
    }
}
