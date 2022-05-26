using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCheckPoint : MonoBehaviour
{
    [SerializeField]
    Transform checkPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider info)
    {
        if (info.gameObject.tag == "Player")
        {
            checkPoint.position = transform.position;
            //canDamage = 0f;       
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
