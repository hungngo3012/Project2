using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI_Simple : MonoBehaviour
{
    Animator ani;
    public NavMeshAgent agent;
    public Transform player;
    public Transform checkpoint;
    public LayerMask whatIsGround, whatIsPlayer;
    public Transform[] limit;
    public int path = 1;

    //Patrolling
    public Vector3 walkPoint;
    public int ChangeWalkPointTime;
    bool walkPointSet;
    public float walkPointRange;
    private bool changeDirect;
    public int isPatrol = 0;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public float damage = 5.0f;

    //States 
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;
    public float dis;
    public bool isDie;
    private bool isMove = false;



    private void Awake()
    {
        ani = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        isDie = transform.gameObject.GetComponent<Enemy>().GetDieStatus();
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange && !isDie)
        {
            Patroling();
        }

        if (playerInSightRange && !playerInAttackRange && !isDie)
        {
            //ani.SetTrigger("walk");
            ChasePlayer();
            walkPointSet = true;

        }

        if (playerInSightRange && playerInAttackRange && !isDie)
        {
            //ani.ResetTrigger("walk");
            ani.SetTrigger("attack");
            AttackPlayer();
            //Invoke(nameof(Recall), timeBetweenAttacks);
        }

        if(isMove)
        {
            ani.SetTrigger("walk");
        }

        if (isDie)
        {
            agent.SetDestination(transform.position);
        }

    }
    private void Recall()
    {
        player.position = checkpoint.position;
    }

    private void Patroling()
    {
        if (walkPointSet == false)
        {
            ani.SetTrigger("rest");
            SearchWalkPoint();
        }
        if (walkPointSet == true)
        {
            agent.SetDestination(walkPoint);
            //ani = GetComponent<Animator>();
            //ani.SetBool("walk", true);
            //transform.LookAt(walkPoint);

        }
        dis = Vector3.Distance(agent.transform.position, walkPoint);
        if (dis < 8f)
        {

            walkPointSet = false;
        }

    }
    private void SearchWalkPoint()
    {
        if(changeDirect && (isPatrol == 1))
        {
            int tmp = path;
            path = Random.Range(0, limit.Length - 1);
            if(tmp == path)
            {
                path = (path + 1) % (limit.Length);
            }
            //StartCoroutine(Coroutine());
            changeDirect = false;
        }

        /*
        if(changeDirect && (isPatrol == 0))
        {
            //path = 0;
            ani.SetTrigger("rest");
        }*/

        //changeDirect = false;
        walkPoint = limit[path].position;

        if(changeDirect && (isPatrol == 0))
        {
            isMove = false;
        }
        /*else
        {
            isMove = true;
        }*/
        walkPointSet = true;

        /*
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
        */
    }
    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
        transform.LookAt(player);
        isMove = true;

    }
    private void AttackPlayer()
    {
        //Make sure enemy does't move
        agent.SetDestination(transform.position);
        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            ani.SetTrigger("attack");
            player.gameObject.GetComponent<PlayerControl>().UpdateHealth(-damage);
            alreadyAttacked = true;
            Invoke(nameof(RestAttack), timeBetweenAttacks);

        }
    }

    private void RestAttack()
    {
        alreadyAttacked = false;
    }

    public void ChangeDirection(bool value)
    {
        changeDirect = value;
    }

    IEnumerator Coroutine()
    {
        yield return new WaitForSeconds(ChangeWalkPointTime);
        //ani.SetBool("walk", false);
    }
}

