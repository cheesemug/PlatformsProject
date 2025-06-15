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
        if(other.CompareTag("Player"))
        {
            Debug.Log("---.");
            anim.SetTrigger("launch");
            other.gameObject.transform.position = ballPos.position;
            other.GetComponent<player>().rb.velocity = new Vector3(0, 0, 0);
            other.transform.up = new Vector3 (Random.Range(0f,1f), Random.Range(0f, 1f), Random.Range(0f, 1f)).normalized;
            Rigidbody[] kids = other.gameObject.GetComponents<Rigidbody>();
            foreach (var item in kids)
            {
                item.velocity = new Vector3(0, 0, 0);
            }
            obj = other.gameObject;

        }

    }

    public void Weeee()
    {
        if(obj!=null)
        {
            obj.GetComponent<player>().rb.AddForce(acctualMesh.transform.up * launchForce, ForceMode.Impulse);
        }
    }
}
