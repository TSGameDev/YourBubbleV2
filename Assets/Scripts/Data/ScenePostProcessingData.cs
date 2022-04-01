using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;

public struct ScenePostProcessingData
{
    public DepthOfField depthOfField;

    public Bloom bloom;

    public ColorAdjustments colorAdjustments;

    public Tonemapping toneMapping;

    public Vignette vignette;

    public WhiteBalance whiteBalance;

    public ScenePostProcessingData(VolumeProfile volumeProfile)
    {
        volumeProfile.TryGet(out depthOfField);
        volumeProfile.TryGet(out bloom);
        volumeProfile.TryGet(out colorAdjustments);
        volumeProfile.TryGet(out toneMapping);
        volumeProfile.TryGet(out vignette);
        volumeProfile.TryGet(out whiteBalance);
    }

}
