using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSelection : MonoBehaviour
{
    public SpriteRenderer thisRenderer;
    bool isSelected;
    GameObject targetGameObject;
    NoteScript targetNoteScript;


    float nextValue;
    float prevValue;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("called");
           RaycastHit2D hit2D = Physics2D.Raycast(new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y), Vector2.zero,50f);
            if (hit2D.collider != null)
            {
                Debug.Log(hit2D.transform.gameObject.name);
                targetGameObject = hit2D.collider.transform.gameObject;
                 targetNoteScript = hit2D.collider.GetComponent<NoteScript>();
            }
        }

        
        if (targetGameObject != null)
        {
            thisRenderer.enabled = true;
            this.gameObject.transform.position = new Vector2(targetGameObject.transform.position.x, this.gameObject.transform.position.y);
            nextValue = targetNoteScript.targetBeatPosition + 0.25f;
            prevValue = targetNoteScript.targetBeatPosition - 0.25f;

            if(!targetNoteScript.thisRenderer.enabled)
            {
                targetGameObject = null;
            }

            if (!InputHolder.Holder.musicPlayer.isPlaying)
            {
                if (Input.GetKeyDown(KeyCode.Z))
                {
                    if (!InputHolder.Holder.beatPositionDictionary.ContainsKey(prevValue))
                    {
                        bool temp = InputHolder.Holder.beatPositionDictionary[targetNoteScript.targetBeatPosition];
                        InputHolder.Holder.beatPositionDictionary.Remove(targetNoteScript.targetBeatPosition);
                        targetNoteScript.targetBeatPosition -= 0.25f;
                        InputHolder.Holder.beatPositionDictionary.Add(targetNoteScript.targetBeatPosition, temp);
                    }
                }
                else if (Input.GetKeyDown(KeyCode.X))
                {
                    InputHolder.Holder.beatPositionDictionary.Remove(targetNoteScript.targetBeatPosition);
                    targetGameObject.SetActive(false);
                    targetGameObject = null;
                }
                else if (Input.GetKeyDown(KeyCode.C))
                {
                    if (!InputHolder.Holder.beatPositionDictionary.ContainsKey(nextValue))
                    {
                        bool temp = InputHolder.Holder.beatPositionDictionary[targetNoteScript.targetBeatPosition];
                        InputHolder.Holder.beatPositionDictionary.Remove(targetNoteScript.targetBeatPosition);
                        targetNoteScript.targetBeatPosition += 0.25f;
                        InputHolder.Holder.beatPositionDictionary.Add(targetNoteScript.targetBeatPosition, temp);
                    }
                }
            }          
        }
        else
        { thisRenderer.enabled = false; }

    }
}
