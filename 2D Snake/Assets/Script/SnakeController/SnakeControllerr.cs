using System.Threading.Tasks;
using UnityEngine;
using System;

public class SnakeControllerr
{
    public SnakeView snakeView { get; private set; }
    public SnakeModel snakeModel { get; private set; }

    public static event Action OnFoodConsume;
    public static event Action OnGameOver;
    public static event Action OnSpecialAbilityActive;

    public SnakeControllerr(SnakeModel snakeModel,SnakeSO snakeSO)
   {
        this.snakeModel = snakeModel;
        this.snakeView = GameObject.Instantiate<SnakeView>(snakeSO.snakeView);

        snakeModel.snakeSegments.Add(snakeView.gameObject);

        snakeModel.SetSnakeController(this);
        this.snakeView.SetSnakeController(this);

   }

    public void Move(Direction direction)
    {
        switch(direction)
        {
            case Direction.Right:
                MoveAllSegments(Vector2.right);
                break;

            case Direction.Left:
                MoveAllSegments(Vector2.left);
                break;

            case Direction.Up:
                MoveAllSegments(Vector2.up);
                break;

            case Direction.Down:
                MoveAllSegments(Vector2.down);
                break;
        }
    }

    public void InvokeOnGameOverEvent()
    {
        OnGameOver?.Invoke();
    }

    private void MoveAllSegments(Vector2 direction)
    {
        for(int i = snakeModel.snakeSegments.Count -1; i > 0; i--)
        {
            snakeModel.snakeSegments[i].transform.position = snakeModel.snakeSegments[i - 1].transform.position;
        }

        snakeView.transform.Translate(direction);
    }

    public void Grow()
    {
        GameObject snakeSegment = GameObject.Instantiate(snakeModel.snakeSegment);
        snakeModel.snakeSegments.Add(snakeSegment);

        OnFoodConsume?.Invoke();
        UpdateFoodConsumeCount();
    }

    public void Shrink()
    {
        if(snakeModel.snakeSegments.Count > 1)
        {
            GameObject snakeSegment = snakeModel.snakeSegments[snakeModel.snakeSegments.Count - 1];
            snakeModel.snakeSegments.RemoveAt(snakeModel.snakeSegments.Count - 1);

            SnakeSegment segment = snakeSegment.gameObject.GetComponent<SnakeSegment>();
            segment.Destroy();

            OnFoodConsume?.Invoke();
            UpdateMassBurnerFoodCount();
        }
    }

    private async void ActivateSpecialAbility()
    {
        OnSpecialAbilityActive?.Invoke();

        snakeView.GetComponent<BoxCollider2D>().isTrigger = true;

        await Task.Delay(System.TimeSpan.FromSeconds(snakeModel.shieldActiveTime));

        snakeView.GetComponent<BoxCollider2D>().isTrigger = false;
    }

    private void UpdateFoodConsumeCount()
    {
        snakeModel.foodConsumeCount++;
        if(snakeModel.foodConsumeCount >= snakeModel.consumeCountToSpwanFood)
        {
            snakeModel.foodConsumeCount = 0;
        }
    }

    private void UpdateMassBurnerFoodCount()
    {
        snakeModel.massBurnerFoodCount++;
        if(snakeModel.massBurnerFoodCount >= snakeModel.consumeCountToActivateShield)
        {
            snakeModel.massBurnerFoodCount = 0;
            ActivateSpecialAbility();
        }
    }
}


public enum Direction
{
    None,
    Right,
    Left,
    Up,
    Down
}
