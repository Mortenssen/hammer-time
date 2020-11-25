using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour
{
    public enum IngredientName { Nails, Glue, Tape, Battery };

    public IngredientName ingredientName;

    public enum IngredientCategory { Green, Blue, Yellow, Red };

    public IngredientCategory category;


}
