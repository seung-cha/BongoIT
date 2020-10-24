using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SongDataForm
{
   public string artistName;
    public string songName;
    public float offset;
    public float bpm;
    public float highLight;
    public bool[] values;
       public  float[] keys;

    public SongDataForm(string ArtistName, string SongName, float Offset, float Bpm, float[] key, bool[] value, float HighLight)
    {
        artistName = ArtistName;
        songName = SongName;
        offset = Offset;
        bpm = Bpm;      
        highLight = HighLight;

        values = value;
        keys = key;

    }


}
