using UnityEngine;

public class FoodService : GenericSingleton<FoodService>
{
    [SerializeField] MassGainerFoodView massGainerFood;
    [SerializeField] GameObject massBurnerFood;
    [SerializeField] BoxCollider2D boundry;

    private void Start()
    {
        SpwanMassGainerFood();
    }

    public void SpwanMassGainerFood()
    {
        FoodControllerr foodController = new FoodControllerr(massGainerFood, boundry);
    }

    public void SpwanMassBurnerFood()
    {
        FoodControllerr foodController = new FoodControllerr(massBurnerFood, boundry);
    }


}
