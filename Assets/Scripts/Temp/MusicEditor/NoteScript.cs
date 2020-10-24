using System.Collections;
using System.Collections.Generic;
using Tool;
using UnityEngine;

public class NoteScript : MonoBehaviour
{
    public float targetBeatPosition;
    public AudioSource tick;
    public GameObject targetGameObject;
    public GameObject spawnGameObject;

    public SpriteRenderer thisRenderer;


    bool isDisabled;

    private void Start()
    {
        isDisabled = false;
        
    }
    public void Update()
    {
        // convert target beat position into beat position (in beat)

      
        float value = Mathf.InverseLerp(targetBeatPosition -4 , targetBeatPosition, Tools.GetCurrentTimeInBeat(InputHolder.Holder.musicPlayer.time, InputHolder.Holder.rawOffset, 60f /InputHolder.Holder.bpm));
        transform.position = new Vector3(Mathf.Lerp(spawnGameObject.transform.position.x, targetGameObject.transform.position.x, value), spawnGameObject.transform.position.y, 30);


        if (Tools.GetCurrentTimeInBeat(InputHolder.Holder.musicPlayer.time, InputHolder.Holder.rawOffset, 60f / InputHolder.Holder.bpm) < targetBeatPosition - 4 || Tools.GetCurrentTimeInBeat(InputHolder.Holder.musicPlayer.time, InputHolder.Holder.rawOffset, 60f / InputHolder.Holder.bpm) > targetBeatPosition)
        {
            
            if (!isDisabled)
            {
                isDisabled = true;
                if (InputHolder.Holder.musicPlayer.isPlaying)
                    tick.Play();
                thisRenderer.enabled = false;
            }
        }
        else
        {
           
            thisRenderer.enabled = true;
            isDisabled = false;
        }

      

    }

}
