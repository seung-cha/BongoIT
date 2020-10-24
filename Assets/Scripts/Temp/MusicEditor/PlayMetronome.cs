using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// BongoEditor

public class PlayMetronome : MonoBehaviour
{
    public AudioClip[] metronomeClips = new AudioClip[2];
    public AudioSource metronomePlayer;
    float bpmInSecond;
    float nextTick;
    float positionInBeat;
    bool enableMetronome;
    bool tickNow;

    float currentBeatPosition;
    int lastIndex;
    float lastTickTime;

    public Toggle toggle;

    // Debug variable
    public bool halfBpm;
    public bool doubleBPM;


    public bool debug;
    void Start()
    {
        halfBpm = false;
        metronomePlayer.clip = metronomeClips[0];
        tickNow = false;
        lastIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        enableMetronome = toggle.isOn;
        //Debug code
        if (halfBpm)
        {
            InputHolder.Holder.bpm /= 2;
            halfBpm = false;
        }
        if(doubleBPM)
        {
            InputHolder.Holder.bpm *= 2;
            doubleBPM = false;
        }

         // Check if user changed playtime (especially when rewinded)
       
        if(positionInBeat < lastTickTime)
            lastIndex = (int)currentBeatPosition + 1;


        if (positionInBeat < 0)
            lastIndex = 0;
        //If so, adjust the lastIndex value accordingly.
        


        bpmInSecond = 60 / InputHolder.Holder.bpm;


        // This gets you the playtime in Beat (e.g 2.25, 3.71, 1.35 etc)
        positionInBeat = (InputHolder.Holder.musicPlayer.time  - InputHolder.Holder.rawOffset) / bpmInSecond;
       

        // This gets you the playtime in Wholebar (e.g 1, 2, 3, 4. When positionInBeat is 1.52, 2.31, 3.61, 4.12).       
        currentBeatPosition =  (int)positionInBeat;

       // Debug.Log(currentBeatPosition);
       
        
        if (InputHolder.Holder.bpm != 0 && InputHolder.Holder.musicPlayer.clip != null && InputHolder.Holder.musicPlayer.isPlaying)
        {
            if(positionInBeat < 0)
            { return; }
            if (currentBeatPosition >= lastIndex)
            {
                tickNow = true;
                lastTickTime = currentBeatPosition;
                lastIndex = (int)currentBeatPosition + 1;

            }
        }
        
        if(debug)
            Debug.Log(positionInBeat + " is the current beat");
    }

    private void LateUpdate()
    {
        if(tickNow)
        {
            tickNow = false;
            if (currentBeatPosition % 4 == 0)
            {
                if(currentBeatPosition >= 0)
                metronomePlayer.clip = metronomeClips[1];
                
            }
            else
            {
                if(metronomePlayer.clip != metronomeClips[0])
                metronomePlayer.clip = metronomeClips[0];

            }

            if(enableMetronome)
            metronomePlayer.Play();
        }
    }

  
}
