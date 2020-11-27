using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{

    public Transform startingPosition;

    Animator animator;

    public DragDropScript dragScript;

    public CraftManager craftManager;

    public bool canHammer = true;

    public int hammerLevel = 1;

    // Start is called before the first frame update
    void Start()
    {
        hammerLevel = PlayerPrefs.GetInt("HammerLevel", 1);


        craftManager = GameObject.FindGameObjectWithTag("CraftManager").GetComponent<CraftManager>();
        dragScript = GameObject.FindGameObjectWithTag("GameController").GetComponent<DragDropScript>();
        animator = GetComponent<Animator>();
    }

    public void GoToStartingPosition()
    {
        InvokeRepeating("MoveToStartingPosition", 0f, 2.0f * Time.deltaTime);
    }

    void MoveToStartingPosition()
    {
        Vector3 newPos = transform.position;
        newPos.x = Mathf.Lerp(newPos.x, startingPosition.position.x, 0.25f);
        newPos.y = Mathf.Lerp(newPos.y, startingPosition.position.y, 0.25f);
        newPos.z = Mathf.Lerp(newPos.z, startingPosition.position.z, 0.25f);
        transform.position = newPos;

        if(Vector3.Distance(transform.position, startingPosition.position) < 0.5f)
        {
            CancelInvoke("MoveToStartingPosition");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!canHammer) { return; }

        if(craftManager.recievedRecipeIngredients.Count == 0) { return; }

        if(Input.GetKeyDown(KeyCode.Q))
        {            
            if(craftManager.canCraft)
            {
                animator.enabled = true;
                animator.SetTrigger("L_Hit");
                dragScript.canDrag = false;
                dragScript.isMouseDragging = false;
                craftManager.RecieveHit(hammerLevel, true);
            }            
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (craftManager.canCraft)
            {
                animator.enabled = true;
                animator.SetTrigger("H_Hit");
                dragScript.canDrag = false;
                dragScript.isMouseDragging = false;
                craftManager.RecieveHit(hammerLevel, false);
            }
        }
    }
}
