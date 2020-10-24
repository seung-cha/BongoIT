using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool PoolManager;

    [SerializeField]
    private int amountToPool;
    public List<GameObject> noteLPoolObjects;
    public List<GameObject> noteRPoolObjects;



    public GameObject noteParentObject;
    public GameObject noteL;
    public GameObject noteR;
    private void Awake()
    {
        PoolManager = this;
    }
    void Start()
    {
        noteLPoolObjects = new List<GameObject>();
        noteRPoolObjects = new List<GameObject>();

        for (int i = 0; i <= amountToPool; i++)
        {
            GameObject obj = Instantiate(noteL);
            obj.transform.parent = noteParentObject.transform;
            obj.transform.localScale = new Vector3(0.3f, 0.3f, 1);
            obj.transform.position = new Vector3(0, 0, 30);
            obj.SetActive(false);
            noteLPoolObjects.Add(obj);
        }

        for (int i = 0; i <= amountToPool; i++)
        {
            GameObject obj = Instantiate(noteR);
            obj.transform.parent = noteParentObject.transform;
            obj.transform.localScale = new Vector3(0.3f, 0.3f, 1);
            obj.SetActive(false);
            noteRPoolObjects.Add(obj);
        }


    }


    public GameObject GetLNote()
    {
        for (int i = 0; i < noteLPoolObjects.Count; i++)
        {
            if (!noteLPoolObjects[i].activeInHierarchy)
            {
                return noteLPoolObjects[i];
            }
        }


        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = Instantiate(noteL);
            obj.transform.parent = noteParentObject.transform;
            obj.transform.localScale = new Vector3(0.3f, 0.3f, 1);
            obj.transform.position = new Vector3(0, 0, 30);
            obj.SetActive(false);
            noteLPoolObjects.Add(obj);
        }

        return GetLNote();
    }

    public GameObject GetRNote()
    {
        for (int i = 0; i < noteRPoolObjects.Count; i++)
        {
            if (!noteRPoolObjects[i].activeInHierarchy)
            {
                return noteRPoolObjects[i];
            }
        }



        for (int i = 0; i <= amountToPool; i++)
        {
            GameObject obj = Instantiate(noteR);
            obj.transform.parent = noteParentObject.transform;
            obj.transform.localScale = new Vector3(0.3f, 0.3f, 1);
            obj.SetActive(false);
            noteRPoolObjects.Add(obj);
        }

        return GetRNote();
    }
}




     
 

