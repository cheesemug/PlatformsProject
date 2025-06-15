using UnityEngine;

public class player : MonoBehaviour
{
    [HideInInspector]public Rigidbody rb;
    public int id;
    public GameObject waterSplash;

    private Vector3 start;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        start = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "death")
        {
            GameObject obj = Instantiate(waterSplash, transform.position, Quaternion.identity);
            Destroy(obj, 2f);

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "death")
        {
            //Destroy(gameObject);
            transform.position = start;
            rb.velocity = Vector3.zero;
        }
    }
}
