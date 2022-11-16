using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG;

public class TransformLink : MonoBehaviour
{
    public Transform largeBall, scaledParent, regularParent;

    public float xOffset, zOffset;
    float parentScale;//, xScale, yScale, zScale;

    // Start is called before the first frame update
    void Start()
    {
        parentScale = regularParent.localScale.x / scaledParent.localScale.x;
        Debug.Log("parentScale: " + parentScale);
        //xScale = largeBall.localScale.x / transform.localScale.x;
        //yScale = largeBall.localScale.y / transform.localScale.y;
        //zScale = largeBall.localScale.z / transform.localScale.z;
    }

    // Update is called once per frame
    void Update()
    {
        largeBall.SetPositionAndRotation(new Vector3((parentScale * transform.position.x) + xOffset, largeBall.position.y, (parentScale * transform.position.z) + zOffset), new Quaternion()); 
    }
}
