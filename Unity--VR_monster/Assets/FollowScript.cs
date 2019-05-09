using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowScript : MonoBehaviour
{
    public GameObject target;
    public float gain = 0.5f;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();        
    }

    // Update is called once per frame
    void Update()
    {
        rb.MovePosition(Vector3.Lerp(this.transform.position, target.transform.position, gain));

        //Vector3 velcocity = new Vector3(target.transform.position.x - this.transform.position.x, 0, target.transform.position.z - this.transform.position.z);

        //rb.velocity += velcocity * gain;
    }
}
