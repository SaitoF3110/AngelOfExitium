using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundOption : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider _bgmSlider;
    public Slider _bgsSlider;
    public Slider _seSlider;

    private void Start()
    {

        audioMixer.GetFloat("BGM_Volume", out float bgmVolume);
        _bgmSlider.value = bgmVolume;
        audioMixer.GetFloat("BGS_Volume", out float bgsVolume);
        _seSlider.value = bgsVolume;
        audioMixer.GetFloat("SE_Volume", out float seVolume);
        _seSlider.value = seVolume;
    }

    public void SetBGM(float volume)
    {
        audioMixer.SetFloat("BGM_Volume", volume);
    }

    public void SetBGS(float volume)
    {
        audioMixer.SetFloat("BGS_Volume", volume);
    }

    public void SetSE(float volume)
    {
        audioMixer.SetFloat("SE_Volume", volume);
    }


}
