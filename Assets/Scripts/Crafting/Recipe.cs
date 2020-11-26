using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Recipe
{
    public string recipeName = "Recipe";

    public GameObject modelOutput;

    public enum HammerHit { LightHit, HeavyHit };
    public HammerHit hammerHit;

    public int hitsRequired = 8;
    public int currentHits = 0;

    public enum IngredientNumber { Two, Three, Four };
    public IngredientNumber numberOfIngredients;

    public enum IngredientName { Nails, Glue, DuctTape, Crystal, Wires, Eyeball };
    public IngredientName firstIngredientName;
    public IngredientName secondIngredientName;
    public IngredientName thirdIngredientName;
    public IngredientName fourthIngredientName;

    public void Craft()
    {
        if (numberOfIngredients == IngredientNumber.Two)
        {
            
        }
        else if(numberOfIngredients == IngredientNumber.Three)
        {
            
        }
        else if (numberOfIngredients == IngredientNumber.Four)
        {
            
        }
    }

}
