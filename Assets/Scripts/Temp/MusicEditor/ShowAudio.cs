using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowAudio : MonoBehaviour
{
    public Slider audioLengthVisualizer;
    public Slider lengthVisualierZoomSlider;
    public Scrollbar lengthVisualierScroll;

    private RectTransform audRec;

    [SerializeField]
    private float defaultValue;
    public float maxZoomValue;
    private float visualizerLength;
    // debug code
    public int wid;
    public int hei;
    void Start()
    {
        audRec = audioLengthVisualizer.GetComponent<RectTransform>();
        defaultValue = audRec.sizeDelta.x;
        Debug.Log(defaultValue);

        lengthVisualierZoomSlider.minValue = defaultValue;
        lengthVisualierZoomSlider.maxValue = maxZoomValue;

        lengthVisualierZoomSlider.value = lengthVisualierZoomSlider.minValue;
        audioLengthVisualizer.value = 0.0f;
    }

    private void Update()
    {
        if (InputHolder.Holder.musicPlayer.clip != null)
        {
            audioLengthVisualizer.maxValue = InputHolder.Holder.musicPlayer.clip.length;    
            if (InputHolder.Holder.musicPlayer.isPlaying) {
                audioLengthVisualizer.value = InputHolder.Holder.musicPlayer.time;
                audioLengthVisualizer.interactable = false;
            }
            else
            {
                audioLengthVisualizer.interactable = true;
            }
               
        }

      


    }


    public void ChangeRecValue()
    {
        audRec.sizeDelta = new Vector2(lengthVisualierZoomSlider.value, audRec.sizeDelta.y);
    }

    public void ChangeCurrentAudioPlayTime()
    {
        if (InputHolder.Holder.musicPlayer.isPlaying)
        { return; }
       // Debug.Log("Music is not playing, change will be made");
            InputHolder.Holder.musicPlayer.time = audioLengthVisualizer.value;
            Debug.Log(InputHolder.Holder.musicPlayer.time);
        
    }

    public void UpdateSlider()
    {
        audioLengthVisualizer.value = InputHolder.Holder.musicPlayer.time;
    }
}
