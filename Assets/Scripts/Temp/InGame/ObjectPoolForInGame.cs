using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPoolForInGame : MonoBehaviour
{
    public static ObjectPoolForInGame Pool;

    public GameObject poolContainer;

    public int amountToPool;

    public GameObject lNote;
    public GameObject rNote;


    public List<GameObject> lNotePool;
    public List<GameObject> rNotePool;

    public void Awake()
    {
        if (Pool == null)
            Pool = this;

        if (Pool != null && Pool != this)
            Destroy(this.gameObject);
    }
    void Start()
    {
        lNotePool = new List<GameObject>();
        rNotePool = new List<GameObject>();

        for(int i = 0; i <= amountToPool; i++ )
        {
            GameObject obj = Instantiate(lNote);
         //  obj.transform.parent = poolContainer.transform;
            obj.SetActive(false);
            lNotePool.Add(obj);
        }

        for (int i = 0; i <= amountToPool; i++)
        {
            GameObject obj = Instantiate(rNote);
            obj.GetComponent<InGameNoteInfo>().isRightNote = true;
           // obj.transform.parent = poolContainer.transform;
            obj.SetActive(false);
            rNotePool.Add(obj);
        }
    }

  public GameObject GetLNote()
    {
        for(int i = 0; i < lNotePool.Count; i++)
        {
            if(!lNotePool.ElementAt(i).activeInHierarchy)
            {
                return lNotePool.ElementAt(i);
            }
        }


        for(int i = 0; i < amountToPool / 2; i++)
        {
            GameObject obj = Instantiate(lNote);
            obj.transform.parent = poolContainer.transform;
            obj.SetActive(false);
            lNotePool.Add(obj);
        }


        return GetLNote();
    }


    public GameObject GetRNote()
    {
        for (int i = 0; i < rNotePool.Count; i++)
        {
            if (!rNotePool.ElementAt(i).activeInHierarchy)
            {
                return rNotePool.ElementAt(i);
            }
        }


        for (int i = 0; i < amountToPool / 2; i++)
        {
            GameObject obj = Instantiate(rNote);
            obj.transform.parent = poolContainer.transform;
            obj.SetActive(false);
            rNotePool.Add(obj);
        }


        return GetRNote();
    }
}
