using UnityEngine;
using TMPro;

public class SnakeView : MonoBehaviour
{
    public SnakeControllerr snakeController { get; private set; }
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI shieldActive;

    protected bool horizontalMoving = false;
    protected bool verticalMoving = false;
    protected Direction direction = Direction.None;
    protected float timeCount;
    protected float movementHalt = 0.15f;
    protected float shieldActiveTime = 8f;
    protected bool isShieldActive = false;
   
    protected virtual void Update()
    {
        UserInput();

        if (Time.time - timeCount >= movementHalt)
        {
            timeCount = Time.time;
            snakeController.Move(direction);
        }

        if(isShieldActive && shieldActiveTime >= 0)
        {
            shieldActiveTime -= Time.deltaTime;
            DisplayShieldTime();
        }
    }

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<SnakeSegment>())
        {
            this.enabled = false;
            snakeController.InvokeOnGameOverEvent();
        }
    }

    protected void OnTriggerEnter2D(Collider2D collision)
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

    protected virtual void UserInput()
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

    public virtual void UpdateScoreText(float score)
    {
        scoreText.text = "Score : " + score.ToString();
    }

    public virtual void StartShieldTimer()
    {
        isShieldActive = true;
        shieldActive.gameObject.SetActive(true);
    }
    public virtual void DisplayShieldTime()
    {
        shieldActive.text = "Shield Active : " + ((int)shieldActiveTime);
    }

    public virtual void StopShieldTimer()
    {
        isShieldActive = false;
        shieldActive.gameObject.SetActive(false);
        shieldActiveTime = 8f;
    }

    public void SetSnakeController(SnakeControllerr snakeController)
    {
        this.snakeController = snakeController;
    }
}

