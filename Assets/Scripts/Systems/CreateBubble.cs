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

    int posInToneMappingArray = 0;
    UnityEngine.Rendering.Universal.TonemappingMode[] TonemappingModes = 
        { UnityEngine.Rendering.Universal.TonemappingMode.None, 
        UnityEngine.Rendering.Universal.TonemappingMode.Neutral, 
        UnityEngine.Rendering.Universal.TonemappingMode.ACES };

    #endregion

    private void Awake()
    {
        GM = FindObjectOfType<GameManager>();
        SelectSkyBox();
        SelectTerrainTexture();
    }

    public void IncreaseField(string FieldToIncrease)
    {
        ScenePostProcessingData postProcessingData = GM.scenePostProcessingData;
        switch (FieldToIncrease)
        {
            case "Skybox":
                posInSkyboxArray++; 
                SelectSkyBox();
                skyboxTxt.text = currentSkybox.name;
                break;
            case "Texture":
                posInTerrainArray++; 
                SelectTerrainTexture();
                terrainTxt.text = currentTerrainTexture.name;
                break;
            case "DoF Focus Distance":
                postProcessingData.depthOfField.focusDistance.value++;
                DOFFocusDistanceTxt.text = Mathf.RoundToInt(postProcessingData.depthOfField.focusDistance.value).ToString();
                break;
            case "DoF Focal Length":
                postProcessingData.depthOfField.focalLength.value++;
                DOFFocalLengthTxt.text = postProcessingData.depthOfField.focalLength.value.ToString();
                break;
            case "DoF Aperture":
                postProcessingData.depthOfField.aperture.value++;
                DOFAppertureTxt.text = postProcessingData.depthOfField.aperture.value.ToString();
                break;
            case "Bloom Intensity":
                postProcessingData.bloom.intensity.value++;
                bloomIntensityTxt.text = postProcessingData.bloom.intensity.value.ToString();
                break;
            case "CA Post Exposure":
                postProcessingData.colorAdjustments.postExposure.value++;
                colourPostExposureTxt.text = postProcessingData.colorAdjustments.postExposure.value.ToString();
                break;
            case "CA Contrast":
                postProcessingData.colorAdjustments.contrast.value++;
                colourContrastTxt.text = postProcessingData.colorAdjustments.contrast.value.ToString();
                break;
            case "CA Saturation":
                postProcessingData.colorAdjustments.saturation.value++;
                colourSaturationTxt.text = postProcessingData.colorAdjustments.saturation.value.ToString();
                break;
            case "Tone Mapping Mode":
                posInToneMappingArray++;
                SelectToneMappingMode(postProcessingData);
                break;
            case "Vig Intensity":
                postProcessingData.vignette.intensity.value += 0.1f;
                vignetteIntensityTxt.text = postProcessingData.vignette.intensity.value.ToString();
                break;
            case "Vig Smoothness":
                postProcessingData.vignette.smoothness.value += 0.1f;
                vignetteSmoothnessTxt.text = postProcessingData.vignette.smoothness.value.ToString();
                break;
            case "Vig Rounded":
                postProcessingData.vignette.rounded.value = true;
                vignetteRoundedTxt.text = postProcessingData.vignette.rounded.value.ToString();
                break;
            case "WB Temperture":
                postProcessingData.whiteBalance.temperature.value++;
                whiteBalanceTemperatureTxt.text = postProcessingData.whiteBalance.temperature.value.ToString();
                break;
            case "WB Tint":
                postProcessingData.whiteBalance.tint.value++;
                whiteBalanceTintTxt.text = postProcessingData.whiteBalance.tint.value.ToString();
                break;
        }
    }

    public void DecreaseField(string FieldToDecrease)
    {
        ScenePostProcessingData postProcessingData = GM.scenePostProcessingData;
        switch (FieldToDecrease)
        {
            case "Skybox":
                posInSkyboxArray--;
                SelectSkyBox();
                skyboxTxt.text = currentSkybox.name;
                break;
            case "Texture":
                posInTerrainArray--;
                SelectTerrainTexture();
                terrainTxt.text = currentTerrainTexture.name;
                break;
            case "DoF Focus Distance":
                postProcessingData.depthOfField.focusDistance.value--;
                DOFFocusDistanceTxt.text = Mathf.RoundToInt(postProcessingData.depthOfField.focusDistance.value).ToString();
                break;
            case "DoF Focal Length":
                postProcessingData.depthOfField.focalLength.value--;
                DOFFocalLengthTxt.text = postProcessingData.depthOfField.focalLength.value.ToString();
                break;
            case "DoF Aperture":
                postProcessingData.depthOfField.aperture.value--;
                DOFAppertureTxt.text = postProcessingData.depthOfField.aperture.value.ToString();
                break;
            case "Bloom Intensity":
                postProcessingData.bloom.intensity.value--;
                bloomIntensityTxt.text = postProcessingData.bloom.intensity.value.ToString();
                break;
            case "CA Post Exposure":
                postProcessingData.colorAdjustments.postExposure.value--;
                colourPostExposureTxt.text = postProcessingData.colorAdjustments.postExposure.value.ToString();
                break;
            case "CA Contrast":
                postProcessingData.colorAdjustments.contrast.value--;
                colourContrastTxt.text = postProcessingData.colorAdjustments.contrast.value.ToString();
                break;
            case "CA Saturation":
                postProcessingData.colorAdjustments.saturation.value--;
                colourSaturationTxt.text = postProcessingData.colorAdjustments.saturation.value.ToString();
                break;
            case "Tone Mapping Mode":
                posInToneMappingArray--;
                SelectToneMappingMode(postProcessingData);
                break;
            case "Vig Intensity":
                postProcessingData.vignette.intensity.value -= 0.1f;
                vignetteIntensityTxt.text = postProcessingData.vignette.intensity.value.ToString();
                break;
            case "Vig Smoothness":
                postProcessingData.vignette.smoothness.value -= 0.1f;
                vignetteSmoothnessTxt.text = postProcessingData.vignette.smoothness.value.ToString();
                break;
            case "Vig Rounded":
                postProcessingData.vignette.rounded.value = false;
                vignetteRoundedTxt.text = postProcessingData.vignette.rounded.value.ToString();
                break;
            case "WB Temperture":
                postProcessingData.whiteBalance.temperature.value--;
                whiteBalanceTemperatureTxt.text = postProcessingData.whiteBalance.temperature.value.ToString();
                break;
            case "WB Tint":
                postProcessingData.whiteBalance.tint.value--;
                whiteBalanceTintTxt.text = postProcessingData.whiteBalance.tint.value.ToString();
                break;
        }
    }


    void SelectSkyBox()
    {
        if (posInSkyboxArray >= GM.Skyboxes.Length) { currentSkybox = GM.Skyboxes[GM.Skyboxes.Length - 1]; posInSkyboxArray = GM.Skyboxes.Length - 1; }
        else if (posInSkyboxArray < 0) { currentSkybox = GM.Skyboxes[0]; posInSkyboxArray = 0; }
        else { currentSkybox = GM.Skyboxes[posInSkyboxArray]; }
    }

    void SelectTerrainTexture()
    {
        if (posInTerrainArray >= GM.TerrainTextures.Length) { currentTerrainTexture = GM.TerrainTextures[GM.TerrainTextures.Length - 1]; posInTerrainArray = GM.TerrainTextures.Length - 1; }
        else if (posInTerrainArray < 0) { currentTerrainTexture = GM.TerrainTextures[0]; posInTerrainArray = 0; }
        else { currentTerrainTexture = GM.TerrainTextures[posInTerrainArray]; }
    }

    void SelectToneMappingMode(ScenePostProcessingData postProcessingData)
    {
        if (posInToneMappingArray >= TonemappingModes.Length - 1) 
        { 
            postProcessingData.toneMapping.mode.value = TonemappingModes[TonemappingModes.Length - 1]; 
            posInToneMappingArray = TonemappingModes.Length - 1;
            toneMappingModeTxt.text = "ACES";
        }
        else if (posInToneMappingArray <= 0) 
        { 
            postProcessingData.toneMapping.mode.value = TonemappingModes[0]; 
            posInToneMappingArray = 0;
            toneMappingModeTxt.text = "None";
        }
        else 
        { 
            postProcessingData.toneMapping.mode.value = TonemappingModes[posInToneMappingArray];
            toneMappingModeTxt.text = "Neutral";
        }
    }

    void ConfirmPostProcessingData(ScenePostProcessingData postProcessingData)
    {
        GM.scenePostProcessingData = postProcessingData;
    }
}
