using UnityEngine;
using UnityEngine.SceneManagement;


public class LobbyUIController : MonoBehaviour
{
   
    public void onPlayButtonClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SoundManager.Instance.PlaySFX(SoundName.ButtonClick);
    }

    public void onQuitButtonClick()
    {
        Application.Quit();
        SoundManager.Instance.PlaySFX(SoundName.ButtonClick);
    }

}

