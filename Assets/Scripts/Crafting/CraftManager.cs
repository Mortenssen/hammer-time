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

    private void Awake()
    {
        current = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentRecipe.Add(recipes[0]);
        recipes.Remove(recipes[0]);
    }

    public void RecieveHit(int hitQuantity, bool isLightHit)
    {
        if(isLightHit && currentRecipe[0].hammerHit == Recipe.HammerHit.LightHit)
        {
            currentRecipe[0].currentHits += hitQuantity;
        }
        else if(!isLightHit && currentRecipe[0].hammerHit == Recipe.HammerHit.HeavyHit)
        {
            currentRecipe[0].currentHits += hitQuantity;
        }
        else
        {
            for (int i = 0; i < recievedRecipeIngredients.Count; i++)
            {
                Destroy(recievedRecipeIngredients[i].gameObject);
            }
            recievedRecipeIngredients.Clear();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(currentRecipe[0].currentHits >= currentRecipe[0].hitsRequired)
        {
            for (int i = 0; i < recievedRecipeIngredients.Count; i++)
            {
                Destroy(recievedRecipeIngredients[i].gameObject);
            }
            recievedRecipeIngredients.Clear();
            if (recievedRecipeIngredients.Count == 0)
            {
                currentRecipe.Remove(currentRecipe[0]);
                if(recipes.Count > 0)
                {
                    currentRecipe.Add(recipes[0]);
                    recipes.Remove(recipes[0]);
                }                
            }
        }
    }

    public void RecipeIngredients(List<Ingredient> ingredients)
    {
        currentRecipeIngredients.Clear();

        currentRecipeIngredients.Add(currentRecipe[0].firstIngredientName.ToString());
        currentRecipeIngredients.Add(currentRecipe[0].secondIngredientName.ToString());
        currentRecipeIngredients.Add(currentRecipe[0].thirdIngredientName.ToString());
        currentRecipeIngredients.Add(currentRecipe[0].fourthIngredientName.ToString());

        recievedRecipeIngredients = ingredients;


        canCraft = CompareToRecipe(recievedRecipeIngredients);

        if (canCraft)
        {
            Debug.Log("YAY WE CRAFTING MATE!!!");
        }
        else
        {
            Debug.Log("We fked up somewhere");
        }
        
    }

    public bool CompareToRecipe(List<Ingredient> ingredients)
    {
        if(currentRecipe[0].numberOfIngredients == Recipe.IngredientNumber.Two && ingredients.Count == 2)
        {
            bool first = false;
            bool second = false;
            if((currentRecipe[0].firstIngredientName.ToString() == ingredients[0].ingredientName.ToString()) 
                || (currentRecipe[0].firstIngredientName.ToString() == ingredients[1].ingredientName.ToString()))
            {
                first = true;
            }
            if((currentRecipe[0].secondIngredientName.ToString() == ingredients[1].ingredientName.ToString()) 
                || (currentRecipe[0].secondIngredientName.ToString() == ingredients[0].ingredientName.ToString()))
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

        if (currentRecipe[0].numberOfIngredients == Recipe.IngredientNumber.Three && ingredients.Count == 3)
        {
            bool first = false;
            bool second = false;
            bool third = false;
            if ((currentRecipe[0].firstIngredientName.ToString() == ingredients[0].ingredientName.ToString())
                || (currentRecipe[0].firstIngredientName.ToString() == ingredients[1].ingredientName.ToString())
                || (currentRecipe[0].firstIngredientName.ToString() == ingredients[2].ingredientName.ToString()))
            {
                first = true;
            }
            if ((currentRecipe[0].secondIngredientName.ToString() == ingredients[1].ingredientName.ToString())
                || (currentRecipe[0].secondIngredientName.ToString() == ingredients[0].ingredientName.ToString())
                || (currentRecipe[0].secondIngredientName.ToString() == ingredients[2].ingredientName.ToString()))
            {
                second = true;
            }
            if ((currentRecipe[0].thirdIngredientName.ToString() == ingredients[2].ingredientName.ToString())
                || (currentRecipe[0].thirdIngredientName.ToString() == ingredients[1].ingredientName.ToString())
                || (currentRecipe[0].thirdIngredientName.ToString() == ingredients[0].ingredientName.ToString()))
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

        if (currentRecipe[0].numberOfIngredients == Recipe.IngredientNumber.Four && ingredients.Count == 4)
        {
            bool first = false;
            bool second = false;
            bool third = false;
            bool fourth = false;
            if ((currentRecipe[0].firstIngredientName.ToString() == ingredients[0].ingredientName.ToString())
                || (currentRecipe[0].firstIngredientName.ToString() == ingredients[1].ingredientName.ToString())
                || (currentRecipe[0].firstIngredientName.ToString() == ingredients[2].ingredientName.ToString())
                || (currentRecipe[0].firstIngredientName.ToString() == ingredients[3].ingredientName.ToString()))
            {
                first = true;
            }
            if ((currentRecipe[0].secondIngredientName.ToString() == ingredients[1].ingredientName.ToString())
                || (currentRecipe[0].secondIngredientName.ToString() == ingredients[0].ingredientName.ToString())
                || (currentRecipe[0].secondIngredientName.ToString() == ingredients[2].ingredientName.ToString())
                || (currentRecipe[0].secondIngredientName.ToString() == ingredients[3].ingredientName.ToString()))
            {
                second = true;
            }
            if ((currentRecipe[0].thirdIngredientName.ToString() == ingredients[2].ingredientName.ToString())
                || (currentRecipe[0].thirdIngredientName.ToString() == ingredients[1].ingredientName.ToString())
                || (currentRecipe[0].thirdIngredientName.ToString() == ingredients[0].ingredientName.ToString())
                || (currentRecipe[0].thirdIngredientName.ToString() == ingredients[3].ingredientName.ToString()))
            {
                third = true;
            }
            if ((currentRecipe[0].fourthIngredientName.ToString() == ingredients[3].ingredientName.ToString())
                || (currentRecipe[0].fourthIngredientName.ToString() == ingredients[0].ingredientName.ToString())
                || (currentRecipe[0].fourthIngredientName.ToString() == ingredients[1].ingredientName.ToString())
                || (currentRecipe[0].fourthIngredientName.ToString() == ingredients[2].ingredientName.ToString()))
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
