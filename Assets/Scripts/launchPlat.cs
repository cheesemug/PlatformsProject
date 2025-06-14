using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class launchPlat : MonoBehaviour
{
    public Animator animator;
    public float launchForce;
    public int launch = 0;
    // Start is called before the first frame update
    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (launch == 1)
            {
                AddForceFunc(collision);
                launch = 0;
            }
        
        }
    }

    public void AddForceFunc(UnityEngine.Collision col)
    {
        col.gameObject.GetComponent<player>().rb.AddForce(transform.up * launchForce, ForceMode.Impulse);
    }
}
