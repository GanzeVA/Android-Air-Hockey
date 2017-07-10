using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    private GameObject musicPlayer;

    void Awake()
    {
        musicPlayer = GameObject.Find("Music Player Used");
        if (musicPlayer == null)
        {
            musicPlayer = this.gameObject;
            musicPlayer.name = "Music Player Used";
            DontDestroyOnLoad(musicPlayer);
        }
        else
        {
            if (this.gameObject.name != "Music Player Used")
            {
                Destroy(this.gameObject);
            }
        }
    }

    public void EnableMusic()
    {
        musicPlayer.GetComponent<AudioSource>().Play();
    }

    public void DisableMusic()
    {
        musicPlayer.GetComponent<AudioSource>().Stop();
    }
}
