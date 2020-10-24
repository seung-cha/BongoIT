using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;

public class MaterialGetter : MonoBehaviour
{
    public static MaterialGetter Get;

    public Dictionary<int,AudioClip> audioClips = new Dictionary<int, AudioClip>();
    public Dictionary<int, Sprite> images = new Dictionary<int, Sprite>();
    public Dictionary<int, SongDataForm> beatInfos = new Dictionary<int, SongDataForm>();


    public int index;
    private void Awake()
    {
        if (Get == null)
        {
            Get = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else if (Get != null && Get != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        for(int i = 0; i < PathManager.DirectoryManager.musicPaths.Count; i++)
        {
            StartCoroutine(GetAudio(PathManager.DirectoryManager.musicPaths.ElementAt(i), i));
        }
        for (int i = 0; i < PathManager.DirectoryManager.imagePaths.Count; i++)
        {
            StartCoroutine(GetImage(PathManager.DirectoryManager.imagePaths.ElementAt(i), i));
        }
        for (int i = 0; i < PathManager.DirectoryManager.beatInfoPaths.Count; i++)
        {
            GetBgit(PathManager.DirectoryManager.beatInfoPaths.ElementAt(i), i);
        }

      
        index = -1;
    }

 


    
    IEnumerator GetAudio(string path, int index)
    {
        if (path.EndsWith(".ogg")) {
            using (UnityWebRequest req = UnityWebRequestMultimedia.GetAudioClip(path, AudioType.OGGVORBIS))
            {
                yield return req.SendWebRequest();

                audioClips.Add(index, DownloadHandlerAudioClip.GetContent(req));            
            }
        }
        else
        {
            using (UnityWebRequest req = UnityWebRequestMultimedia.GetAudioClip(path, AudioType.WAV))
            {
                yield return req.SendWebRequest();
                audioClips.Add( index,DownloadHandlerAudioClip.GetContent(req));           
            }
        }
    }

    IEnumerator GetImage(string path, int index)
    {
        if (File.Exists(path))
        {
            using (UnityWebRequest req = UnityWebRequestTexture.GetTexture(path))
            {
                yield return req.SendWebRequest();
                Texture2D texture = DownloadHandlerTexture.GetContent(req);
                Sprite img = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
                images.Add(index, img);
            }
        }
        else
            images.Add(index, null);
    }

    private void GetBgit(string path, int index)
    {
        beatInfos.Add(index, Tool.Tools.LoadBeatInfo(path));
    }
}
