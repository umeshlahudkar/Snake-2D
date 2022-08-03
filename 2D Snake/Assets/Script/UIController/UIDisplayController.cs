using UnityEngine;
using System.Threading.Tasks;
using TMPro;

public class UIDisplayController : MonoBehaviour
{
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] GameObject specialAbilityDisplay;
    [SerializeField] TextMeshProUGUI abilityTimer;

    int displayHaltTime = 8;
    int time = 8;
    float currentTime;
    bool isTimerActive = false;

    private void OnEnable()
    {
        SnakeControllerr.OnGameOver += EnableGameOverScreen;
        SnakeControllerr.OnSpecialAbilityActive += DisplaySpecialAbility;
    }

    private void OnDisable()
    {
        SnakeControllerr.OnGameOver -= EnableGameOverScreen;
        SnakeControllerr.OnSpecialAbilityActive += DisplaySpecialAbility;
    }

    private void Update()
    {
        if(isTimerActive && Time.time - currentTime >= 1.0f)
        {
            currentTime = Time.time;
            DisplayTime();
            time--;
        }
    }
    public void EnableGameOverScreen()
    {
        gameOverScreen.SetActive(true);
    }

    public void DisableGameOverScreen()
    {
        gameOverScreen.SetActive(false);
    }

    public async void DisplaySpecialAbility()
    {
        specialAbilityDisplay.SetActive(true);
        isTimerActive = true;

        await Task.Delay(System.TimeSpan.FromSeconds(displayHaltTime));

        isTimerActive = false;
        time = 8;
        specialAbilityDisplay.SetActive(false);
    }
    
    public void DisplayTime()
    {
        abilityTimer.text = time.ToString();
    }
}
