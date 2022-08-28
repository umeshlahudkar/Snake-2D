using UnityEngine;

public class MassGainerFoodController : MonoBehaviour, IConsumable
{
    private FoodType foodType = FoodType.MassGainerFood;
    private FoodSpwaner foodSpwaner;

    public void Destroy()
    {
        foodSpwaner.SpwanMassGainerFood();
    }

    public void SetFoodSpwaner(FoodSpwaner foodSpwaner)
    {
        this.foodSpwaner = foodSpwaner;
    }

    public FoodType GetType()
    {
        return foodType;
    }
}
