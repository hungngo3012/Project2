using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerControl : MonoBehaviour
{
    //Interact other
    [SerializeField]
    Transform checkPoint;

    [SerializeField]
    Transform Bullet;

    [SerializeField]
    Transform BulletPos;

    [SerializeField]
    Transform Sword;

    [SerializeField]
    Transform Shield;

    [SerializeField]
    private AudioSource jAudio;

    [SerializeField]
    private AudioSource KAudio;

    [SerializeField]
    public AudioSource GetHitAudio;

    //Player Status
    public float speed = 5.0f;
    public float dashSpeed = 50.0f;

    public float rotationSpeed = 720.0f;
    public float stamina = 100.0f;
    public float hp = 100.0f;

    public StatusBar healthBar;
    public StatusBar staminaBar;

    public ActiveCollider weaponJ;
    public ActiveCollider weaponK;
    public ActiveTrigger noShield;
    //public ActiveCollider shield;

    //bool
    //private Vector3 force;
    private bool isKnock = false;
    private bool isKnockStrong = false;
    private bool isDie = false;
    private bool isDieTrigger = false;
    private bool isDef = false;
    private bool isAttack = false;
    private bool isAttackTrigger = false;
    private Animator animator;

    //Collect
    private bool isCollectSword = false;
    private bool isCollectShield = false;
    private bool isCollectBomb = false;

    //temp
    Rigidbody rb;
    Rigidbody bul;
    MeshRenderer bulMesh;
    Collider bulCol;

    void Start()
    {
        animator = GetComponent<Animator>();

        rb = GetComponent<Rigidbody>();
        bul = Bullet.gameObject.GetComponent<Rigidbody>();

        bulMesh = Bullet.gameObject.GetComponent<MeshRenderer>();

        bulCol = Bullet.gameObject.GetComponent<Collider>();

        healthBar.SetMaxHealth(hp);
        staminaBar.SetMaxHealth(stamina);

        //force = new Vector3(0.0f, 5.0f, 0.0f);
    }

    void OnCollisionEnter(Collision info)
    {
        if (info.gameObject.tag == "water")
        {
            hp = -1.0f;
            //healthBar.SetHealth(hp);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (!isKnock)
        {
            isKnockStrong = false;
        }

        if (isKnock)
        {
            weaponJ.UnActive();
            weaponK.UnActive();
            //rb.AddForce(force * dashSpeed, ForceMode.Impulse);
            isKnockStrong = true;
            isKnock = false;
        }

        if ((hp <= 0f))
        {
            animator.ResetTrigger("getHits");
            if (!isDieTrigger)
            {
                animator.SetTrigger("die");
                isDieTrigger = true;
            }
            hp = 0.1f;
            isDie = true;
        }


        if (isDie)
        {
            StartCoroutine(Coroutine());
            isDie = false;
        }

        if ((Input.GetKeyDown(KeyCode.J)) && (stamina > 5) && !isAttackTrigger && isCollectSword && !isDef && !isKnockStrong)
        {
            weaponJ.UnActive();
            weaponK.UnActive();
            //animator.SetBool("isMove", false);
            animator.SetBool("attack1", true);
            isAttackTrigger = true;
            weaponJ.Active();
            jAudio.Play();
            stamina = stamina - 5;
            //staminaBar.SetHealth(stamina);
            isAttack = true;
        }
        else
        {
            animator.SetBool("attack1", false);
        }

        if ((Input.GetKeyDown(KeyCode.K)) && (stamina > 10) && !isAttackTrigger && isCollectSword && !isDef && !isKnockStrong)
        {
            weaponK.UnActive();
            weaponJ.UnActive();
            //animator.SetBool("isMove", false);
            animator.SetBool("attack2", true);
            isAttackTrigger = true;
            weaponK.Active();
            KAudio.Play();
            stamina = stamina - 10;
            //staminaBar.SetHealth(stamina);
            isAttack = true;
        }
        else
        {
            animator.SetBool("attack2", false);
        }

        if (isAttack)
        {
            StartCoroutine(Coroutine2());
            isAttack = false;
        }

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);

        if (isDieTrigger)
        {
            movementDirection = Vector3.zero;
        }

        movementDirection.Normalize();

        if (!isDef)
        {
            transform.Translate(movementDirection * speed * Time.deltaTime, Space.World);
        }
        else
        {
            transform.Translate(movementDirection * speed * 0.5f * Time.deltaTime, Space.World);
        }


        if ((movementDirection != Vector3.zero) && !isDef)
        {
            animator.SetBool("isMove", true);
            //weaponJ.UnActive();
            //weaponK.UnActive();
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
        else
        {
            animator.SetBool("isMove", false);
        }

        if ((Input.GetKeyDown(KeyCode.Space)) && (stamina > 20) && (movementDirection != Vector3.zero))
        {
            //weaponJ.UnActive();
            //weaponK.UnActive();
            rb.AddForce(movementDirection * dashSpeed, ForceMode.Impulse);
            jAudio.Play();
            stamina = stamina - 20;
            //staminaBar.SetHealth(stamina);
        }

        if ((Input.GetKey(KeyCode.L)) && isCollectShield)
        {
            weaponJ.UnActive();
            weaponK.UnActive();
            isKnock = false;
            isDef = true;
            animator.SetBool("defend", true);
            noShield.UnActive();
            //shield.Active();
        }
        else
        {
            animator.SetBool("defend", false);
            //shield.UnActive();
            noShield.Active();
            isDef = false;
        }

        if (Input.GetKeyDown(KeyCode.H) && (stamina > 50) && !isDef && isCollectBomb)
        {
            Bullet.position = BulletPos.position;
            bulMesh.enabled = true;
            bulCol.isTrigger = false;
            bul.useGravity = true;
            bul.AddForce(transform.forward * dashSpeed * 1.5f, ForceMode.Impulse);
            jAudio.Play();
            stamina = stamina - 50;
            //staminaBar.SetHealth(stamina);
        }


        if (stamina < 100)
        {
            stamina = stamina + 0.05f;           
        }

        if (hp < 100)
        {
            hp = hp + 0.001f;           
        }

        staminaBar.SetHealth(stamina);
        healthBar.SetHealth(hp);
    }

    IEnumerator Coroutine()
    {
        //Print the time of when the function is first called.
        //Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(5);
        transform.position = checkPoint.position;
        hp = 50.0f;
        //healthBar.SetHealth(hp);
        yield return new WaitForSeconds(5);
        isDieTrigger = false;

        //After we have waited 5 seconds print the time again.
        //Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }

    IEnumerator Coroutine2()
    {
        //Print the time of when the function is first called.
        //Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(1);
        weaponJ.UnActive();
        weaponK.UnActive();
        isAttackTrigger = false;
        //isAttack = false;

        //After we have waited 5 seconds print the time again.
        //Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }

    public void UpdateHealth(float mod)
    {
        if(mod < 0f)
        {
            GetHitAudio.Play();
            animator.SetTrigger("getHits");
            isKnock = true;
        }

        hp = hp + mod;
        healthBar.SetHealth(hp);

        if (hp >= 100f)
        {
            hp = 100.0f;
            stamina = stamina + mod*2;
            healthBar.SetHealth(hp);
            staminaBar.SetHealth(stamina);
        }
    }

    public void CollectSword()
    {
        Sword.gameObject.SetActive(true);
        isCollectSword = true;
    }

    public void CollectShield()
    {
        Shield.gameObject.SetActive(true);
        isCollectShield = true;
    }

    public void CollectBomb()
    {
        isCollectBomb = true;
    }
}