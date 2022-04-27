using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;

namespace TSGameDev.Data
{
    //A struct to hold post processing data for a scene for the purpose of saving, loading and manipulating the data easily.
    public struct ScenePostProcessingData
    {
        public DepthOfField depthOfField;
        public Bloom bloom;
        public ColorAdjustments colorAdjustments;
        public Tonemapping toneMapping;
        public Vignette vignette;
        public WhiteBalance whiteBalance;

        /// <summary>
        /// Struct for player post processing settings to be carried into the scene, saved and loaded
        /// </summary>
        /// <param name="volumeProfile">The volume profile asset for value changing</param>
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
}
