using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    private GameObject musicPlayer;
    public GameObject disableMusic;
    public GameObject enableMusic;

    public GameObject credits;
    public GameObject menu;

    void Start()
    {
        musicPlayer = GameObject.Find("Music Player Used");
        if (musicPlayer.GetComponent<AudioSource>().isPlaying)
        {
            disableMusic.SetActive(true);
            enableMusic.SetActive(false);
        }
        else
        {
            disableMusic.SetActive(false);
            enableMusic.SetActive(true);
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void StartGameCPU()
    {
        SceneManager.LoadScene("GameCPU");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void Credits()
    {
        credits.SetActive(true);
        menu.SetActive(false);
    }

    public void ExitCredits()
    {
        credits.SetActive(false);
        menu.SetActive(true);
    }

    public void PlayMusic()
    {
        musicPlayer.GetComponent<MusicController>().EnableMusic();
    }

    public void UnPlayMusic()
    {
        musicPlayer.GetComponent<MusicController>().DisableMusic();
    }

    public void RateMe()
    {
        Application.OpenURL("market://details?id=com.zborowski.pixelhockey");
    }
}
