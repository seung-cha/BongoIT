using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextProvider : MonoBehaviour
{
    public TMP_InputField field;
    private bool isValid;
    public Button button;
    void Start()
    {
        
    }


    private void Update()
    {
        button.interactable = isValid;
    }
    public void ProvideText()
    {
        isValid =  PathManager.DirectoryManager.GetTargetName(field.text);
    }

    public void onCreateClick()
    {
        PathManager.DirectoryManager.CreateNewFolder(field.text);
    }
}
