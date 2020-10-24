using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

// BongoEditor

    public class InputHolder : MonoBehaviour
    {
        public static InputHolder Holder;

        private void Awake()
        {
            if (Holder == null)
                Holder = this;
            else if (Holder != null && Holder != this)
                Destroy(gameObject);
        }

    private void Start()
    {
        musicPlayer.time = 0.015f;
    }

    public string artistName;
        public string songName;
    public float bpm;

    public float rawOffset;
    public float highLight;
  //  public List<float> LbeatPosition = new List<float>();
   // public List<float> RbeatPosition = new List<float>();

    // float value indicates the beat and bool indicates whether the beat is L or R.
    public Dictionary<float, bool> beatPositionDictionary = new Dictionary<float, bool>();

    #region background
    public Texture2D backgroundTexture;
        public SpriteRenderer backgroundRenderer;
        public GameObject imageContainer;
        public AudioClip audClip;
        public AudioSource musicPlayer;

    #endregion

}

