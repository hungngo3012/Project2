using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float RotateSpeed = 0.2f;
    public int RotateDirection;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(RotateDirection == 0)
        {
            transform.Rotate(Vector3.left * RotateSpeed);
        }    

        if(RotateDirection == 1)
        {
            transform.Rotate(Vector3.right * RotateSpeed);
        }

        if (RotateDirection == 2)
        {
            transform.Rotate(Vector3.up * RotateSpeed);
        }

        if (RotateDirection == 3)
        {
            transform.Rotate(Vector3.down * RotateSpeed);
        }
    }
}
