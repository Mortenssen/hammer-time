using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftManager : MonoBehaviour
{
    public static CraftManager current = null;

    public List<Recipe> currentRecipe = new List<Recipe>();
    public List<Recipe> recipes = new List<Recipe>();

    public List<string> currentRecipeIngredients = new List<string>();
    public List<Ingredient> recievedRecipeIngredients = new List<Ingredient>();

    public bool canCraft = false;
    private int nbOfHit = 0;

    private void Awake()
    {
        current = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        int recipeNumber = Random.Range(0, recipes.Count);
        currentRecipe.Add(recipes[recipeNumber]);
        recipes.Remove(recipes[recipeNumber]);
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< Updated upstream
        
=======
        SetImages();

        if(currentRecipe[0].currentHits >= currentRecipe[0].hitsRequired - MoneyCount.current.hammerLvl)
        {
            Instantiate(currentRecipe[0].modelOutput, productSpawn.position, productSpawn.rotation);
            MoneyCount.current.GiveMoney(Random.Range(70, 151));
            for (int i = 0; i < recievedRecipeIngredients.Count; i++)
            {
                if(recievedRecipeIngredients[i] != null)
                {
                    Destroy(recievedRecipeIngredients[i].gameObject);
                }
                
            }
            recievedRecipeIngredients.Clear();
            if (recievedRecipeIngredients.Count == 0)
            {
                canCraft = false;
                currentRecipe.Remove(currentRecipe[0]);
                if(recipes.Count > 0)
                {
                    currentRecipe.Add(recipes[0]);
                    recipes.Remove(recipes[0]);
                }                
            }
        }
>>>>>>> Stashed changes
    }

    public void RecipeIngredients(List<Ingredient> ingredients)
    {
        currentRecipeIngredients.Clear();

        currentRecipeIngredients.Add(currentRecipe[0].firstIngredientName.ToString());
        currentRecipeIngredients.Add(currentRecipe[0].secondIngredientName.ToString());
        currentRecipeIngredients.Add(currentRecipe[0].thirdIngredientName.ToString());
        currentRecipeIngredients.Add(currentRecipe[0].fourthIngredientName.ToString());


        recievedRecipeIngredients = ingredients;

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            canCraft = CompareToRecipe(recievedRecipeIngredients);

            if (canCraft)
            {
                if (currentRecipe[0].hammerHit == Recipe.HammerHit.LightHit)
                {
                    nbOfHit += 1;
                    if (nbOfHit == (int)currentRecipe[0].hitNumber - GameManager.current.hammerLevel)
                    {
                        nbOfHit = 0;
                        Debug.Log("Finnally Crafted");
                        int recipeNumber = Random.Range(0, recipes.Count);
                        currentRecipe.Remove(currentRecipe[0]);
                        currentRecipe.Add(recipes[recipeNumber]);
                        recipes.Remove(recipes[0]);
                    }
                    else
                    {
                        Debug.Log("YAY WE CRAFTING MATE!!!");
                        Debug.Log("HIT MORE !");
                    }
                }
                else
                { Debug.Log("Wrong Hit"); }
            }
            else
            {
                Debug.Log("We fked up somewhere");
            }
        }
        else if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            canCraft = CompareToRecipe(recievedRecipeIngredients);

            if (canCraft)
            {
                if (currentRecipe[0].hammerHit == Recipe.HammerHit.HeavyHit)
                {
                    nbOfHit += 1;
                    if (nbOfHit == (int)currentRecipe[0].hitNumber - GameManager.current.hammerLevel)
                    {
                        nbOfHit = 0;
                        Debug.Log("Finnally Crafted");
                        int recipeNumber = Random.Range(0, recipes.Count);
                        currentRecipe.Remove(currentRecipe[0]);
                        currentRecipe.Add(recipes[recipeNumber]);
                        recipes.Remove(recipes[0]);
                    }
                    else
                    {
                        Debug.Log("YAY WE CRAFTING MATE!!!");
                        Debug.Log("HIT MORE !");
                    }
                }
                else
                { Debug.Log("Wrong Hit"); }
            }
            else
            {
                Debug.Log("We fked up somewhere");
            }
        }
    }
    public bool CompareToRecipe(List<Ingredient> ingredients)
    {
        if(currentRecipe[0].numberOfIngredients == Recipe.IngredientNumber.Two)
        {
            bool first = false;
            bool second = false;
            if(currentRecipe[0].firstIngredientName.ToString() == ingredients[0].ingredientName.ToString())
            {
                first = true;
            }
            if(currentRecipe[0].secondIngredientName.ToString() == ingredients[1].ingredientName.ToString())
            {
                second = true;
            }

            if(first && second)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        if (currentRecipe[0].numberOfIngredients == Recipe.IngredientNumber.Three)
        {
            bool first = false;
            bool second = false;
            bool third = false;
            if (currentRecipe[0].firstIngredientName.ToString() == ingredients[0].ingredientName.ToString())
            {
                first = true;
            }
            if (currentRecipe[0].secondIngredientName.ToString() == ingredients[1].ingredientName.ToString())
            {
                second = true;
            }
            if (currentRecipe[0].thirdIngredientName.ToString() == ingredients[2].ingredientName.ToString())
            {
                third = true;
            }

            if (first && second && third)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        if (currentRecipe[0].numberOfIngredients == Recipe.IngredientNumber.Four)
        {
            bool first = false;
            bool second = false;
            bool third = false;
            bool fourth = false;
            if (currentRecipe[0].firstIngredientName.ToString() == ingredients[0].ingredientName.ToString())
            {
                first = true;
            }
            if (currentRecipe[0].secondIngredientName.ToString() == ingredients[1].ingredientName.ToString())
            {
                second = true;
            }
            if (currentRecipe[0].thirdIngredientName.ToString() == ingredients[2].ingredientName.ToString())
            {
                third = true;
            }
            if (currentRecipe[0].fourthIngredientName.ToString() == ingredients[3].ingredientName.ToString())
            {
                fourth = true;
            }

            if (first && second && third && fourth)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        return false;
    }
}
