using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingMenu : MonoBehaviour
{
    public AudioMixer _audioMixer;
    // Start is called before the first frame update
    public void SetVolume (float volume)
    {
        _audioMixer.SetFloat("mainVolume", volume);
    }
}
