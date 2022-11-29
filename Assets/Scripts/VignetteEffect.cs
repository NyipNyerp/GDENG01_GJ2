using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class VignetteEffect : MonoBehaviour
{
    private PostProcessVolume _postProcessVolume;
    private Vignette _vignette;

    [SerializeField] private float initialTime = 300;
    [SerializeField] private float currentTime = 0;
    [SerializeField] private int debugMultiplier = 1;

    // Start is called before the first frame update
    void Start()
    {
        _postProcessVolume = GetComponent<PostProcessVolume>();
        _postProcessVolume.profile.TryGetSettings(out _vignette);
    }

    void Update()
    {
        if (currentTime < initialTime)
        {
            currentTime += Time.deltaTime * debugMultiplier;
            SetIntensity(currentTime / initialTime);
        }
        else
        {
            // GAME OVER = LOSE
        }
    }

    public void VignetteOnOff(bool isOn)
    {
        _vignette.active = isOn;
    }

    public void SetIntensity(float value)
    {
        if (value <= 1) _vignette.intensity.value = value;
    }
}
