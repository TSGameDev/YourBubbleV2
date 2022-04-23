using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using TSGameDev.Managers;
using TSGameDev.Data;
using TSGameDev.Object;
using TSGameDev.Interactables;

public class CreateBubble : MonoBehaviour
{
    #region Private Variables

    [Header("Environment Texts")]
    [SerializeField] TextMeshProUGUI skyboxTxt;
    [SerializeField] TextMeshProUGUI terrainTxt;
    [SerializeField] TextMeshProUGUI terrainLengthTxt;
    [SerializeField] TextMeshProUGUI terrainWidthTxt;
    [Space(10)]

    #endregion

    #region Post Processing Variables

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

    #endregion

    #region Scene Creation Variables
    [Header("Scene Creation Prefabs")]
    [SerializeField] GameObject cameraa;
    [SerializeField] GameObject playerSetup;
    [SerializeField] SceneDatabase sceneObjectDatabase;

    Material currentSkybox;
    int posInSkyboxArray = 0;

    Material currentTerrainTexture;
    int posInTerrainArray = 0;

    int posInToneMappingArray = 0;
    UnityEngine.Rendering.Universal.TonemappingMode[] TonemappingModes = 
        { UnityEngine.Rendering.Universal.TonemappingMode.None, 
        UnityEngine.Rendering.Universal.TonemappingMode.Neutral, 
        UnityEngine.Rendering.Universal.TonemappingMode.ACES };

    int currentTerrainWidth = 100;
    int currentTerrainLength = 100;

    #endregion

    GameManager GM;
    UIManager uiManager;

    private void Awake()
    {
        GM = FindObjectOfType<GameManager>();
        uiManager = FindObjectOfType<UIManager>();
        SelectSkyBox();
        SelectTerrainTexture();
        AwakeText();

    }

    /// <summary>
    /// Increase one of the values within the create bubble settings menu
    /// </summary>
    /// <param name="FieldToIncrease">Which field the call will increase</param>
    public void IncreaseField(string FieldToIncrease)
    {
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
                if(GM.scenePostProcessingData.depthOfField.focusDistance.value < 30)
                    GM.scenePostProcessingData.depthOfField.focusDistance.value++;
                DOFFocusDistanceTxt.text = Mathf.RoundToInt(GM.scenePostProcessingData.depthOfField.focusDistance.value).ToString();
                break;
            case "DoF Focal Length":
                GM.scenePostProcessingData.depthOfField.focalLength.value++;
                DOFFocalLengthTxt.text = GM.scenePostProcessingData.depthOfField.focalLength.value.ToString();
                break;
            case "DoF Aperture":
                GM.scenePostProcessingData.depthOfField.aperture.value++;
                DOFAppertureTxt.text = GM.scenePostProcessingData.depthOfField.aperture.value.ToString();
                break;
            case "Bloom Intensity":
                if(GM.scenePostProcessingData.bloom.intensity.value < 5)
                    GM.scenePostProcessingData.bloom.intensity.value++;
                bloomIntensityTxt.text = GM.scenePostProcessingData.bloom.intensity.value.ToString();
                break;
            case "CA Post Exposure":
                if(GM.scenePostProcessingData.colorAdjustments.postExposure.value < 5)
                GM.scenePostProcessingData.colorAdjustments.postExposure.value++;
                colourPostExposureTxt.text = GM.scenePostProcessingData.colorAdjustments.postExposure.value.ToString();
                break;
            case "CA Contrast":
                GM.scenePostProcessingData.colorAdjustments.contrast.value++;
                colourContrastTxt.text = GM.scenePostProcessingData.colorAdjustments.contrast.value.ToString();
                break;
            case "CA Saturation":
                GM.scenePostProcessingData.colorAdjustments.saturation.value++;
                colourSaturationTxt.text = GM.scenePostProcessingData.colorAdjustments.saturation.value.ToString();
                break;
            case "Tone Mapping Mode":
                posInToneMappingArray++;
                SelectToneMappingMode(GM.scenePostProcessingData);
                break;
            case "Vig Intensity":
                GM.scenePostProcessingData.vignette.intensity.value = (float)System.Math.Round(GM.scenePostProcessingData.vignette.intensity.value += 0.1f, 2);
                vignetteIntensityTxt.text = GM.scenePostProcessingData.vignette.intensity.value.ToString();
                break;
            case "Vig Smoothness":
                GM.scenePostProcessingData.vignette.smoothness.value = (float)System.Math.Round(GM.scenePostProcessingData.vignette.smoothness.value += 0.1f, 2);
                vignetteSmoothnessTxt.text = GM.scenePostProcessingData.vignette.smoothness.value.ToString();
                break;
            case "Vig Rounded":
                GM.scenePostProcessingData.vignette.rounded.value = true;
                vignetteRoundedTxt.text = GM.scenePostProcessingData.vignette.rounded.value.ToString();
                break;
            case "WB Temperture":
                GM.scenePostProcessingData.whiteBalance.temperature.value++;
                whiteBalanceTemperatureTxt.text = GM.scenePostProcessingData.whiteBalance.temperature.value.ToString();
                break;
            case "WB Tint":
                GM.scenePostProcessingData.whiteBalance.tint.value++;
                whiteBalanceTintTxt.text = GM.scenePostProcessingData.whiteBalance.tint.value.ToString();
                break;
            case "Terrain Length":
                currentTerrainLength += 100;
                terrainLengthTxt.text = $"{currentTerrainLength}m";
                break;
            case "Terrain Width":
                currentTerrainWidth += 100;
                terrainWidthTxt.text = $"{currentTerrainWidth}m";
                break;
        }
    }

    /// <summary>
    /// Decrease one of the values within the create bubble settings menu
    /// </summary>
    /// <param name="FieldToIncrease">Which field the call will decrease</param>
    public void DecreaseField(string FieldToDecrease)
    {
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
                GM.scenePostProcessingData.depthOfField.focusDistance.value--;
                DOFFocusDistanceTxt.text = Mathf.RoundToInt(GM.scenePostProcessingData.depthOfField.focusDistance.value).ToString();
                break;
            case "DoF Focal Length":
                GM.scenePostProcessingData.depthOfField.focalLength.value--;
                DOFFocalLengthTxt.text = GM.scenePostProcessingData.depthOfField.focalLength.value.ToString();
                break;
            case "DoF Aperture":
                GM.scenePostProcessingData.depthOfField.aperture.value--;
                DOFAppertureTxt.text = GM.scenePostProcessingData.depthOfField.aperture.value.ToString();
                break;
            case "Bloom Intensity":
                GM.scenePostProcessingData.bloom.intensity.value--;
                bloomIntensityTxt.text = GM.scenePostProcessingData.bloom.intensity.value.ToString();
                break;
            case "CA Post Exposure":
                if(GM.scenePostProcessingData.colorAdjustments.postExposure.value > -5)
                    GM.scenePostProcessingData.colorAdjustments.postExposure.value--;
                colourPostExposureTxt.text = GM.scenePostProcessingData.colorAdjustments.postExposure.value.ToString();
                break;
            case "CA Contrast":
                GM.scenePostProcessingData.colorAdjustments.contrast.value--;
                colourContrastTxt.text = GM.scenePostProcessingData.colorAdjustments.contrast.value.ToString();
                break;
            case "CA Saturation":
                GM.scenePostProcessingData.colorAdjustments.saturation.value--;
                colourSaturationTxt.text = GM.scenePostProcessingData.colorAdjustments.saturation.value.ToString();
                break;
            case "Tone Mapping Mode":
                posInToneMappingArray--;
                SelectToneMappingMode(GM.scenePostProcessingData);
                break;
            case "Vig Intensity":
                GM.scenePostProcessingData.vignette.intensity.value = (float)System.Math.Round(GM.scenePostProcessingData.vignette.intensity.value -= 0.1f, 2);
                vignetteIntensityTxt.text = GM.scenePostProcessingData.vignette.intensity.value.ToString();
                break;
            case "Vig Smoothness":
                if(GM.scenePostProcessingData.vignette.smoothness.value > 0.1f)
                    GM.scenePostProcessingData.vignette.smoothness.value = (float)System.Math.Round(GM.scenePostProcessingData.vignette.smoothness.value -= 0.1f, 2);
                vignetteSmoothnessTxt.text = GM.scenePostProcessingData.vignette.smoothness.value.ToString();
                break;
            case "Vig Rounded":
                GM.scenePostProcessingData.vignette.rounded.value = false;
                vignetteRoundedTxt.text = GM.scenePostProcessingData.vignette.rounded.value.ToString();
                break;
            case "WB Temperture":
                GM.scenePostProcessingData.whiteBalance.temperature.value--;
                whiteBalanceTemperatureTxt.text = GM.scenePostProcessingData.whiteBalance.temperature.value.ToString();
                break;
            case "WB Tint":
                GM.scenePostProcessingData.whiteBalance.tint.value--;
                whiteBalanceTintTxt.text = GM.scenePostProcessingData.whiteBalance.tint.value.ToString();
                break;
            case "Terrain Length":
                if(currentTerrainLength > 100) currentTerrainLength -= 100;
                terrainLengthTxt.text = $"{currentTerrainLength}m";
                break;
            case "Terrain Width":
                if(currentTerrainWidth > 100) currentTerrainWidth -= 100;
                terrainWidthTxt.text = $"{currentTerrainWidth}m";
                break;
        }
    }

    /// <summary>
    /// Function to select a skybox from the array located on the game manager
    /// </summary>
    void SelectSkyBox()
    {
        if (posInSkyboxArray >= GM.Skyboxes.Length) { currentSkybox = GM.Skyboxes[GM.Skyboxes.Length - 1]; posInSkyboxArray = GM.Skyboxes.Length - 1; }
        else if (posInSkyboxArray < 0) { currentSkybox = GM.Skyboxes[0]; posInSkyboxArray = 0; }
        else { currentSkybox = GM.Skyboxes[posInSkyboxArray]; }
    }

    /// <summary>
    /// Function to select the terrain texture of the world from the array located on the game manager
    /// </summary>
    void SelectTerrainTexture()
    {
        if (posInTerrainArray >= GM.TerrainTextures.Length) 
        { 
            currentTerrainTexture = GM.TerrainTextures[GM.TerrainTextures.Length - 1];
            posInTerrainArray = GM.TerrainTextures.Length - 1;
        }
        else if (posInTerrainArray < 0) 
        { 
            currentTerrainTexture = GM.TerrainTextures[0];
            posInTerrainArray = 0; 
        }
        else 
        { 
            currentTerrainTexture = GM.TerrainTextures[posInTerrainArray];
        }
    }

    /// <summary>
    /// Function to select the tone mapping mode post processing
    /// </summary>
    /// <param name="postProcessingData">The post processing data used within the created bubble/overhaul application</param>
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

    /// <summary>
    /// function to 'awake' the UI of the create bubble settings
    /// </summary>
    void AwakeText()
    {
        skyboxTxt.text = currentSkybox.name;
        terrainTxt.text = currentTerrainTexture.name;
        terrainLengthTxt.text = $"{currentTerrainLength}m";
        terrainWidthTxt.text = $"{currentTerrainWidth}m";

        DOFFocusDistanceTxt.text = GM.scenePostProcessingData.depthOfField.focusDistance.value.ToString();
        DOFFocalLengthTxt.text = GM.scenePostProcessingData.depthOfField.focalLength.value.ToString();
        DOFAppertureTxt.text = GM.scenePostProcessingData.depthOfField.aperture.value.ToString();

        bloomIntensityTxt.text = GM.scenePostProcessingData.bloom.intensity.value.ToString();

        colourPostExposureTxt.text = GM.scenePostProcessingData.colorAdjustments.postExposure.value.ToString();
        colourContrastTxt.text = GM.scenePostProcessingData.colorAdjustments.contrast.value.ToString();
        colourSaturationTxt.text = GM.scenePostProcessingData.colorAdjustments.saturation.value.ToString();

        toneMappingModeTxt.text = GM.scenePostProcessingData.toneMapping.mode.value.ToString();

        vignetteIntensityTxt.text = GM.scenePostProcessingData.vignette.intensity.value.ToString();
        vignetteSmoothnessTxt.text = GM.scenePostProcessingData.vignette.smoothness.value.ToString();
        vignetteRoundedTxt.text = GM.scenePostProcessingData.vignette.rounded.value.ToString();

        whiteBalanceTemperatureTxt.text = GM.scenePostProcessingData.whiteBalance.temperature.value.ToString();
        whiteBalanceTintTxt.text = GM.scenePostProcessingData.whiteBalance.tint.value.ToString();
    }

    /// <summary>
    /// function to create the new scene of which the player can spawn different models, effects and sounds to build an environment
    /// </summary>
    public void CreateScene()
    {
        SceneManager.CreateScene("TestSceneCreation");
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("TestSceneCreation"));
        RenderSettings.skybox = currentSkybox;

        uiManager.OpenCloseBubbleSettingsMenu(false, false);

        TerrainData newTerrainData = new TerrainData();
        newTerrainData.size = new Vector3(currentTerrainWidth, 0, currentTerrainLength);
        Terrain newTerrain = Terrain.CreateTerrainGameObject(newTerrainData).GetComponent<Terrain>();
        newTerrain.materialTemplate = currentTerrainTexture;
        newTerrain.terrainData = newTerrainData;
        
        Instantiate(playerSetup, new Vector3(currentTerrainWidth / 2, 0, currentTerrainLength / 2), Quaternion.identity);
        sceneObjectDatabase.PopulateAssetMenu();
        SceneManager.MoveGameObjectToScene(cameraa, SceneManager.GetSceneByName("TestSceneCreation"));

        GM.gameState = GameState.Application;
        GM.gameStateActions = new ApplicationStateAction(GM);
    }

}
