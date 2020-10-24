using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System;
using UnityEngine;

public class AddBeats : MonoBehaviour
{
    [SerializeField]
    float currentSnappedBeat;


    // Update is called once per frame
    void Update()
    {
        if (InputHolder.Holder.musicPlayer.clip == null || InputHolder.Holder.bpm == 0)
            return;

        currentSnappedBeat = Tool.Tools.SnapToTheNearestBeat((InputHolder.Holder.musicPlayer.time - InputHolder.Holder.rawOffset) / (60 / InputHolder.Holder.bpm));

        
            if (Input.GetKeyDown(KeyCode.J))
            {
            // L bongo
            if (!InputHolder.Holder.beatPositionDictionary.ContainsKey(InputHolder.Holder.musicPlayer.time))
            {
                InputHolder.Holder.beatPositionDictionary.Add(currentSnappedBeat, false);
                GameObject obj = ObjectPool.PoolManager.GetLNote();
                obj.GetComponent<NoteScript>().targetBeatPosition = currentSnappedBeat;
                obj.SetActive(true);
            }

           
            Debug.Log("add Left called");
            }
            else if (Input.GetKeyDown(KeyCode.K))
            {
            // R bongo
            if (!InputHolder.Holder.beatPositionDictionary.ContainsKey(InputHolder.Holder.musicPlayer.time))
            {
                InputHolder.Holder.beatPositionDictionary.Add(currentSnappedBeat, true);
                GameObject obj = ObjectPool.PoolManager.GetRNote();
                obj.GetComponent<NoteScript>().targetBeatPosition = currentSnappedBeat;
                obj.SetActive(true);
            }
        }
        
    }
}
