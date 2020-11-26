using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Recipe
{
    public string recipeName = "Recipe";

    public GameObject modelOutput;

    public enum IngredientNumber { Two, Three, Four };

    public IngredientNumber numberOfIngredients;

    public enum HitNumber { Four = 4, Five = 5, Six = 6, Seven = 7, Eight = 8}
    public HitNumber hitNumber;

    public enum IngredientName { Nails, Glue, Tape, Battery };

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
        if(hammerHit == HammerHit.LightHit)
        {

        }
        else if(hammerHit == HammerHit.HeavyHit)
        {

        }
    }

}
