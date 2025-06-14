using UnityEngine;

public class player : MonoBehaviour
{
    [HideInInspector]public Rigidbody rb;
    public int id;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "death")
        {
            Destroy(gameObject);
        }
        

    }
}
