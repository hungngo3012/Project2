using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    public AudioSource EnemyGetHitAudio;

    [SerializeField]
    Transform Gift;

    public float hp = 10.0f;
    public float maxHP = 10.0f;

    public bool isDie;
    public bool isKnock = false;
    private Animator animator;

    public AudioSource[] DieVoice;

    Collider m_ObjectCollider;
    // Start is called before the first frame update
    void Start()
    {
        m_ObjectCollider = GetComponent<Collider>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 movementDirection = new Vector3(0, 0, -1.0f);
        if (isDie)
        {
            StartCoroutine(Coroutine());
        }

        //transform.Translate(movementDirection * 2.0f * Time.deltaTime, Space.World);
    }

    IEnumerator Coroutine()
    {
        //Print the time of when the function is first called.
        //Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(3);

        Destroy(gameObject);

        //After we have waited 5 seconds print the time again.
        //Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }

    public void UpdateHealth(float mod)
    {
        if (mod < 0f)
        {
            animator.SetTrigger("getHits");
            isKnock = true;
            EnemyGetHitAudio.Play();
            Invoke(nameof(SetKnockStatus), 2.0f);
        }

        hp = hp + mod;

        if (hp > maxHP)
        {
            hp = maxHP;
        }

        if (hp <= 0f)
        {
            if(DieVoice.Length == 1)
            {
                DieVoice[0].Play();
            }
            Gift.position = transform.position;
            Gift.gameObject.SetActive(true);
            m_ObjectCollider.isTrigger = true;
            animator.SetTrigger("die");
            isDie = true;
        }
    }

    public bool GetDieStatus()
    {
        return isDie;
    }

    public void SetDieStatus(bool val)
    {
        isDie = val;
    }
    public bool GetKnockStatus()
    {
        return isKnock;
    }
    public void SetKnockStatus()
    {
        isKnock = false;
    }

    public float GetHp()
    {
        return hp;
    }
    public float GetMaxHp()
    {
        return maxHP;
    }
}
