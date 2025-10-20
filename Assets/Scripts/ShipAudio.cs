using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipAudio : MonoBehaviour
{
    [SerializeField] AK.Wwise.Event _akPlayWin;

    public void PlayWinSound()
    {
        _akPlayWin?.Post(gameObject);
    }
}
