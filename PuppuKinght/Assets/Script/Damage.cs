using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    //[SerializeField]
    //Transform Player;

    public float damage = 5.0f;
    public float damageSpeed = 1.0f;
    private float canDamage;
    private Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnCollisionEnter(Collision info)
    {
        if ((info.gameObject.tag == "Player"))
        {
            /*
            if(damageSpeed <= canDamage)
            {
                info.gameObject.GetComponent<PlayerControl>().UpdateHealth(-damage);
                canDamage = 0f;
            }
            else
            {
                canDamage += Time.deltaTime;
            }*/

            
            animator.SetTrigger("attack");
            info.gameObject.GetComponent<PlayerControl>().UpdateHealth(-damage);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
