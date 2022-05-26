using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyZone : MonoBehaviour
{
    public int isGunner = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider info)
    {
        if ((info.gameObject.tag == "Enemy"))
        {
            if(isGunner == 0)
            {
                info.gameObject.GetComponent<EnemyAI_Simple>().ChangeDirection(true);
            }
            
            if(isGunner == 1)
            {
                info.gameObject.GetComponent<EnemyAI_Gunner>().ChangeDirection(true);
            }           
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
