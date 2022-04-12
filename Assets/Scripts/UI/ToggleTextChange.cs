using UnityEngine;
using UnityEngine.UI;
using TSGameDev.Managers;

public class ToggleTextChange : MonoBehaviour
{
    #region Private Variables

    [SerializeField] Text toggleTxt;
    
    AudioManager audioManager;
    Toggle toggle;

    #endregion

    // Awake function called before start but after variable inisitalisation
    void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
        toggle = GetComponent<Toggle>();
    }

    //function to change the text colour on toggles so the text is readable
    public void TextColourChange(string audioGroup)
    {
        toggleTxt.color = toggle.isOn ? Color.black : Color.white;
        audioManager.playerSettingsData.SetMuted(audioGroup, toggle.isOn);
        audioManager.PlayerMuteAudioGroup(audioGroup, toggle.isOn);
    }
}
