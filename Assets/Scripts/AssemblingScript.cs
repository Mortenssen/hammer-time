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
        if(!recipeComplete && recipeIngredients.Count > 1)
        {
            //StartCoroutine(Assembling());
            craftManager.RecipeIngredients(recipeIngredients);
        }
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
