using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
public class Post_Processing : MonoBehaviour
{
    public PostProcessProfile profile;
    CameraAPi cameraApi;
    // Start is called before the first frame update
    void Start()
    {
        PostProcessLayer postProcessLayer = cameraApi.cam.gameObject.AddComponent<PostProcessLayer>();
        postProcessLayer.volumeLayer = LayerMask.GetMask("Default");

        GameObject volumeObject = new GameObject("PostProcesingVolume");
        PostProcessVolume volume = volumeObject.AddComponent<PostProcessVolume>();
        volume.isGlobal = true;
        volume.sharedProfile = profile;


        ConfigurePostProcessingEffects();
        
    }

    void ConfigurePostProcessingEffects()
    {
     
        Vignette vignette;
        if (profile == null)
        {
            Debug.Log("Error Post processing file not found");
            return;
        }
        if (!profile.TryGetSettings(out vignette))
        {
            vignette = profile.AddSettings<Vignette>();
        }
        vignette.intensity.Override(0.4f);
        vignette.smoothness.Override(0.9f);

        Bloom bloom;
        if (!profile.TryGetSettings(out bloom))
        {
            bloom = profile.AddSettings<Bloom>();
        }
        bloom.intensity.Override(5.1f);
        bloom.threshold.Override(1f);
    }
}
