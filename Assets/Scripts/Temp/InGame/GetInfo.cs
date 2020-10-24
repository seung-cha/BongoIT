using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Tool;
using UnityEngine;

public class GetInfo : MonoBehaviour
{

    public static GetInfo Info;
    public SongDataForm data;
    public AudioSource audioSource;
    public Sprite backgroundImage;


    public Dictionary<float, bool> beatInfo;
    public float spm;

    private int currentBeatIndex;

    [SerializeField]
    private float playTimeInBeat;
    [SerializeField]
    private bool canSkip;


  //  private bool canExit;
    void Awake()
    {

        if (Info == null)
            Info = this;
        if (Info != null && Info != this)
            Destroy(this.gameObject);



        data = MaterialGetter.Get.beatInfos[MaterialGetter.Get.index];
        beatInfo = new Dictionary<float, bool>();
    }

    private void Start()
    {

        currentBeatIndex = 0;


        for (int i = 0; i < data.keys.Length; i++)
        {
            Debug.Log(data.keys[i]);
            Debug.Log(data.values[i]);
        }
        
     
        
        for (int i = 0; i < data.keys.Length; i++)
        {
            beatInfo.Add(data.keys[i], data.values[i]);
        }

     
        audioSource.clip = MaterialGetter.Get.audioClips[MaterialGetter.Get.index];
        backgroundImage = MaterialGetter.Get.images[MaterialGetter.Get.index];


        spm = 60 / data.bpm;
        audioSource.Play();






        DoSpawn();
    }


    void Update()
    {
        PlayAudio.UniversalAudioPlayer.musicPlayer.time = audioSource.time;

        
        playTimeInBeat = Tools.GetCurrentTimeInBeat(audioSource.time, data.offset, spm);
        canSkip = playTimeInBeat < (beatInfo.ElementAt(0).Key - 5 );

        if(canSkip)
        {
            if(Input.GetKeyDown(KeyCode.LeftControl))
            audioSource.time = Tools.BeatToPlaytime(beatInfo.ElementAt(0).Key - 5, spm, data.offset);
        }

        if (Input.GetKeyDown(KeyCode.Space))
            SceneChanger.SceneProcessor.ChangeScene(1);
    }



    private void DoSpawn()
    {
      foreach(KeyValuePair<float, bool> pair in beatInfo)
        {
            GameObject obj;
            if (pair.Value)
            {
                obj = ObjectPoolForInGame.Pool.GetRNote();
            }
            else
            {
                obj = ObjectPoolForInGame.Pool.GetLNote();
            }
            obj.GetComponent<InGameNoteInfo>().desiredTickTime = pair.Key;
            obj.SetActive(true);
        }
    }
    private void OnDestroy()
    {
        PlayAudio.UniversalAudioPlayer.musicPlayer.Play();
    }
}
