using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerRecipe", menuName = "Recipe/Player Recipe")]
public class SOCurrentRecipe : ScriptableObject
{
    public PotionType potion;
    public IngredientType ingredient;
    public HeatLevel heat;
}
