using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExploAttack : MonoBehaviour
{
    public float damage = 20.0f;
    public Text[] damageText;
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
        if(damageText.Length > 0)
        {
            damageText[0].text = damage.ToString();
        }
    }
}
