using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetHighlight : MonoBehaviour
{
    public TextMeshProUGUI highlightTime;

   public void SetCurrentTimeHighlight()
    {
        InputHolder.Holder.highLight = InputHolder.Holder.musicPlayer.time;
        highlightTime.text = Convert.ToString(TimeSpan.FromSeconds(InputHolder.Holder.highLight));
    }
}
