using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BongoIt : MonoBehaviour
{
    public  GameObject[] idlePaws;
    public  GameObject[] hitPaws;
    public GameObject[] bongoCat;
    public AudioSource[] audSource;
    public bool isBongoTime;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.S))
        {
            idlePaws[0].SetActive(false);
            hitPaws[0].SetActive(true);
        }
        else
        {
            idlePaws[0].SetActive(true);
            hitPaws[0].SetActive(false);
        }


        if (Input.GetKey(KeyCode.K))
        {
            idlePaws[1].SetActive(false);
            hitPaws[1].SetActive(true);
        }
        else
        {
            idlePaws[1].SetActive(true);
            hitPaws[1].SetActive(false); 
        }

        if(isBongoTime)
        {
            bongoCat[0].SetActive(false);
            bongoCat[1].SetActive(true);
        }
        else
        {
            bongoCat[1].SetActive(false);
            bongoCat[0].SetActive(true);
        }



        if(Input.GetKeyDown(KeyCode.S))
        {
            audSource[0].Play();
        }

        if(Input.GetKeyDown(KeyCode.K))
        {
            audSource[1].Play();
        }
    }
}
