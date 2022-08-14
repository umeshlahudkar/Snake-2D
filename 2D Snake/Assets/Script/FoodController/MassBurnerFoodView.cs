using UnityEngine;

public class MassBurnerFoodView : MonoBehaviour
{
    public FoodControllerr foodController;

    public void Disable()
    {
        gameObject.SetActive(false);
        ObjectPooler.Instance.ReturnToPool(gameObject, ObjectType.MassBurnerFood);
    }

    public void SetFoodController(FoodControllerr _foodControllerr)
    {
        foodController = _foodControllerr;
    }
}
