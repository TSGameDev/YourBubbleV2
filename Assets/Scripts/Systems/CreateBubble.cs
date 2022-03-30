using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using TSGameDev.Managers;

public class CreateBubble : MonoBehaviour
{
    #region Private Variables

    [SerializeField] TextMeshProUGUI skyboxTxt;
    [SerializeField] TextMeshProUGUI terrainTxt;

    GameManager GM;

    Material currentSkybox;
    int posInSkyboxArray;

    Material currentTerrainTexture;
    int posInTerrainArray;

    #endregion

    private void Awake()
    {
        GM = FindObjectOfType<GameManager>();
    }

    public void ForwardSkybox() { posInSkyboxArray++; SelectSkyBox(); }

    public void BackwardSkybox() { posInSkyboxArray--; SelectSkyBox(); }

    void SelectSkyBox() 
    {
        if (posInSkyboxArray <= GM.Skyboxes.Length) { currentSkybox = GM.Skyboxes[GM.Skyboxes.Length]; }
        else if (posInSkyboxArray >= 0)
            currentSkybox = GM.Skyboxes[0];
        else
            currentSkybox = GM.Skyboxes[posInSkyboxArray];

        skyboxTxt.text = currentSkybox.name;
    }

    public void ForwardTerrainTexture() { posInTerrainArray++; SelectTerrainTexture(); }

    public void BackwardTerrainTexture() { posInTerrainArray--; SelectTerrainTexture(); }

    public void SelectTerrainTexture() 
    { 
        currentTerrainTexture = GM.Skyboxes[posInTerrainArray];
        terrainTxt.text = currentTerrainTexture.name;
    }
}
