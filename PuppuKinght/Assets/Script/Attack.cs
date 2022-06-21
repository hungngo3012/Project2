using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attack : MonoBehaviour
{
    public float damage = 5.0f;
    public Text damageText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider info)
    {
        if (info.gameObject.tag == "Enemy")
        {
            info.gameObject.GetComponent<Enemy>().UpdateHealth(-damage);
                //canDamage = 0f;       
        }
    }

    // Update is called once per frame
    void Update()
    {
        damageText.text = damage.ToString();
    }

    public void UpdateDamage(float mod)
    {
        damage = damage + mod;
    }
}
