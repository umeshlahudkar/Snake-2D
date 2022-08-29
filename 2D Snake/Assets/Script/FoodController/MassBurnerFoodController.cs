using UnityEngine;

public class MassBurnerFoodController : MonoBehaviour, IConsumable
{
    private FoodType foodType = FoodType.MassBurnerFood;
    private float timeElapced;
    private float timeToDisable = 8;

    private void Update()
    {
        timeElapced += Time.deltaTime;
        if(timeElapced >= timeToDisable)
        {
            Destroy();
        }
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    public FoodType GetType()
    {
        return foodType;
    }
}
