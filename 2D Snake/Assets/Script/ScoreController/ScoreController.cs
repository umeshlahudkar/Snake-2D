using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
    TextMeshProUGUI scoreText;
    int score = 0;

    private void OnEnable()
    {
        SnakeControllerr.OnFoodConsume += UpdateScore;
    }

    private void OnDisable()
    {
        SnakeControllerr.OnFoodConsume -= UpdateScore;
    }
    private void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        ScoreDisplay();
    }

    public void UpdateScore()
    {
        score += 10;
        ScoreDisplay();
    }

    public void ScoreDisplay()
    {
        scoreText.text ="SCORE : " + score;
    }
}

