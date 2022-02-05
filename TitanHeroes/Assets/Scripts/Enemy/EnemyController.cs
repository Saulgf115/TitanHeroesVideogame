using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum EnemyState
{
    PATROL,
    CHASE,
    ATTACK
}


public class EnemyController : MonoBehaviour
{
    [SerializeField]
    EnemyState enemyState;

    CharacterAnimation enemyAnimation;
    NavMeshAgent navMeshAgent;

     [SerializeField]
     float patrol_Radius = 30.0f;
    [SerializeField]
    float patrol_Time = 10.0f;
    float timer_Count = 0.0f;

    public float moveSpeed = 3.5f;
    public float runSpeed = 6.0f;


    //player target
    Transform playerTarget;
    public float chaseDistance = 10.0f;
    public float attackDistance = 1.0f;
    public float chasePlayerAfterAttackDistance = 1.0f;

    [SerializeField]
    float waitBeforeAttackTime = 3.0f;

    [SerializeField]
    float attackTimer = 0.0f;

    bool enemyDied = false;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        enemyAnimation = GetComponent<CharacterAnimation>();
    }

    void Start()
    {
        timer_Count = patrol_Time;

        enemyState = EnemyState.PATROL;

        playerTarget = GameObject.FindGameObjectWithTag(TagManager.PLAYER_TAG).transform;

        attackTimer = waitBeforeAttackTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyDied)
        {
            return;
        }


        if(enemyState == EnemyState.PATROL)
        {
            Patrol();

            Debug.Log("<color=green> TIMER COUNT: " + timer_Count + "</color>");
        }

        if(enemyState != EnemyState.CHASE && enemyState != EnemyState.ATTACK)
        {
            if(Vector3.Distance(transform.position,playerTarget.position) <= chaseDistance)
            {
                enemyState = EnemyState.CHASE;

                enemyAnimation.StopAnimation();
            }
        }


        if(enemyState == EnemyState.CHASE)
        {
            ChasePlayer();
        }

        if(enemyState == EnemyState.ATTACK)
        {
            AttackPlayer();
        }

    }

    void Patrol()
    {
        timer_Count += Time.deltaTime;
        navMeshAgent.speed = moveSpeed;

        if(timer_Count > patrol_Time)
        {
            //SET NEW RANDOM DESTINATION
            SetNewRandomDestination();

            timer_Count = 0.0f;
            
        }

        if(navMeshAgent.remainingDistance <= 0.5f)
        {
            //stop the nav agent from moving
            navMeshAgent.velocity = Vector3.zero;
        }

        if(navMeshAgent.velocity.sqrMagnitude == 0.0f)
        {
            //set the Idle animation from the character animation class
            enemyAnimation.Walk(false);
        }
        else
        {
            enemyAnimation.Walk(true);
        }


    }

    void SetNewRandomDestination()
    {
        Vector3 newDestination = RandomNavSphere(transform.position,patrol_Radius,-1);
        navMeshAgent.SetDestination(newDestination);
    }


    Vector3 RandomNavSphere(Vector3 originPosition,float distance,int layerMask)
    {
        Vector3 randomDirection = Random.insideUnitSphere * distance;
        randomDirection += originPosition;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randomDirection,out navHit,distance,layerMask);

        return navHit.position;
    }


    void ChasePlayer()
    {
        navMeshAgent.SetDestination(playerTarget.position);
        navMeshAgent.speed = runSpeed;


        if(navMeshAgent.velocity.sqrMagnitude == 0)
        {
            enemyAnimation.Run(false);
        }
        else{

            enemyAnimation.Run(true);

        }


        //we are in the range of attack
        if(Vector3.Distance(transform.position,playerTarget.position) <= attackDistance)
        {
            enemyState = EnemyState.ATTACK;
        }
        else if(Vector3.Distance(transform.position, playerTarget.position) > chaseDistance)
        {
            timer_Count = patrol_Time;
            enemyState = EnemyState.PATROL;

            enemyAnimation.Run(false);
        }

    }


    void AttackPlayer()
    {
        navMeshAgent.velocity = Vector3.zero;
        navMeshAgent.isStopped = true;

        enemyAnimation.Run(false);
        enemyAnimation.Walk(false);

        attackTimer += Time.deltaTime;

        if(attackTimer > waitBeforeAttackTime)
        {
            attackTimer = 0.0f;

            enemyAnimation.NormalAttack_1();
        }

        if(Vector3.Distance(transform.position,playerTarget.position) > attackDistance + chasePlayerAfterAttackDistance)
        {
            //MAKE TO THE AGENT MOVE AGAIN
            navMeshAgent.isStopped = false;

            enemyState = EnemyState.CHASE;
        }
    }

}
