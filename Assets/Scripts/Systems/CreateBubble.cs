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

    public void IncreaseField(string FieldToIncrease)
    {
        switch (FieldToIncrease)
        {
            case "Skybox":
                posInSkyboxArray++; 
                SelectSkyBox();
                break;
            case "Texture":
                posInTerrainArray++; 
                SelectTerrainTexture();
                break;
            case "DoF Focus Distance":
                GM.scenePostProcessingData.depthOfField.focusDistance.value++;
                break;
            case "DoF Focal Length":
                GM.scenePostProcessingData.depthOfField.focalLength.value++;
                break;
            case "DoF Aperture":
                GM.scenePostProcessingData.depthOfField.aperture.value++;
                break;
            case "Bloom Intensity":
                GM.scenePostProcessingData.bloom.intensity.value++;
                break;
            case "CA Post Exposure":
                GM.scenePostProcessingData.colorAdjustments.postExposure.value++;
                break;
            case "CA Contrast":
                GM.scenePostProcessingData.colorAdjustments.contrast.value++;
                break;
            case "CA Saturation":
                GM.scenePostProcessingData.colorAdjustments.saturation.value++;
                break;
            case "Tone Mapping Mode":
                break;
            case "Vig Intensity":
                GM.scenePostProcessingData.vignette.intensity.value++;
                break;
            case "Vig Smoothness":
                GM.scenePostProcessingData.vignette.smoothness.value++;
                break;
            case "Vig Rounded":
                break;
            case "WB Temperture":
                GM.scenePostProcessingData.whiteBalance.temperature.value++;
                break;
            case "WB Tint":
                GM.scenePostProcessingData.whiteBalance.tint.value++;
                break;
        }
    }

    public void DecreaseField(string FieldToDecrease)
    {
        switch(FieldToDecrease)
        {
            case "Skybox":
                posInSkyboxArray++;
                SelectSkyBox();
                break;
            case "Texture":
                posInTerrainArray++;
                SelectTerrainTexture();
                break;
            case "DoF Focus Distance":
                GM.scenePostProcessingData.depthOfField.focusDistance.value--;
                break;
            case "DoF Focal Length":
                GM.scenePostProcessingData.depthOfField.focalLength.value--;
                break;
            case "DoF Aperture":
                GM.scenePostProcessingData.depthOfField.aperture.value--;
                break;
            case "Bloom Intensity":
                GM.scenePostProcessingData.bloom.intensity.value--;
                break;
            case "CA Post Exposure":
                GM.scenePostProcessingData.colorAdjustments.postExposure.value--;
                break;
            case "CA Contrast":
                GM.scenePostProcessingData.colorAdjustments.contrast.value--;
                break;
            case "CA Saturation":
                GM.scenePostProcessingData.colorAdjustments.saturation.value--;
                break;
            case "Tone Mapping Mode":
                break;
            case "Vig Intensity":
                GM.scenePostProcessingData.vignette.intensity.value--;
                break;
            case "Vig Smoothness":
                GM.scenePostProcessingData.vignette.smoothness.value--;
                break;
            case "Vig Rounded":
                break;
            case "WB Temperture":
                GM.scenePostProcessingData.whiteBalance.temperature.value--;
                break;
            case "WB Tint":
                GM.scenePostProcessingData.whiteBalance.tint.value--;
                break;
        }
    }


    void SelectSkyBox()
    {
        if (posInSkyboxArray >= GM.Skyboxes.Length) { currentSkybox = GM.Skyboxes[GM.Skyboxes.Length - 1]; }
        else if (posInSkyboxArray < 0) { currentSkybox = GM.Skyboxes[0]; }
        else { currentSkybox = GM.Skyboxes[posInSkyboxArray]; }

        skyboxTxt.text = currentSkybox.name;
    }

    void SelectTerrainTexture()
    {
        if (posInTerrainArray >= GM.TerrainTextures.Length) { currentTerrainTexture = GM.TerrainTextures[GM.TerrainTextures.Length - 1]; }
        else if (posInTerrainArray < 0) { currentTerrainTexture = GM.TerrainTextures[0]; }
        else { currentTerrainTexture = GM.TerrainTextures[posInTerrainArray]; }

        terrainTxt.text = currentTerrainTexture.name;
    }
}
