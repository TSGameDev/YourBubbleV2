using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TSGameDev.Managers;

public class ToggleTextChange : MonoBehaviour
{
    [SerializeField] Text toggleTxt;
    
    AudioManager audioManager;
    Toggle toggle;
    

    // Start is called before the first frame update
    void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
        toggle = GetComponent<Toggle>();
    }

    public void TextColourChange(string audioGroup)
    {
        toggleTxt.color = toggle.isOn ? Color.black : Color.white;
        audioManager.playerSettingsData.SetMuted(audioGroup, toggle.isOn);
        audioManager.PlayerMuteAudioGroup(audioGroup, toggle.isOn);
        Debug.Log($"Master Mute: {audioManager.playerSettingsData.masterMuted} " +
            $"Environment Mute: {audioManager.playerSettingsData.environmentMuted} " +
            $"Weather Mute: {audioManager.playerSettingsData.weatherMuted} " +
            $"Effect Mute: {audioManager.playerSettingsData.effectMuted}");
    }
}
