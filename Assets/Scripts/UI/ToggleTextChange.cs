using UnityEngine;
using UnityEngine.UI;
using TSGameDev.Managers;

public class ToggleTextChange : MonoBehaviour
{
    #region Private Variables

    [SerializeField] Text toggleTxt;
    
    AudioManager audioManager;
    GameManager gameManager;
    Toggle toggle;

    #endregion

    // Awake function called before start but after variable inisitalisation
    void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
        gameManager = FindObjectOfType<GameManager>();
        toggle = GetComponent<Toggle>();
    }

    /// <summary>
    /// Function to change the toggle text of a toggle for better readability. Also mutes the passed in audio group
    /// </summary>
    /// <param name="audioGroup">The audio group within the audio mixer to mute</param>
    public void TextColourChange(string audioGroup)
    {
        toggleTxt.color = toggle.isOn ? Color.black : Color.white;
        gameManager.playerSettingsData.SetMuted(audioGroup, toggle.isOn);
        audioManager.PlayerMuteAudioGroup(audioGroup, toggle.isOn);
    }
}
