using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayUpwards : MonoBehaviour
{
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    [ContextMenu("GetUp")]
    public void GetUp()
    {
        rb.MoveRotation(Quaternion.Euler(0f, this.transform.rotation.eulerAngles.y, 0f));
    }
}
