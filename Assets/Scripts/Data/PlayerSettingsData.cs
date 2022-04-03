using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct PlayerSettingsData
{
    public float masterVol;
    public float environmentVol;
    public float weatherVol;
    public float effectVol;

    public bool masterMuted;
    public bool environmentMuted;
    public bool weatherMuted;
    public bool effectMuted;

    public void SetMuted(string audioGroup)
    {
        switch (audioGroup)
        {
            case "Master":
                masterMuted = true;
                break;
            case "Environment":
                environmentMuted = true;
                break;
            case "Weather":
                weatherMuted = true;
                break;
            case "Effect":
                effectMuted = true;
                break;
        }
    }
}
