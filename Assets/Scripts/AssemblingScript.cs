using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssemblingScript : MonoBehaviour
{
    //If ingredients are in, it becomes true
    //bool ingredient1 = false;
    //bool ingredient2 = false;
    //bool ingredient3 = false;

    GameObject ingredient1Object = null;
    GameObject ingredient2Object = null;
    GameObject ingredient3Object = null;

    CraftManager craftManager = null;

    public GameObject finalObject;

    public bool recipeComplete;

    public static AssemblingScript current = null;

    [SerializeField] List<Ingredient> recipeIngredients = new List<Ingredient>();


    private void Awake()
    {
        current = this;
    }

    private void Start()
    {
        craftManager = GetComponent<CraftManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //if(ingredient1 && ingredient2 && ingredient3)
        //{
            if(!recipeComplete && recipeIngredients.Count > 1)
            {
                //StartCoroutine(Assembling());
                craftManager.RecipeIngredients(recipeIngredients);
            }
        //}
    }
    private void OnTriggerStay(Collider other)
    {
        /*if(other.gameObject.layer == 8 && !ingredient1)
        {
            ingredient1 = true;
            ingredient1Object = other.gameObject;
            recipeIngredients.Add(ingredient1Object.GetComponent<Ingredient>());
            Debug.Log("1In");
        }     
        if(other.gameObject.layer == 9 && !ingredient2)
        {
            ingredient2 = true;
            ingredient2Object = other.gameObject;
            recipeIngredients.Add(ingredient2Object.GetComponent<Ingredient>());
            Debug.Log("2In");
        }     
        if(other.gameObject.layer == 10 && !ingredient3)
        {
            ingredient3 = true;
            ingredient3Object = other.gameObject;
            recipeIngredients.Add(ingredient3Object.GetComponent<Ingredient>());
            Debug.Log("3In");
        }*/
    }

    public void OnTriggerEnter(Collider other)
    {
        Ingredient component;
        if (other.TryGetComponent<Ingredient>(out component))
        {
            recipeIngredients.Add(component);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        Ingredient component;
        if (other.TryGetComponent<Ingredient>(out component))
        {
            recipeIngredients.Remove(component);
        }

    }

    IEnumerator Assembling()
    {
        recipeComplete = true;
        yield return new WaitForSeconds(2);
        Destroy(ingredient1Object);
        Destroy(ingredient2Object);
        Destroy(ingredient3Object);
        yield return new WaitForSeconds(1);
        Instantiate(finalObject);
        StopCoroutine(Assembling());
    }
}
