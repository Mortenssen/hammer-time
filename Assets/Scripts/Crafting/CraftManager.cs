using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftManager : MonoBehaviour
{
    public static CraftManager current = null;

    public List<Recipe> currentRecipe = new List<Recipe>();
    public List<Recipe> recipes = new List<Recipe>();

    public List<string> currentRecipeIngredients = new List<string>();
    public List<Ingredient> recievedRecipeIngredients = new List<Ingredient>();

    public Transform productSpawn;

    Hammer hammerTool;

    public Image outputImage;
    public Image[] ingredientsImages;

    public Sprite nailsImage;
    public Sprite glueImage;
    public Sprite ductTapeImage;
    public Sprite crystalImage;
    public Sprite wiresImage;
    public Sprite eyeballImage;
    public Sprite alienImage;
    public Sprite antimatterImage;
    public Sprite metalImage;
    public Sprite pipeImage;

    public bool canCraft = false;

    private void Awake()
    {
        current = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        hammerTool = GameObject.Find("HammerTool").GetComponent<Hammer>();
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

    void SetImages()
    {
        if(currentRecipe.Count != 0)
        {
            outputImage.sprite = currentRecipe[0].outputImage;

            for (int i = 0; i < currentRecipeIngredients.Count; i++)
            {
                switch (currentRecipeIngredients[i])
                {
                    case "Nails":
                        ingredientsImages[i].sprite = nailsImage;
                        break;
                    case "Glue":
                        ingredientsImages[i].sprite = glueImage;
                        break;
                    case "DuctTape":
                        ingredientsImages[i].sprite = ductTapeImage;
                        break;
                    case "Crystal":
                        ingredientsImages[i].sprite = crystalImage;
                        break;
                    case "Wires":
                        ingredientsImages[i].sprite = wiresImage;
                        break;
                    case "Eyeball":
                        ingredientsImages[i].sprite = eyeballImage;
                        break;
                    case "Alien":
                        ingredientsImages[i].sprite = alienImage;
                        break;
                    case "Antimatter":
                        ingredientsImages[i].sprite = antimatterImage;
                        break;
                    case "Metal":
                        ingredientsImages[i].sprite = metalImage;
                        break;
                    case "Pipe":
                        ingredientsImages[i].sprite = pipeImage;
                        break;
                    default:
                        break;
                }
            }

        }
        
    }

    // Update is called once per frame
    void Update()
    {
        SetImages();

        if(currentRecipe[0].currentHits >= currentRecipe[0].hitsRequired)
        {
            if (CustomEvents.OutputCrafted !=null) CustomEvents.OutputCrafted();
            Instantiate(currentRecipe[0].modelOutput, productSpawn.position, productSpawn.rotation);
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
            Debug.Log("i enter here");
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
