using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static float volume;
    public AudioMixer mixer;

    private void Start()
    {
        mixer.SetFloat("Volume", volume);
    }

    public void SetVolume(float val)
    {
        volume = val == 0f ? -80 : Mathf.Log10(val) * 20;
        mixer.SetFloat("Volume", volume);
    }
}
