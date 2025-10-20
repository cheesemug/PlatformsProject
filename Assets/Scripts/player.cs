using UnityEngine;

public class player : MonoBehaviour
{
    [HideInInspector]public Rigidbody rb;
    public int id;
    public GameObject waterSplash;

    private Vector3 start;

    private PlayerAudio playerAudio;

    private void Awake()
    {
        playerAudio = GetComponent<PlayerAudio>();
        rb = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {
        start = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "water")
        {
            Debug.Log("Hit trigger and ded");
            playerAudio.PlayCollision("water");
            GameObject obj = Instantiate(waterSplash, transform.position, Quaternion.identity);
            Destroy(obj, 2f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "death")
        {
            Debug.Log("Hit collision and ded");
            //Destroy(gameObject);
            transform.position = start;
            rb.velocity = Vector3.zero;
            playerAudio.PlaySpawn();
        }
        else if (collision.gameObject.tag == "rock")
        {
            playerAudio.PlayCollision("rock");
        }
    }
    public void playMetalSound()
    {
        playerAudio.PlayCollision("metal");
    }
}
