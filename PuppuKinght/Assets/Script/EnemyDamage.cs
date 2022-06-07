using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public float damage = 5.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    void OnTriggerEnter(Collider info)
    {
        if (info.gameObject.tag == "Player")
        {
            info.gameObject.GetComponent<PlayerControl>().UpdateHealth(-damage);
            //canDamage = 0f;       
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
