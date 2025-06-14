using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goal : MonoBehaviour
{
    List<GameObject> playersInScene = new List<GameObject>();
    GameObject[] playerArr;
    public int playersCollected;

    public GameObject startObj;
    public GameObject endObj;
    public GameObject midObj;

    private Vector3 startToMid;
    private Vector3 midToEnd;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        playerArr = GameObject.FindGameObjectsWithTag("Player");
        
        transform.position = startObj.transform.position;

        for (int i = 0; i < playerArr.Length; i++)
        {
            playersInScene.Add(playerArr[i].gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        startToMid = midObj.transform.position - transform.position;
        midToEnd = endObj.transform.position - transform.position;


        if (startToMid.magnitude < 0.01f && playersInScene.Count != playersCollected)
        {
            Debug.Log("startToMid active");
            transform.position += startToMid * speed * Time.deltaTime;
        }
        if (playersInScene.Count == playersCollected)
        {
            transform.position += midToEnd * speed * Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playersCollected++;
            Destroy(collision.gameObject);
        }
    }
}
