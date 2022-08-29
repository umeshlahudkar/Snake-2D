using UnityEngine;

public class UIDisplayController : MonoBehaviour
{
    [SerializeField] GameObject gameOverScreen;

    private void OnEnable()
    {
        SnakeControllerr.OnGameOver += EnableGameOverScreen;
    }

    private void OnDisable()
    {
        SnakeControllerr.OnGameOver -= EnableGameOverScreen;
    }

    public void EnableGameOverScreen()
    {
        gameOverScreen.SetActive(true);
    }

    public void DisableGameOverScreen()
    {
        gameOverScreen.SetActive(false);
    }

}
