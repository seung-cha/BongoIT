using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FindButtonRequirements : MonoBehaviour
{
    private EventTrigger trigger;

    private void Awake()
    {
        trigger = GetComponent<EventTrigger>();
    }
    void Start()
    {
        
    }

}
