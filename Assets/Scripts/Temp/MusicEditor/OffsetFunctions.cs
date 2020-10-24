using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffsetFunctions : MonoBehaviour
{
    public GameObject offsetFunction;
    void Update()
    {
        if (InputHolder.Holder.rawOffset != 0)
            offsetFunction.SetActive(true);
        else
            offsetFunction.SetActive(false);
    }

    public void ResetOffset()
    {
        InputHolder.Holder.rawOffset = 0;
    }

    public void GotoOffset()
    {
        if (InputHolder.Holder.musicPlayer.isPlaying)
            InputHolder.Holder.musicPlayer.Pause();

        InputHolder.Holder.musicPlayer.time = InputHolder.Holder.rawOffset;
    }
}
