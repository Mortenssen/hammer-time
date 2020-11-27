using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour
{
    public enum IngredientName { Nails, Glue, DuctTape, Crystal, Wires, Eyeball, Alien, Antimatter, Metal, Pipe };
    public IngredientName ingredientName;

    public AudioClip audioClip;
}
