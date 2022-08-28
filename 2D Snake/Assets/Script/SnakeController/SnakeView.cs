using UnityEngine;

public class SnakeView : MonoBehaviour
{
    public SnakeControllerr snakeController { get; private set; }
    private bool horizontalMoving = false;
    private bool verticalMoving = false;
    private Direction direction = Direction.None;
    private float timeCount;
    private float movementHalt = 0.15f;
   
    void Update()
    {
        UserInput();

        if (Time.time - timeCount >= movementHalt)
        {
            timeCount = Time.time;
            snakeController.Move(direction);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<SnakeSegment>())
        {
            this.enabled = false;
            snakeController.InvokeOnGameOverEvent();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ISwapable screenWrap = collision.gameObject.GetComponent<ISwapable>();
        if(screenWrap != null)
        {
            gameObject.transform.position = screenWrap.GetRespwanPosition(gameObject.transform.position);
        }

        IConsumable consumable = collision.gameObject.GetComponent<IConsumable>();
        if (consumable != null)
        {
            if(consumable.GetType() == FoodType.MassBurnerFood)
            {
                consumable.Destroy();
                snakeController.Shrink();
            }
            else
            {
                consumable.Destroy();
                snakeController.Grow();
            }
            
        }
    }

    void UserInput()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) && !horizontalMoving)
        {
            horizontalMoving = true;
            verticalMoving = false;
            direction = Direction.Right;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && !horizontalMoving)
        {
            horizontalMoving = true;
            verticalMoving = false;
            direction = Direction.Left;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) && !verticalMoving)
        {
            verticalMoving = true;
            horizontalMoving = false;
            direction = Direction.Up;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && !verticalMoving)
        {
            verticalMoving = true;
            horizontalMoving = false;
            direction = Direction.Down;
        }
    }

    public void SetSnakeController(SnakeControllerr snakeController)
    {
        this.snakeController = snakeController;
    }
}

