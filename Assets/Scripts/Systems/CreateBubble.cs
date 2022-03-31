using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using TSGameDev.Managers;

public class CreateBubble : MonoBehaviour
{
    #region Private Variables

    [Header("Environment Texts")]
    [SerializeField] TextMeshProUGUI skyboxTxt;
    [SerializeField] TextMeshProUGUI terrainTxt;
    [Space(10)]

    [Header("Post Processing Texts")]
    [SerializeField] TextMeshProUGUI DOFFocusDistanceTxt;
    [SerializeField] TextMeshProUGUI DOFFocalLengthTxt;
    [SerializeField] TextMeshProUGUI DOFAppertureTxt;
    [Space(5)]

    [SerializeField] TextMeshProUGUI bloomIntensityTxt;
    [SerializeField] TextMeshProUGUI bloomScatterTxt;
    [SerializeField] TextMeshProUGUI bloomTintTxt;
    [Space(5)]

    [SerializeField] TextMeshProUGUI colourPostExposureTxt;
    [SerializeField] TextMeshProUGUI colourContrastTxt;
    [SerializeField] TextMeshProUGUI colourSaturationTxt;
    [Space(5)]

    [SerializeField] TextMeshProUGUI toneMappingModeTxt;
    [Space(5)]

    [SerializeField] TextMeshProUGUI vignetteIntensityTxt;
    [SerializeField] TextMeshProUGUI vignetteSmoothnessTxt;
    [SerializeField] TextMeshProUGUI vignetteRoundedTxt;
    [Space(5)]

    [SerializeField] TextMeshProUGUI whiteBalanceTemperatureTxt;
    [SerializeField] TextMeshProUGUI whiteBalanceTintTxt;

    GameManager GM;

    Material currentSkybox;
    int posInSkyboxArray = 0;

    Material currentTerrainTexture;
    int posInTerrainArray = 0;

    #endregion

    private void Awake()
    {
        GM = FindObjectOfType<GameManager>();
        SelectSkyBox();
        SelectTerrainTexture();
    }

    public void ForwardSkybox() { posInSkyboxArray++; SelectSkyBox(); }

    public void BackwardSkybox() { posInSkyboxArray--; SelectSkyBox(); }

    void SelectSkyBox() 
    {
        if (posInSkyboxArray >= GM.Skyboxes.Length) { currentSkybox = GM.Skyboxes[GM.Skyboxes.Length - 1]; }
        else if (posInSkyboxArray < 0) { currentSkybox = GM.Skyboxes[0]; }
        else { currentSkybox = GM.Skyboxes[posInSkyboxArray]; }

        skyboxTxt.text = currentSkybox.name;
    }

    public void ForwardTerrainTexture() { posInTerrainArray++; SelectTerrainTexture(); }

    public void BackwardTerrainTexture() { posInTerrainArray--; SelectTerrainTexture(); }

    public void SelectTerrainTexture() 
    {
        if (posInTerrainArray >= GM.TerrainTextures.Length) { currentTerrainTexture = GM.TerrainTextures[GM.TerrainTextures.Length - 1]; }
        else if (posInTerrainArray < 0) { currentTerrainTexture = GM.TerrainTextures[0]; }
        else { currentTerrainTexture = GM.TerrainTextures[posInTerrainArray]; }

        terrainTxt.text = currentTerrainTexture.name;
    }

    
}
