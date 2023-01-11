using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtonsScript : MonoBehaviour
{
    public AudioSource audio;
    public AudioClip clickSound;

    public void PlayClickSound()
    {
        audio.PlayOneShot(clickSound);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void ResetScene()
    {
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }
    public void PauseGame()
    {
        Time.timeScale = 0f;
    }
    public void ContinueGame()
    {
        Time.timeScale = 1f;
    }
}
