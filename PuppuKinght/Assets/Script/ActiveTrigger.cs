using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveTrigger : MonoBehaviour
{
    [SerializeField]
    Transform Weapon;

    Collider m_ObjectCollider;
    // Start is called before the first frame update
    void Start()
    {
        m_ObjectCollider = Weapon.gameObject.GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Active()
    {
        //Weapon.gameObject.SetActive(true);
        m_ObjectCollider.isTrigger = true;
    }

    public void UnActive()
    {
        //Weapon.gameObject.SetActive(false);
        m_ObjectCollider.isTrigger = false;
    }
}
