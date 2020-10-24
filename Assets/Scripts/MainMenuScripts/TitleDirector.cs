using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleDirector : MonoBehaviour
{
    public GameObject itself;
    public GameObject playDestination;
    public GameObject changeDestionation;

    private void Awake()
    {
        if (!(this.gameObject.transform.parent.name == "Canvas"))
            this.gameObject.transform.parent = GameObject.Find("Canvas").transform;
    }
    public void DestroyThis()
    {
        Destroy(itself);
    }
   public void OnPlayClick()
    {       
      Instantiate(playDestination);
        DestroyThis();
    }

    public void OnChangeClick()
    {       
        Instantiate(changeDestionation);
        DestroyThis();
    }

    public void OnQuitClick()
    {
        Application.Quit();
    }
}
