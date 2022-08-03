using UnityEngine;
using System.Threading.Tasks;

public class FoodControllerr
{
    public MassBurnerFoodView massBurnerFoodView { get; private set; }
    public MassGainerFoodView massGainerFoodView { get; private set; }

    public BoxCollider2D boundry;

    public FoodControllerr(GameObject _massBurnerFoodView, BoxCollider2D _boundry)
    {
        massBurnerFoodView = ObjectPooler.Instance.GetObject(_massBurnerFoodView, ObjectType.MassBurnerFood).GetComponent<MassBurnerFoodView>();
        massBurnerFoodView.SetFoodController(this);
        massBurnerFoodView.gameObject.SetActive(true);
        boundry = _boundry;
        massBurnerFoodView.transform.position = GetRandomPosition();
        DisableAfterTime();
    }

    public FoodControllerr(MassGainerFoodView _massGainerFoodView , BoxCollider2D _boundry)
    {
        massGainerFoodView = GameObject.Instantiate<MassGainerFoodView>(_massGainerFoodView);
        massGainerFoodView.SetFoodController(this);
        boundry = _boundry;
        massGainerFoodView.transform.position = GetRandomPosition();
    }

    public Vector2 GetRandomPosition()
    {
        float x = Random.Range(boundry.bounds.min.x, boundry.bounds.max.x);
        float y = Random.Range(boundry.bounds.min.y, boundry.bounds.max.y);

        return new Vector2(Mathf.Round(x), Mathf.Round(y));
    }

    public async void DisableAfterTime()
    {
        await Task.Delay(System.TimeSpan.FromSeconds(7));

        if(massBurnerFoodView != null)
        {
            massBurnerFoodView.Disable();
        }
    }
}
