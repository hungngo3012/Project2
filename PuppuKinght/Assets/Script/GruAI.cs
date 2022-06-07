using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GruAI : MonoBehaviour
{
    [SerializeField]
    private AudioSource Attack1Audio;

    [SerializeField]
    private AudioSource StoneAudio;

    [SerializeField]
    private AudioSource Attack2Audio;

    [SerializeField]
    private AudioSource CurrentMusic;

    [SerializeField]
    private AudioSource BossMusic;

    [SerializeField]
    Transform BossHP;

    [SerializeField]
    Transform CheckPanel;

    Animator ani;
    public NavMeshAgent agent;
    public Transform player;
    public Transform eye;
    public Transform checkpoint;
    public LayerMask whatIsGround, whatIsPlayer;

    //Attacking
    public float timeBetweenAttacks;
    public float timeDamage;
    bool alreadyAttacked;
    bool restAfterAttack = false;
    public float damage = 5.0f;
    public Transform Attack1;
    public Transform Attack2;

    //States 
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;
    public float dis;
    public bool isDie;
    private bool isMove = false;
    private bool isRest = false;
    private int typeAttack;
    private int type;
    private bool isTalk = false;
    private int isRun;


    Rigidbody rb;
    public StatusBar healthBar;


    private void Awake()
    {
        ani = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        healthBar.SetMaxHealth(transform.GetComponent<Enemy>().GetMaxHp());
    }

    private void Update()
    {
        bool isKnock = transform.GetComponent<Enemy>().GetKnockStatus();

        if (isKnock)
        {
            healthBar.SetHealth(transform.GetComponent<Enemy>().GetHp());
            agent.SetDestination(transform.position);
            transform.LookAt(eye);
        }

        if (CheckPanel.GetComponent<ClosePanel>().isClosePanel())
        {
            isTalk = true;
        }

        isDie = transform.gameObject.GetComponent<Enemy>().GetDieStatus();
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange && !isDie && isTalk)
        {
            ani.SetTrigger("rest");
            agent.SetDestination(transform.position);
        }

        if (playerInSightRange && !playerInAttackRange && !isDie && !restAfterAttack && isTalk && !isKnock)
        {
            isRest = false;
            //ani.SetTrigger("walk");
            ChasePlayer();
        }

        if (playerInSightRange && playerInAttackRange && !isDie && isTalk && !isKnock)
        {
            isRest = false;
            //ani.ResetTrigger("walk");
            //ani.SetTrigger("attack");
            AttackPlayer();
            //Invoke(nameof(Recall), timeBetweenAttacks);
        }

        if (isMove)
        {

        }

        if (isDie)
        {
            agent.SetDestination(transform.position);
            transform.LookAt(transform.forward);
            BossHP.gameObject.SetActive(false);
            Invoke(nameof(Die), 3.0f);
        }

    }

    private void Die()
    {
        BossMusic.gameObject.SetActive(false);
        CurrentMusic.gameObject.SetActive(true);
    }

    private void ChasePlayer()
    {
        ani.ResetTrigger("run");
        ani.SetTrigger("walk");
        agent.SetDestination(player.position);
        transform.LookAt(player);
        isMove = true;
        isRun = Random.Range(0, 500);//500

        if(isRun == 15)
        {
            ani.SetTrigger("run");
            //Invoke(nameof(Run), 0.2f);
            Run();
        }
    }

    private void Run()
    {
        rb.AddForce(transform.forward * 1000.0f, ForceMode.Impulse);
        transform.LookAt(player);
    }

    private void AttackPlayer()
    {
        //Make sure enemy does't move
        agent.SetDestination(transform.position);
        transform.LookAt(eye);

        if (!alreadyAttacked)
        {
            typeAttack = Random.Range(0, 99);
            if(typeAttack % 2 == 0)
            {
                ani.SetTrigger("attack1");
                type = 1;
            }
            else
            {
                ani.SetTrigger("attack2");
                type = 2;
            }

            ani.ResetTrigger("walk");
            //player.gameObject.GetComponent<PlayerControl>().UpdateHealth(-damage);
            Invoke(nameof(Damage), timeDamage - 0.7f);
            alreadyAttacked = true;
            restAfterAttack = true;
            Invoke(nameof(RestDamage), timeDamage);
            Invoke(nameof(RestAttack), timeBetweenAttacks);
            Invoke(nameof(RestMove), timeBetweenAttacks + 0.2f);

        }
    }

    private void Damage()
    {
        if(type == 1)
        {
            Attack1Audio.Play();
            Attack1.gameObject.SetActive(true);
            StoneAudio.Play();
        }
        if(type == 2)
        {
            Attack2Audio.Play();
            Attack2.gameObject.SetActive(true);
        }

    }
    private void RestAttack()
    {
        alreadyAttacked = false;
    }
    private void RestDamage()
    {
        Attack1.gameObject.SetActive(false);
        Attack2.gameObject.SetActive(false);
    }
    private void RestMove()
    {
        restAfterAttack = false;
        transform.LookAt(player);
    }
}
