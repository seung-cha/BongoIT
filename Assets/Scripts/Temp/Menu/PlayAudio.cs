using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class PlayAudio : MonoBehaviour
{
    public static PlayAudio UniversalAudioPlayer;


    public AudioSource musicPlayer;
    private void Awake()
    {
        if (UniversalAudioPlayer == null)
            UniversalAudioPlayer = this;

        if (UniversalAudioPlayer != null && UniversalAudioPlayer != this)
            Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2 || SceneManager.GetActiveScene().buildIndex == 3)
        {
           // Debug.Log("called");
            if(musicPlayer.isPlaying)
            musicPlayer.Pause();
        }

    }

}
