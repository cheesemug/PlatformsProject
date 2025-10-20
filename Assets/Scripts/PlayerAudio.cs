using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    [SerializeField] AK.Wwise.Event _akPlayCollision;
    [SerializeField] AK.Wwise.Event _akPlaySpawn;
    [SerializeField] AK.Wwise.Event _akStopCollision;
    [SerializeField] AK.Wwise.State _akWaterState;
    [SerializeField] AK.Wwise.State _akRockState;
    [SerializeField] AK.Wwise.State _akMetalState;

    public void PlayCollision(string state)
    {
        StopCollision();
        if (state == "metal")
            _akMetalState.SetValue();
        else if (state == "rock")
            _akRockState.SetValue();
        else if (state == "water")
            _akWaterState.SetValue();
        _akPlayCollision?.Post(gameObject);
    }
    public void PlaySpawn()
    {
        _akPlaySpawn?.Post(gameObject);
    }
    public void StopCollision() 
    {
        _akStopCollision?.Post(gameObject);
    }
}
