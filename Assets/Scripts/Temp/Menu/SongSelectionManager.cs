using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class SongSelectionManager : MonoBehaviour
{
    public GameObject parentObject;
    public GameObject songObject;


    public Button selectButton;

    private void Awake()
    {
        if (FindObjectsOfType<PathManager>().Length == 0)
            Debug.Log("Cannot find path manager!");

        Debug.Log("Awake called");
    }
    void Start()
    {
       for(int i = 0; i < MaterialGetter.Get.beatInfos.Count; i++)
        {
            Debug.Log(MaterialGetter.Get.beatInfos[i].artistName);
            GameObject obj = Instantiate(songObject);
            obj.SetActive(false);
            obj.transform.SetParent(parentObject.transform);
            SelectContainer container = obj.GetComponent<SelectContainer>();
             container.artistName = MaterialGetter.Get.beatInfos[i].artistName;
             container.songName = MaterialGetter.Get.beatInfos[i].songName;
            container.image = MaterialGetter.Get.images[i];
            container.index = i;
            obj.SetActive(true);
            
        }

    }

    void Update()
    {
        if (MaterialGetter.Get.index != -1)
            selectButton.interactable = true;
        else
            selectButton.interactable = false;
    }
}
