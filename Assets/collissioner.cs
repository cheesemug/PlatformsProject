using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collissioner : MonoBehaviour
{
    public Animator animator;
    public GameObject ballTpSpot;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.transform.position = ballTpSpot.transform.localPosition;
            other.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
            animator.SetTrigger("launch");
        }
    }

    public void Func()
    {
        GetComponentInChildren<launchPlat>().launch = 1;
    }
}
