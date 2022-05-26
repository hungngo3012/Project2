using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    Transform transTarget;

    public float speed = 2.0f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = transTarget.position;
        transform.position = Vector3.Lerp(transform.position, transTarget.position, Time.deltaTime * speed);
    }
}
