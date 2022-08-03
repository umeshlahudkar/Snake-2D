using UnityEngine;

public class MassGainerFoodView : MonoBehaviour
{
    public FoodControllerr foodController;

    public void SetFoodController(FoodControllerr _foodControllerr)
    {
        foodController = _foodControllerr;
    }

    public void Respwan()
    {
        gameObject.transform.position = foodController.GetRandomPosition();
    }
}
