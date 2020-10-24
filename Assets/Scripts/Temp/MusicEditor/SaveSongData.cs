using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSongData : MonoBehaviour
{
    public void OnSaveDataClick()
    {
        Tool.Tools.SaveBeatInfo(InputHolder.Holder.artistName, InputHolder.Holder.songName, InputHolder.Holder.rawOffset, InputHolder.Holder.bpm, InputHolder.Holder.beatPositionDictionary, InputHolder.Holder.highLight, PathManager.DirectoryManager.targetFolderPath);
    }
}
