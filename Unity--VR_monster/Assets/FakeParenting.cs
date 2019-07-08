using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeParenting : MonoBehaviour
{
    Transform fakeParent;

    Vector3 startLocalPosition;
    Quaternion startLocalRotation;

    // Start is called before the first frame update
    void Start()
    {
        fakeParent = this.transform.parent;

        startLocalPosition = fakeParent.InverseTransformPoint(transform.position);
        startLocalRotation = Quaternion.Inverse(fakeParent.rotation) * transform.rotation;

        this.transform.parent = null;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.position = fakeParent.position + startLocalPosition;
        this.transform.rotation = fakeParent.rotation * startLocalRotation;
    }
}
