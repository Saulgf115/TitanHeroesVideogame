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


    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        enemyAnimation = GetComponent<CharacterAnimation>();
    }

    void Start()
    {
        timer_Count = patrol_Time;

        enemyState = EnemyState.PATROL;
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyState == EnemyState.PATROL)
        {
            Patrol();

            Debug.Log("<color=green> TIMER COUNT: " + timer_Count + "</color>");
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

}
