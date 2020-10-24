using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplaySongLength : MonoBehaviour
{
    public TextMeshProUGUI text;
    public TextMeshProUGUI beatText;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (InputHolder.Holder.musicPlayer.clip != null && InputHolder.Holder.musicPlayer.time >= 0)
        {
            text.text = Convert.ToString(TimeSpan.FromSeconds(InputHolder.Holder.musicPlayer.time));

            if(InputHolder.Holder. bpm != 0)
            beatText.text = (Tool.Tools.GetCurrentTimeInBeat(InputHolder.Holder.musicPlayer.time, InputHolder.Holder.rawOffset, 60 / InputHolder.Holder.bpm).ToString("0.00"));

        }
    }
}
