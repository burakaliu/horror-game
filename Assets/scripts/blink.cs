using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class blink : MonoBehaviour
{

    public PostProcessVolume ppv;

    // Start is called before the first frame update
    void Start()
    {
        ppv.profile.GetSetting<Vignette>().intensity.value = 1f;
        ppv.profile.GetSetting<Vignette>().roundness.value = 1f;
        ppv.profile.GetSetting<Grain>().intensity.value = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        //slowly increase the intensity of the vignette effect
        if (ppv.profile.GetSetting<Vignette>().intensity.value >= 0.576)
        {
            ppv.profile.GetSetting<Vignette>().intensity.value -= 0.0005f;
            
        }
        if (ppv.profile.GetSetting<Vignette>().roundness.value >= 0.142) {
            ppv.profile.GetSetting<Vignette>().roundness.value -= 0.0005f;
        }
        if (ppv.profile.GetSetting<Grain>().intensity.value >= 0.142)
        {
            ppv.profile.GetSetting<Grain>().intensity.value -= 0.0005f;
        }

    }
}
