using UnityEngine;

public class FoodSpwaner : MonoBehaviour
{
    [SerializeField] private MassGainerFoodController massGainerFoodPrefab;
    [SerializeField] private MassBurnerFoodController massBurnerFoodPrefab;
    [SerializeField] private BoxCollider2D boundry;
    private MassGainerFoodController massGainerFood = null;

    private int massGainerFoodCount;
    private int massBurnerSpwanInterval = 5;

    private void Start()
    {
        SpwanMassGainerFood();
    }

    public void SpwanMassGainerFood()
    {
        massGainerFoodCount++;

        if(massGainerFood == null)
        {
            massGainerFood = Instantiate(massGainerFoodPrefab, GetRandomPosition(), Quaternion.identity);
            massGainerFood.SetFoodSpwaner(this);
        } 
        else
        {
            massGainerFood.transform.position = GetRandomPosition();
        }
        

        if(massGainerFoodCount >= massBurnerSpwanInterval)
        {
            massGainerFoodCount = 0;
            SpwanMassBurnerFood();
        }
    }

    private void SpwanMassBurnerFood()
    {
        Instantiate(massBurnerFoodPrefab, GetRandomPosition(), Quaternion.identity);
    }

    private Vector2 GetRandomPosition()
    {
        float x = Random.Range(boundry.bounds.min.x, boundry.bounds.max.x);
        float y = Random.Range(boundry.bounds.min.y, boundry.bounds.max.y);

        return new Vector2(Mathf.Round(x), Mathf.Round(y));
    }
}

public enum FoodType
{
    None,
    MassGainerFood,
    MassBurnerFood
}
