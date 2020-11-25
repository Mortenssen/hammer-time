using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour
{
    public enum IngredientName { Nails, Glue, Tape, Battery };
    public IngredientName ingredientName;

    public enum HammerHit { LightHit, HeavyHit };
    public HammerHit hammerHit;


}
