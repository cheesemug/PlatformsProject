using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalShip : MonoBehaviour
{
    public int numBalls;
    public GameObject winObject;
    private float winTimer = 1;

    // Start is called before the first frame update
    void Start()
    {
        numBalls = FindObjectsOfType<player>().Length;
    }

    // Update is called once per frame
    void Update()
    {
        if(numBalls==0)
            winTimer-=Time.deltaTime;
        if (winTimer < 0)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(other.gameObject);
            numBalls--;
            if (numBalls == 0)
                Instantiate(winObject,transform.position, Quaternion.identity);
        }
    }
}
