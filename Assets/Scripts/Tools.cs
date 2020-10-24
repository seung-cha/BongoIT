using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace Tool
{
    public static class Tools
    {
        public static float GetCurrentTimeInBeat(float time, float offset, float spb)
        { return (time - offset) / spb; }

        public static float BeatToPlaytime(float posInBeat, float spb, float offset)
        { return posInBeat * spb + offset; }

        public static float GridToTheNearestBeat(float posInBeat, float spb, float offset, bool up)
        {
            //This well only get decimal places.
            float temp = posInBeat - (int)posInBeat;
            float roundedTemp = (float)Math.Round(temp, 2);
            float value = 0;
            Debug.Log(temp);
            Debug.Log(roundedTemp);

            if (up)
            {
                if (roundedTemp == 1f)
                {
                    Debug.Log(" 1 called");
                    value = 1.25f;
                    return BeatToPlaytime((int)posInBeat + value, spb, offset);
                }


                if (roundedTemp < 0.25f && roundedTemp >= 0f)
                {
                    Debug.Log(" 0.25 called");
                    value = 0.25f;
                    return BeatToPlaytime((int)posInBeat + value, spb, offset);
                }
                else if (roundedTemp < 0.5f && roundedTemp >= 0.25f)
                {
                    Debug.Log(" 0.5 called");
                    value = 0.5f;

                    return BeatToPlaytime((int)posInBeat + value, spb, offset);
                }
                else if (roundedTemp < 0.75f && roundedTemp >= 0.5f)
                {
                    Debug.Log(" 0.75 called");
                    value = 0.75f;
                    return BeatToPlaytime((int)posInBeat + value, spb, offset);
                }
                else if (roundedTemp < 0.1f && roundedTemp >= 0.75f)
                {
                    Debug.Log(" 1 called");
                    value = 1f;
                    return BeatToPlaytime((int)posInBeat + value, spb, offset);
                }
                else
                {
                    Debug.Log("else 0.25 called");
                    value = 1f;
                    return BeatToPlaytime((int)posInBeat + value, spb, offset);
                }
            }
            else
            {
                if (roundedTemp == 0f)
                {
                    Debug.Log(" 1 called");
                    value = -0.25f;
                    return BeatToPlaytime((int)posInBeat + value, spb, offset);
                }


                if (roundedTemp <= 0.25f && roundedTemp > 0f)
                {
                    Debug.Log(" 0.25 called");
                    value = 0f;
                    return BeatToPlaytime((int)posInBeat + value, spb, offset);
                }
                else if (roundedTemp <= 0.5f && roundedTemp > 0.25f)
                {
                    Debug.Log(" 0.5 called");
                    value = 0.25f;

                    return BeatToPlaytime((int)posInBeat + value, spb, offset);
                }
                else if (roundedTemp <= 0.75f && roundedTemp > 0.5f)
                {
                    Debug.Log(" 0.75 called");
                    value = 0.5f;
                    return BeatToPlaytime((int)posInBeat + value, spb, offset);
                }
                else if (roundedTemp <= 0.1f && roundedTemp > 0.75f)
                {
                    Debug.Log(" 1 called");
                    value = 0.75f;
                    return BeatToPlaytime((int)posInBeat + value, spb, offset);
                }
                else
                {
                    Debug.Log("else 0.25 called");
                    value = 0.75f;
                    return BeatToPlaytime((int)posInBeat + value, spb, offset);
                }

            }
        }

        public static float SnapToTheNearestBeat(float timeInBeat)
        {
            float decimalNum = timeInBeat - (int)timeInBeat;



            if (decimalNum < 0.125)
                return (int)timeInBeat;
            else if (decimalNum >= 0.125 && decimalNum < 0.375)
                return (int)timeInBeat + 0.25f;
            else if (decimalNum >= 0.375 && decimalNum < 0.625)
                return (int)timeInBeat + 0.5f;
            else if (decimalNum >= 0.625 && decimalNum < 0.875)
                return (int)timeInBeat + 0.75f;
            else
                return (int)timeInBeat + 1f;
        }

        public static void SaveBeatInfo(string artistName, string songName, float offset, float bpm, Dictionary<float, bool> beatInfo, float highLight, string PathWithoutExtension)
        {
            float[] tempKeyContainer;
            bool[] tempValueContainer;


            tempKeyContainer = beatInfo.Keys.ToArray();
            tempValueContainer = beatInfo.Values.ToArray();

            BinaryFormatter formatter = new BinaryFormatter();
            string path = PathWithoutExtension + "\\beatData.bgit";
            FileStream stream = new FileStream(path, FileMode.Create);

           SongDataForm dataForm = new SongDataForm(artistName, songName, offset, bpm, tempKeyContainer, tempValueContainer, highLight);
            formatter.Serialize(stream, dataForm);
            stream.Close();
        }

        public static SongDataForm LoadBeatInfo(string PathWithExtension)
        {
            string path = PathWithExtension;

            if (!File.Exists(path))
            { return null; }

            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            SongDataForm data = formatter.Deserialize(stream) as SongDataForm;
            stream.Close();
            return data;

        }

    }
}
