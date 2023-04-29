using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTN : MonoBehaviour
{
    [SerializeField] public AudioSource _myFX;
    [SerializeField] public AudioClip _hoverFX;
    [SerializeField] public AudioClip _clickFX;


    public void Hover()
    {
        _myFX.PlayOneShot(_hoverFX);
    }
    public void Click()
    {
        _myFX.PlayOneShot(_clickFX);
    }
}
