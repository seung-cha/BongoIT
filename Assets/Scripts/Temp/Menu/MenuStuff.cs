using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuStuff : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject gameSelection;
    public GameObject MakeChoice;
    public GameObject provideInfo;


    private void Start()
    {
        DefaultSettings();
    }

    private void DefaultSettings()
    {
        mainMenu.SetActive(true);
        gameSelection.SetActive(false);
        MakeChoice.SetActive(false);
        provideInfo.SetActive(false);
    }
    public void onStartClick()
    {
        mainMenu.SetActive(false);
        gameSelection.SetActive(true);
    }

    public void onBackFromStartClick()
    {
        mainMenu.SetActive(true);
        gameSelection.SetActive(false);
    }
  
    public void onMakeClick()
    {
        MakeChoice.SetActive(true);
        gameSelection.SetActive(false);
    }

    public void onBackClickFromMake()
    {
        MakeChoice.SetActive(false);
        gameSelection.SetActive(true);
    }

    public void onBackClickFromProvideInfo()
    {
        provideInfo.SetActive(false);
        MakeChoice.SetActive(true);
    }
    public void onMakeNewClick()
    {
        provideInfo.SetActive(true);
        MakeChoice.SetActive(false);
    }

    public void onMakeFromExistingClick()
    {

    }
    public void onGameStartClick()
    {
        SceneManager.LoadScene(1);
    }

    public void OnQuitClick()
    {
        Application.Quit();
    }
}
