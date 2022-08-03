using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [SerializeField] GameObject pauseScreen;
    public void onRestartButtonClick()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex);
        SoundManager.Instance.PlaySFX(SoundName.ButtonClick);
    }

    public void onMainMenuButtonClick()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
        SoundManager.Instance.PlaySFX(SoundName.ButtonClick);
    }

    public void onPauseButtonClick()
    {
        Time.timeScale = 0;
        pauseScreen.SetActive(true);
        SoundManager.Instance.PlaySFX(SoundName.ButtonClick);
    }

    public void onResumeButtonClick()
    {
        Time.timeScale = 1f;
        pauseScreen.SetActive(false);
        SoundManager.Instance.PlaySFX(SoundName.ButtonClick);
    }

}
