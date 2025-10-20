using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformAudio : MonoBehaviour
{
    [SerializeField] private AK.Wwise.Event _akPlayRotate;

    public void PlayRotate()
    {
        _akPlayRotate?.Post(gameObject);
    }
}
