using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    [SerializeField]
    Transform transTarget;

    Vector3 rotation;

    GameObject Enemy;

    private bool isBlock = false;
    // Start is called before the first frame update
    void Start()
    {
       
    }
/*
    void OnCollisionEnter(Collision info)
    {
        if ((info.gameObject.tag == "Enemy"))
        {
            isBlock = true;
            Enemy = info.gameObject;
        }
    }
*/
    // Update is called once per frame
    void Update()
    {
        /*
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");


        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        movementDirection.Normalize();

        if (isBlock)
        {
            Enemy.GetComponent<Rigidbody>().AddForce(movementDirection * 10.0f, ForceMode.Impulse);
        }
        */

        transform.rotation = transTarget.rotation;
        transform.position = transTarget.position;
    }
}
