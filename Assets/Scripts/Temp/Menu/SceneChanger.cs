using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
   public static SceneChanger SceneProcessor;

    private void Awake()
    {
        if (SceneProcessor == null)
            SceneProcessor = this;
        else if (SceneProcessor != null && SceneProcessor != this)
            Destroy(gameObject);

        DontDestroyOnLoad(this);
    }
    public void ChangeScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }


}
