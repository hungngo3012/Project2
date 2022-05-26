using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExploAttack : MonoBehaviour
{
    public float damage = 20.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollisionEnter(Collision info)
    {
        if(info.gameObject.tag == "Enemy")
        {
            info.gameObject.GetComponent<Enemy>().UpdateHealth(-damage);
        }

        if (info.gameObject.tag == "Player")
        {
            info.gameObject.GetComponent<PlayerControl>().UpdateHealth(-damage);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
