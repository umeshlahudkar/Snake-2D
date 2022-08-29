using UnityEngine;
using TMPro;

public class SnakeView2 : SnakeView
{
    [SerializeField] private TextMeshProUGUI scoreText2;
    [SerializeField] private TextMeshProUGUI shieldActive2;

    protected override void UserInput()
    {
        if (Input.GetKeyDown(KeyCode.D) && !horizontalMoving)
        {
            horizontalMoving = true;
            verticalMoving = false;
            direction = Direction.Right;
        }
        else if (Input.GetKeyDown(KeyCode.A) && !horizontalMoving)
        {
            horizontalMoving = true;
            verticalMoving = false;
            direction = Direction.Left;
        }
        else if (Input.GetKeyDown(KeyCode.W) && !verticalMoving)
        {
            verticalMoving = true;
            horizontalMoving = false;
            direction = Direction.Up;
        }
        else if (Input.GetKeyDown(KeyCode.S) && !verticalMoving)
        {
            verticalMoving = true;
            horizontalMoving = false;
            direction = Direction.Down;
        }
    }

    public override void UpdateScoreText(float score)
    {
        scoreText2.text = "Score : " + score.ToString();
    }

    public override void StartShieldTimer()
    {
        isShieldActive = true;
        shieldActive2.gameObject.SetActive(true);
    }
    public override void DisplayShieldTime()
    {
        shieldActive2.text = "Shield Active : " + ((int)shieldActiveTime);
    }

    public override void StopShieldTimer()
    {
        isShieldActive = false;
        shieldActive2.gameObject.SetActive(false);
        shieldActiveTime = 8f;
    }
}
