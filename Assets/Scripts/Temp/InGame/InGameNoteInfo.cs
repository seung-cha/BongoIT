using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameNoteInfo : MonoBehaviour
{
    public bool isRightNote;
    public float desiredTickTime;

    public GameObject spawnPoint;
    public GameObject targetPoint;


    private void Awake()
    {
        
    }
    void Start()
    {
        this.gameObject.transform.position = spawnPoint.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
         float value = Mathf.InverseLerp(desiredTickTime - 4, desiredTickTime + 1, Tool.Tools.GetCurrentTimeInBeat(GetInfo.Info.audioSource.time, GetInfo.Info.data.offset, GetInfo.Info.spm));
        this.gameObject.transform.position = new Vector3(Mathf.Lerp(spawnPoint.transform.position.x, targetPoint.transform.position.x, value), targetPoint.transform.position.y, 0f);
    }
}
