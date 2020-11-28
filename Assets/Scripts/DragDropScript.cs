﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDropScript : MonoBehaviour
{

    //Initialize Variables
    GameObject getTarget;
    public bool isMouseDragging;
    Vector3 offsetValue;
    Vector3 positionOfScreen;

    bool isDragIngredient;

    AudioSource audioSource;

    public bool canDrag = true;

    GameObject spawnedIngredient;

    [SerializeField] AudioClip clipToPlay;

    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {

        //Mouse Button Press Down
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo;
            getTarget = ReturnClickedObject(out hitInfo);
            if (getTarget != null)
            {
                if(getTarget.CompareTag("Hammer") || (getTarget.CompareTag("Product")))
                {
                    isMouseDragging = true;
                    isDragIngredient = true;
                    spawnedIngredient = getTarget;
                    //Converting world position to screen position.
                    positionOfScreen = Camera.main.WorldToScreenPoint(getTarget.transform.position);
                    offsetValue = getTarget.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, positionOfScreen.z));
                }

                if(getTarget.CompareTag("Ingredient"))
                {
                    isMouseDragging = true;
                    isDragIngredient = true;
                    spawnedIngredient = getTarget;
                    
                    clipToPlay = spawnedIngredient.GetComponent<Ingredient>().audioClip;
                    if(clipToPlay != null) { audioSource.PlayOneShot(clipToPlay); }
                    
                    //Converting world position to screen position.
                    positionOfScreen = Camera.main.WorldToScreenPoint(getTarget.transform.position);
                    offsetValue = getTarget.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, positionOfScreen.z));
                }
                else if(getTarget.CompareTag("IngredientSpawner"))
                {
                    isMouseDragging = true;
                    isDragIngredient = true;
                    spawnedIngredient = Instantiate(getTarget.GetComponent<SpawnIngredient>().ingredientToSpawn);
                    
                    clipToPlay = spawnedIngredient.GetComponent<Ingredient>().audioClip;
                    if (clipToPlay != null) { audioSource.PlayOneShot(clipToPlay); }

                    positionOfScreen = Camera.main.WorldToScreenPoint(getTarget.transform.position);
                    offsetValue = getTarget.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, positionOfScreen.z));
                }
            }
        }

        //Mouse Button Up
        if (Input.GetMouseButtonUp(0))
        {
            isMouseDragging = false;
            isDragIngredient = false;
        }

        //Is mouse Moving
        if (isMouseDragging && canDrag)
        {
            if (isDragIngredient) { MouseDrag(spawnedIngredient.transform); }
            
        }
    }

    public void MouseDrag(Transform ingredient)
    {
        //tracking mouse position.
        Vector3 currentScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, positionOfScreen.z);

        //converting screen position to world position with offset changes.
        Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenSpace) + offsetValue;

        //It will update target gameobject's current postion.
        ingredient.transform.position = currentPosition;
        //getTarget.transform.position = currentPosition;
    }

    //Method to Return Clicked Object
    GameObject ReturnClickedObject(out RaycastHit hit)
    {
        GameObject target = null;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray.origin, ray.direction * 10, out hit))
        {
            target = hit.collider.gameObject;
        }
        return target;
    }

}
