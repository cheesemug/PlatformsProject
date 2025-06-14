using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlingScript : MonoBehaviour
{
    private Animator anim;
    private GameObject obj;

    public Transform ballPos;
    public GameObject acctualMesh;
    public float launchForce;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }


    private void OnTriggerEnter(Collider other)
    {
        anim.SetTrigger("launch");
        other.gameObject.transform.position = ballPos.position;
        other.GetComponent<player>().rb.velocity = new Vector3(0, 0, 0);
        obj = other.gameObject;
    }

    public void Weeee()
    {
        if(obj!=null)
        {
            obj.GetComponent<player>().rb.AddForce(acctualMesh.transform.up * launchForce, ForceMode.Impulse);
        }
    }
}
