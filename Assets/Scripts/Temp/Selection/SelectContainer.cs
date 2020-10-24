using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectContainer : MonoBehaviour
{
    public int index;
    public Sprite image;
    public string artistName;
    public string songName;


    [SerializeField]
    private Image imgRenderer;
    [SerializeField]
    private TextMeshProUGUI artistNameTmp;
    [SerializeField]
    private TextMeshProUGUI songNameTmp;



    private void Awake()
    {
        
    }

    private void Start()
    {
        artistNameTmp.text = artistName;
        songNameTmp.text = songName;
        imgRenderer.sprite = image;

        if (imgRenderer.sprite == null)
            imgRenderer.enabled = false;
    }
    public void OnThisObjectSelect()
    {
        if (MaterialGetter.Get.index != index)
        {
            MaterialGetter.Get.index = index;

            if (PlayAudio.UniversalAudioPlayer.musicPlayer.isPlaying)
                PlayAudio.UniversalAudioPlayer.musicPlayer.Pause();

            PlayAudio.UniversalAudioPlayer.musicPlayer.clip = MaterialGetter.Get.audioClips[MaterialGetter.Get.index];
            PlayAudio.UniversalAudioPlayer.musicPlayer.time = MaterialGetter.Get.beatInfos[MaterialGetter.Get.index].highLight;
            PlayAudio.UniversalAudioPlayer.musicPlayer.Play();
        }
    }
}
