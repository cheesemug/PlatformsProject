using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class launchPlat : MonoBehaviour
{
    public float launchForce;
    [HideInInspector]public int launch = 0;


    public void Update()
    {
        if (launch == 1)
        {
            AddForceFunc(gameObject);
            launch = 0;
        }
    }

    public void AddForceFunc(GameObject gb)
    {
        Debug.Log("WOW");
        gb.GetComponent<player>().rb.AddForce(transform.up * launchForce, ForceMode.Impulse);
    }
}
