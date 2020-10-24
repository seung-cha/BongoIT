using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.Networking;
using System.IO;
using System;
using SFB;


// BongoEditor
public class InputProvider : MonoBehaviour
{
  

    public TMP_InputField artistNameProvider;
    public TMP_InputField songNameProvider;
    public TMP_InputField bpmGetter;
    public TextMeshProUGUI musicState;
    public TextMeshProUGUI backgroundState;
    public UnityEngine.UI.Button musicImportButton;
    public UnityEngine.UI.Button confirmButton;

    public Toggle toggle;
    private bool showBackground;
    public UnityEngine.UI.Button offsetSetter;
    public GameObject inputPanel;

    public UnityEngine.UI.Button musicPlayerButton;

    private string imagePath;
    private string audioPath;
    private string audioExtension;
    private string backgroundString = "\\background.png";
    private string audioString = "\\music";


    public UnityEngine.UI.Button fowardBeat;
    public UnityEngine.UI.Button backwardBeat;


    public GameObject showInputPanel;

    private void Start()
    {
      songNameProvider.text = PathManager.DirectoryManager.targetName;

        StartCoroutine(GetImage(PathManager.DirectoryManager.targetFolderPath + backgroundString));
        StartCoroutine(GetImage(PathManager.DirectoryManager.targetFolderPath + audioString));
    }

    private void Update()
    {
        showBackground = toggle.isOn;
        if (InputHolder.Holder.audClip != null)
        {
            musicImportButton.interactable = false;
            confirmButton.interactable = true;
        }
        else
        {
            musicImportButton.interactable = true;
            confirmButton.interactable = false;
        }

        if (inputPanel.activeSelf == true)
            showInputPanel.SetActive(false);
        else
            showInputPanel.SetActive(true);

        if (showBackground)
            InputHolder.Holder.backgroundRenderer.gameObject.SetActive(true);
        else
            InputHolder.Holder.backgroundRenderer.gameObject.SetActive(false);


    }

    public void SetOffset()
    {
        InputHolder.Holder.rawOffset = InputHolder.Holder.musicPlayer.time;
        // InputHolder.Holder.offset = Tool.Tools.GetCurrentTimeInBeat(InputHolder.Holder.rawOffset, 0, 60 / InputHolder.Holder.bpm);
        /*
        float tempOffset = InputHolder.Holder.rawOffset - (int)InputHolder.Holder.rawOffset;
        // bpm correct it.
        float tempOffsetInBeat = PlaytimeToBeat(tempOffset, 60 / InputHolder.Holder.bpm);
        Debug.Log("tempoffset is " + tempOffsetInBeat);

        // this gets me only a decimal placed number such as 0.76
        float tempOffsetInBeatDecimal = tempOffsetInBeat - (int)tempOffsetInBeat;
        float value = 0;

        if (tempOffsetInBeatDecimal >= 0 || tempOffsetInBeatDecimal < 0.125)
            value = 0;
        else if (tempOffsetInBeatDecimal >= 0.125 || tempOffsetInBeatDecimal < 0.375)
            value = 0.25f;
        else if (tempOffsetInBeatDecimal >= 0.375 || tempOffsetInBeatDecimal < 0.625)
            value = 0.5f;
        else if (tempOffsetInBeatDecimal >= 0.625 || tempOffsetInBeatDecimal < 0.875)
            value = 0.75f;
        else
            value = 1;


        InputHolder.Holder.offset = ConvertFromBeatToPlaytime(tempOffset + value, 60 / InputHolder.Holder.bpm, 0);
        */


            //Debug code

        Debug.Log(InputHolder.Holder.rawOffset + " is now the new rawOffset");
       // Debug.Log(InputHolder.Holder.offset + " is now the new offset");
    }

    public void SetBPM()
    {
       float.TryParse(bpmGetter.text, out InputHolder.Holder.bpm);
    }

    public void ChangeAristName()
    {
        InputHolder.Holder.artistName = artistNameProvider.text;
    }
    public void ChangeSongName()
    {
        InputHolder.Holder.songName = songNameProvider.text;
    }


 

   


    public void OneBeatBack()
    {
        float spm = 60 / InputHolder.Holder.bpm;
        Debug.Log("beatBack called");
        if (InputHolder.Holder.bpm == 0 || Tool.Tools.GetCurrentTimeInBeat(InputHolder.Holder.musicPlayer.time, InputHolder.Holder.rawOffset, spm) < 0)
            return;


        float time = Tool.Tools.GridToTheNearestBeat(Tool.Tools.GetCurrentTimeInBeat(InputHolder.Holder.musicPlayer.time, InputHolder.Holder.rawOffset, spm), spm, InputHolder.Holder.rawOffset, false);
        Debug.Log(time);

        InputHolder.Holder.musicPlayer.time = time;


    }

    public void OneBeatFoward()
    {
        float spm = 60 / InputHolder.Holder.bpm;
        Debug.Log("beatFoward called");
        if (InputHolder.Holder.bpm == 0 || Tool.Tools.GetCurrentTimeInBeat(InputHolder.Holder.musicPlayer.time, InputHolder.Holder.rawOffset, spm) < 0)
            return;
        
        float time = Tool.Tools.GridToTheNearestBeat(Tool.Tools.GetCurrentTimeInBeat(InputHolder.Holder.musicPlayer.time, InputHolder.Holder.rawOffset, spm), spm, InputHolder.Holder.rawOffset, true);
        Debug.Log(time);

        InputHolder.Holder.musicPlayer.time = time;

    }

    public void OnMusicImportClick()
    {
        string path;
        /*
        System.Windows.Forms.OpenFileDialog fileDialog = new System.Windows.Forms.OpenFileDialog();
        fileDialog.Title = "Choose a music";
        fileDialog.Filter = "Music files (.ogg, .wav) | *.ogg; *.wav;";
        System.Windows.Forms.DialogResult result = fileDialog.ShowDialog();

        if (result == System.Windows.Forms.DialogResult.OK)
        {
            path = fileDialog.FileName;

            StartCoroutine(GetAudio(path));
        }
        */

        var extensions = new[] {
    new ExtensionFilter("Music files", "wav", "ogg")
};
        var paths = StandaloneFileBrowser.OpenFilePanel("Open File", "", extensions, false);

        StartCoroutine(GetAudio(paths[0]));

    }

    public void OnBackgroundImportClick()
    {
      


        string path;
        /*
        System.Windows.Forms.OpenFileDialog fileDialog = new System.Windows.Forms.OpenFileDialog();
        fileDialog.Title = "Choose a background image";
        fileDialog.Filter = "Image files (.png, .jpg) | *.jpg; *.png;";
        System.Windows.Forms.DialogResult result = fileDialog.ShowDialog();

        if (result == System.Windows.Forms.DialogResult.OK)
        {
            path = fileDialog.FileName;

            StartCoroutine(GetImage(path));
        }
       */

        var extensions = new[] {
    new ExtensionFilter("Image File", "png", "jpg" )
};
        var paths = StandaloneFileBrowser.OpenFilePanel("Choose a background image", "", extensions, false);

        if(paths.Length != 1)
            StartCoroutine(GetImage(paths[paths.Length -1]));
        else
        StartCoroutine(GetImage(paths[0]));



    }

    public void ConfirmChange()
    {
        InputHolder.Holder.artistName = artistNameProvider.text;
        InputHolder.Holder.songName = songNameProvider.text;

        float cameraheight = Camera.main.orthographicSize * 2;
        float camerawidth = cameraheight * Camera.main.aspect;

        // draw background image
        Debug.Log(Camera.main.aspect);
        if (InputHolder.Holder.backgroundTexture != null)
        {
            float worldScreenHeight = Camera.main.orthographicSize * 2;
            float worldScreenWidth = worldScreenHeight / UnityEngine.Screen.height * UnityEngine.Screen.width;

            Sprite bg = Sprite.Create(InputHolder.Holder.backgroundTexture, new Rect(0, 0,  InputHolder.Holder.backgroundTexture.width, InputHolder.Holder.backgroundTexture.height), Vector2.zero);

            InputHolder.Holder.backgroundRenderer.sprite = bg;
            float width = InputHolder.Holder.backgroundRenderer.sprite.bounds.size.x;
            float height = InputHolder.Holder.backgroundRenderer.sprite.bounds.size.y;

            InputHolder.Holder.imageContainer.transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 100));
            InputHolder.Holder.imageContainer.transform.localScale = new Vector3(worldScreenWidth / width, worldScreenHeight / height, 1);
        }

        if (InputHolder.Holder.musicPlayer.clip == null)
        {
            InputHolder.Holder.musicPlayer.clip = InputHolder.Holder.audClip;
            InputHolder.Holder.musicPlayer.time = 0.15f;
        }
        inputPanel.SetActive(false);

        //copy image if doesn't exist
        if (!Directory.Exists(PathManager.DirectoryManager.targetFolderPath + backgroundString) && imagePath != null)
            File.Copy(imagePath, PathManager.DirectoryManager.targetFolderPath + backgroundString, true);

        //copy audio if doesn't exist
        if (!Directory.Exists(PathManager.DirectoryManager.targetFolderPath + audioString + audioExtension))
            File.Copy(audioPath, PathManager.DirectoryManager.targetFolderPath + audioString + audioExtension, true);

    }


    public void PlayMusic()
    {
        InputHolder.Holder.musicPlayer.Play();
    }
    public void PauseMusic()
    {
        InputHolder.Holder.musicPlayer.Pause();
    }

    public void ShowPanel()
    {
        inputPanel.SetActive(true);
        InputHolder.Holder.musicPlayer.Pause();
    }

    IEnumerator GetImage(string path)
    {
        if (File.Exists(path))
        {
            if (!path.EndsWith(".png") || !path.EndsWith(".jpg"))
            {

                using (UnityWebRequest req = UnityWebRequestTexture.GetTexture(path))
                {
                    yield return req.SendWebRequest();

                    InputHolder.Holder.backgroundTexture = DownloadHandlerTexture.GetContent(req);
                    imagePath = path;
                    /*
                    float height = 2f * Camera.main.orthographicSize;
                    float width = height * Camera.main.aspect;
                    Sprite bg = Sprite.Create(InputHolder.Holder.backgroundTexture, new Rect(0, 0, width, height), Vector2.zero);
                    InputHolder.Holder.backgroundRenderer.sprite = bg;
                    InputHolder.Holder.imageContainer.transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 100));
                    */

                }
            }
        }
    }

    IEnumerator GetAudio(string path)
    {     
        if (path.EndsWith(".ogg"))
        {
            using (UnityWebRequest req = UnityWebRequestMultimedia.GetAudioClip(path, AudioType.OGGVORBIS))
            {
                yield return req.SendWebRequest();

                InputHolder.Holder.audClip = DownloadHandlerAudioClip.GetContent(req);
                audioPath = path;
                audioExtension = ".ogg";
            }
        }

        if (path.EndsWith(".wav"))
        {
            using (UnityWebRequest req = UnityWebRequestMultimedia.GetAudioClip(path, AudioType.WAV))
            {
                yield return req.SendWebRequest();

                InputHolder.Holder.audClip = DownloadHandlerAudioClip.GetContent(req);
                audioPath = path;
                audioExtension = ".wav";
            }
        }
    }
}


