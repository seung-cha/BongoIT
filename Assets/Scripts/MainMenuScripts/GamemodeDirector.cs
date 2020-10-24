using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamemodeDirector : MonoBehaviour
{
    public GameObject backDestination;
    public GameObject makeDestination;
    void Awake()
    {
        if (!(this.gameObject.transform.parent.name == "Canvas"))
            this.gameObject.transform.parent = GameObject.Find("Canvas").transform;
    }

    // Update is called once per frame
   public void OnPlayClick()
    {
        SceneChanger.SceneProcessor.ChangeScene(1);
    }

    public void OnMakeClick()
    {
        Instantiate(makeDestination);
    }
}
