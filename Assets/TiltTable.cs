using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiltTable : MonoBehaviour
{
    public float tiltSpeed = 10.0f;
    public float tiltAngle = 10.0f;

    public void TT(Vector3 tiltDirection)
    {
        transform.Rotate(tiltDirection * tiltSpeed * Time.deltaTime);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            TT(new Vector3(0, 0, 1));
        }
        else if (Input.GetKey(KeyCode.X))
        {
            TT(new Vector3(0, 0, -1));
        }
    }
}
