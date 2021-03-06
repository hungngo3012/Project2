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
    public float stamina;
    public float hp;

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
    public bool isCollectSword = false;
    public bool isCollectShield = false;
    public bool isCollectBomb = false;

    public GameObject CollectSwordPanel;
    public GameObject CollectShieldPanel;
    public GameObject CollectBombPanel;

    //temp
    Rigidbody rb;
    Rigidbody bul;
    MeshRenderer bulMesh;
    Collider bulCol;

    //Main quest
    public bool isCollectLife;
    public bool isCollectPower;
    public bool isCollectSoul;
    public bool isCollectWisdom;

    bool isCollectLifeConFirm;

    public Transform CollectLifePanel;
    public Transform CollectLifePanelQuest;

    //Slope Handle
    [Header("Slope Handling")]
    public float maxSlopeAngle;
    private RaycastHit slopeHit;
    private bool exitingSlope;
    public float playerHeight;
    Vector3 movementDirection;

    //NPC
    public bool[] isInteractNPC;
    public InteractNPC[] npc;
    public bool isBackHammerQuest;

    //DamageSave
    public GameObject WeaponJ;
    public GameObject WeaponK;

    public float SwordDamage;

    //pause
    public bool isPause = false;

    //subScene
    public int typeMove;

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
        SwordDamage = WeaponJ.GetComponent<Attack>().damage;

        Vector3 eulerRotation = transform.rotation.eulerAngles;
        transform.rotation = Quaternion.Euler(0, eulerRotation.y, 0);

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

        if ((Input.GetKeyDown(KeyCode.J)) && (stamina > 5) && !isAttackTrigger && isCollectSword && !isDef && !isKnockStrong && !isDieTrigger)
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

        if ((Input.GetKeyDown(KeyCode.K)) && (stamina > 10) && !isAttackTrigger && isCollectSword && !isDef && !isKnockStrong && !isDieTrigger)
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

        if(typeMove == 0)
        {
            movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        }
        else
        {
            if(typeMove == 1)
            {
                movementDirection = BulletPos.forward * verticalInput + BulletPos.right * horizontalInput;
            }
        }


        //on Slope
        if (OnSlope())
        {
            rb.AddForce(GetSlopeMoveDirection() * speed * 0.5f, ForceMode.Force);

            if (rb.velocity.y > 0)
                rb.AddForce(Vector3.down * 16f, ForceMode.Force);
        }

        //Dont use normal gravity on slope
        rb.useGravity = !OnSlope();

        if (isDieTrigger)
        {
            movementDirection = Vector3.zero;
        }

        movementDirection.Normalize();
        //movementDirection = AdjustVelocityToSlope(movementDirection);

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
            if(typeMove == 0)
            {
                Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
            }
        }
        else
        {
            animator.SetBool("isMove", false);
        }
        /*
        if (typeMove == 1)
        {
            Vector3 mouse = Input.mousePosition;
            Vector3 mouseWorld = UnityEngine.Camera.main.ScreenToWorldPoint(new Vector3(mouse.x, mouse.y, transform.position.y));
            Vector3 forward = mouseWorld - transform.position;
            Quaternion toRotation = Quaternion.LookRotation(forward, Vector3.up);
            toRotation.x = 0;
            toRotation.z = 0;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * 0.15f *Time.deltaTime);
        }
        */
        if (typeMove == 1)
        {
            Vector2 mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")) * 5.0f;
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + mouseInput.x, transform.rotation.eulerAngles.z);
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

        if ((Input.GetKey(KeyCode.L)) && isCollectShield && !isDieTrigger)
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

        if (Input.GetKeyDown(KeyCode.H) && (stamina > 50) && !isDef && isCollectBomb && !isDieTrigger)
        {
            Bullet.position = BulletPos.position;
            bulMesh.enabled = true;
            bulCol.isTrigger = false;
            bul.useGravity = true;
            bul.AddForce(transform.forward * dashSpeed * 1.5f, ForceMode.Impulse);
            jAudio.Play();
            stamina = stamina - 50.0f;
            //staminaBar.SetHealth(stamina);
        }

        if(isCollectLife && !isCollectLifeConFirm)
        {
            CollectLifePanel.gameObject.SetActive(true);
            CollectLifePanelQuest.gameObject.SetActive(true);
            isCollectLifeConFirm = true;
        }

        if ((stamina < 100) && !isPause)
        {
            stamina = stamina + 0.05f;           
        }

        if(stamina > 100.0f)
        {
            stamina = 100.0f;
        }

        if ((hp < 100) && !isPause)
        {
            hp = hp + 0.001f;
            if (isCollectLife)
            {
                hp = hp + 0.001f;
            }
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
        CollectSwordPanel.SetActive(true);
        isCollectSword = true;
    }

    public void CollectShield()
    {
        Shield.gameObject.SetActive(true);
        CollectShieldPanel.SetActive(true);
        isCollectShield = true;
    }

    public void CollectBomb()
    {
        CollectBombPanel.SetActive(true);
        isCollectBomb = true;
    }

    //Collect and set Pieces of Energy
    public void CollectLife(bool value)
    {
        isCollectLife = value;
    }

    public void CollectPower(bool value)
    {
        isCollectPower = value;
    }

    public void CollectSoul(bool value)
    {
        isCollectSoul = value;
    }

    public void CollectWisdom(bool value)
    {
        isCollectWisdom = value;
    }

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        //Load player status
        hp = data.health;
        stamina = data.stamina;
        SwordDamage = data.SwordDamage;

        WeaponJ.GetComponent<Attack>().damage = SwordDamage;
        WeaponK.GetComponent<Attack>().damage = SwordDamage*2;

        //Load Collect Weapon status
        if (data.isCollectSword == 1)
        {
            CollectSword();
        }

        if (data.isCollectShield == 1)
        {
            CollectShield();
        }

        if (data.isCollectBomb == 1)
        {
            CollectBomb();
        }

        //Load position
        Vector3 loadPosition;
        loadPosition.x = data.position[0];
        loadPosition.y = data.position[1];
        loadPosition.z = data.position[2];

        transform.position = loadPosition;

        if (data.isInteractNPC[0] == 1)
        {
            npc[0].isInteract = true;
        }

        if (data.isInteractNPC[1] == 1)
        {
            npc[1].isInteract = true;
        }

        if (data.isInteractNPC[2] == 1)
        {
            npc[2].isInteract = true;
        }

        if (data.isInteractNPC[3] == 1)
        {
            npc[3].isInteract = true;
        }

        //Load main quest status
        if (data.isCollectLife == 1)
        {
            isCollectLife = true;
        }
        if (data.isCollectPower == 1)
        {
            isCollectPower = true;
        }
        if (data.isCollectSoul == 1)
        {
            isCollectSoul = true;
        }
        if (data.isCollectWisdom == 1)
        {
            isCollectWisdom = true;
        }

        //
        if(data.isBackHammerQuest == 1)
        {
            isBackHammerQuest = true;
        }
    }

    public void NpcHandle()
    {
        isInteractNPC[0] = npc[0].isInteract;
        isInteractNPC[1] = npc[1].isInteract;
        isInteractNPC[2] = npc[2].isInteract;
        isInteractNPC[3] = npc[3].isInteract;
    }

    public void SetHammerQuestStatus(bool val)
    {
        isBackHammerQuest = val;
    }

    private bool OnSlope()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out slopeHit, playerHeight * 0.5f + 0.3f))
        {
            float angle = Vector3.Angle(Vector3.up, slopeHit.normal);
            return angle < maxSlopeAngle && angle != 0;
        }

        return false;
    }

    private Vector3 GetSlopeMoveDirection()
    {
        return Vector3.ProjectOnPlane(movementDirection, slopeHit.normal).normalized;
    }
}
