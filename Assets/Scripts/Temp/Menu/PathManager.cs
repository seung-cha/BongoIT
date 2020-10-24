using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.CompilerServices;
using System.Linq;

public class PathManager : MonoBehaviour
{
    public static PathManager DirectoryManager;

    public string targetFolderPath;
    public string targetName;

    public bool pathProcessed;
    public List<string> subPaths = new List<string>();
    public List<string> subPathName = new List<string>();

    public List<string> musicPaths = new List<string>();
    public List<string> imagePaths = new List<string>();
    public List<string> beatInfoPaths = new List<string>();

  //  public List<>
    public string songFolderPath
    { get; private set; }


   // { get; private set; }

    private void Awake()
    {
        if (DirectoryManager == null)
        {
            DirectoryManager = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else if (DirectoryManager != null && DirectoryManager != this)
            Destroy(gameObject);
    }
    void Start()
    {
        GetFile();
    }


   public void GetFile()
    {
        songFolderPath = Path.GetFullPath("./BongoSongList");
        if (!Directory.Exists(songFolderPath))
        {
            Debug.Log("SongFolder has been created");
            Directory.CreateDirectory(songFolderPath);
        }

        // Getting Path
        subPaths = Directory.GetDirectories(songFolderPath).ToList();
        subPathName.Clear();
        musicPaths.Clear();
        imagePaths.Clear();
        beatInfoPaths.Clear();
        foreach (string path in subPaths)
        {
            Debug.Log(path);
        }

        // Getting name Only
        foreach (string name in subPaths)
        {
            string temp = name;
            temp = name.Remove(0, songFolderPath.Length + 1);
            subPathName.Add(temp);
        }

        // Getting music Path
        foreach(string path in subPaths)
        {
            string temp = path+ "\\music.ogg";
            string wavPath = path + "\\music.wav";
            if (File.Exists(temp))
                musicPaths.Add(temp);
            else
                musicPaths.Add(wavPath);
        }

        // Getting Image path

        foreach(string path in subPaths)
        {
            string temp = path + "\\background.png";
            imagePaths.Add(temp);
        }

        //Getting bgit path

        foreach(string path in subPaths)
        {
            string temp = path + "\\beatData.bgit";
            beatInfoPaths.Add(temp);
        }
    }



   public bool GetTargetName(string name)
    {


        if (name.Length > 32 || name.Length == 0)
            return false;

        

        if (name.Contains('/') || name.Contains('\\') || name.Contains(':') || name.Contains('*') || name.Contains('?') || name.Contains('"') || name.Contains('<') || name.Contains('>') || name.Contains('|'))
            return false;


        for(int i = 0; i <subPaths.Count; i++)
        {
            if(subPathName.ElementAt(i) == name)
            {
                return false;
            }
        }
        


        return true;
    }

    public void CreateNewFolder(string name)
    {
        string temp = songFolderPath + "\\" + name;
        Directory.CreateDirectory(temp);
        targetFolderPath = temp;
        targetName = name;
        GetFile();
    }
}
