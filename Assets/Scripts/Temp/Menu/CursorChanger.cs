using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using JetBrains.Annotations;
using UnityEngine.SceneManagement;

public class CursorChanger : MonoBehaviour
{
    public static CursorChanger CursorManager = null;
    

    public Texture2D defaultCursorImg;
    public Texture2D selectableCursorImg;
    public Texture2D clickCursorImg;

    private Texture2D currentCursorImg;

    public bool isOnEditMode;

    public enum MouseStats
    {
        idle,
        clickable,
        click
    }

    [SerializeField]
    private MouseStats currentMouseIs;

    private void Awake()
    {
        if (CursorManager == null)
        {
            CursorManager = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else if (CursorManager != null && CursorManager != this)
            Destroy(gameObject);


        


    }
    void Start()
    {
        currentMouseIs = MouseStats.idle;
        currentCursorImg = defaultCursorImg;
        Cursor.SetCursor(currentCursorImg,Vector2.zero, CursorMode.ForceSoftware);

        isOnEditMode = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2)
            isOnEditMode = true;
        else
            isOnEditMode = false;

        if (Input.GetMouseButton(0))
            currentMouseIs = MouseStats.click;

        if (Input.GetMouseButtonUp(0))
            currentMouseIs = MouseStats.idle;
            


        ChangeCursorReflectively();
    }

   void ChangeCursorReflectively()
    {
        if (!isOnEditMode)
        {
            if (currentMouseIs == MouseStats.idle)
            {
                // if(currentCursorImg != defaultCursorImg)
                //   {
                currentCursorImg = defaultCursorImg;
                Cursor.SetCursor(currentCursorImg, Vector2.zero, CursorMode.ForceSoftware);
                //  }
            }
            else if (currentMouseIs == MouseStats.clickable)
            {
                // if (currentCursorImg != selectableCursorImg)
                //  {
                currentCursorImg = selectableCursorImg;
                Cursor.SetCursor(currentCursorImg, Vector2.zero, CursorMode.ForceSoftware);
                //    }
            }
            else if (currentMouseIs == MouseStats.click)
            {
                //   if (currentCursorImg != clickCursorImg)
                //  {
                currentCursorImg = clickCursorImg;
                Cursor.SetCursor(currentCursorImg, Vector2.zero, CursorMode.ForceSoftware);
                //    }
            }
        }
        else
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);

    }

    public void OnCursorEnter()
    {
        currentMouseIs = MouseStats.clickable;
    }

    public void OnCursorExit()
    {
        currentMouseIs = MouseStats.idle;
    }
}
