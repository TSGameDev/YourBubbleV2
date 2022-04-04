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

    public void SetMuted(string audioGroup, bool toggleValue)
    {
        switch (audioGroup)
        {
            case "Master":
                masterMuted = toggleValue;
                break;
            case "Environment":
                environmentMuted = toggleValue;
                break;
            case "Weather":
                weatherMuted = toggleValue;
                break;
            case "Effect":
                effectMuted = toggleValue;
                break;
        }
    }
}
