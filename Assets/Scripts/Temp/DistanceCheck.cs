using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceCheck : MonoBehaviour
{
    public GameObject a;
    public GameObject b;
    void Start()
    {
        float distance = Vector2.Distance(a.transform.position, b.transform.position);
        distance /= 4;
        GameObject obj = new GameObject();
        obj.transform.position = new Vector3(a.transform.position.x - distance, a.transform.position.y, 0);


    }

   
    void Update()
    {
        
    }
}
