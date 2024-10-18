using UnityEngine;

[CreateAssetMenu(fileName = "NewRecipe", menuName = "Recipe/Create New Recipe")]
public class SORecipe : ScriptableObject
{
    public int id;
    public PotionType potionType;
    public IngredientType ingredientType;
    public HeatLevel heatLevel;
}
