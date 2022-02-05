using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public enum BossState
{
    GO_TO_PLAYER,
    MOVE_AWAY_FROM_PLAYER,
    SEARCH_FOR_PLAYER,
    ATTACK
}

public class BossController : MonoBehaviour
{
    CharacterAnimation bossAnimation;

    BossState bossState;

    NavMeshAgent navMesh;


    public float moveSpeed = 5.0f;

    Transform playerTarget;
    public float attackDistance = 2.0f;
    public float chasePlayerAfterAttackDistance = 1.0f;

    float waitBeforeAttackTime = 2.0f;
    float attackTimer = 0.0f;
    bool firstAttack = false;

    public float retreatDistanceRadius = 8.0f;
    Vector3 randomPosition;


    private void Awake()
    {
        navMesh = GetComponent<NavMeshAgent>();
        bossAnimation = GetComponent<CharacterAnimation>();
    }


    void Start()
    {
        playerTarget = GameObject.FindGameObjectWithTag(TagManager.PLAYER_TAG).transform;

        bossState = BossState.SEARCH_FOR_PLAYER;

    }

    // Update is called once per frame
    void Update()
    {
        if(bossState == BossState.SEARCH_FOR_PLAYER)
        {
            if(Vector3.Distance(transform.position,playerTarget.position) > attackDistance)
            {
                bossState = BossState.GO_TO_PLAYER;
            }
            else
            {
                bossState = BossState.ATTACK;
            }

        } // search for player

        if(bossState == BossState.GO_TO_PLAYER)
        {
            GoTowardsPlayer();
        }

        if(bossState == BossState.ATTACK)
        {
            AttackPlayer();
        }

        if (bossState == BossState.MOVE_AWAY_FROM_PLAYER)
        {
            MoveAwayrFromPlayer();
        }


    }


    void GoTowardsPlayer()
    {
        navMesh.isStopped = false;

        navMesh.SetDestination(playerTarget.position);

        //we are not moving
        if(navMesh.velocity.sqrMagnitude == 0)
        {
            bossAnimation.Walk(false);
            
        }
        else
        {
            bossAnimation.Walk(true);
        }

        if(Vector3.Distance(transform.position,playerTarget.position) <= attackDistance)
        {
            navMesh.velocity = Vector3.zero;
            navMesh.isStopped = true;


            bossAnimation.Walk(false);

            bossState = BossState.ATTACK;

            attackTimer = waitBeforeAttackTime / 2.0f;
        }


    }

    void AttackPlayer()
    {
        attackTimer += Time.deltaTime;

        if(attackTimer > waitBeforeAttackTime)
        {
            attackTimer = 0.0f;

            if(!firstAttack)
            {
                bossAnimation.NormalAttack_1();

                firstAttack = true;

                //if we already attacked for the first time
            }
            else
            {
                //here we weill attack again
                if(Random.Range(0,5) >= 1)
                {

                    if(Random.Range(0,3) > 1)
                    {
                        bossAnimation.NormalAttack_1();
                    }
                    else
                    {
                        bossAnimation.SpecialAttack_1();
                    }


                }
                else
                {
                    //here we will retreat
                    randomPosition = transform.position - (transform.forward * retreatDistanceRadius);

                    bossState = BossState.MOVE_AWAY_FROM_PLAYER;

                    //RESET THE FIRST ATTACK
                    firstAttack = false;

                }
            }
        } //outside of the attack range


        if(Vector3.Distance(transform.position,playerTarget.position) > attackDistance + chasePlayerAfterAttackDistance)
        {
            //enable nav agent to move
            navMesh.isStopped = false;

            bossState = BossState.GO_TO_PLAYER;
        }


    }

    void MoveAwayrFromPlayer()
    {
        navMesh.SetDestination(randomPosition);
        navMesh.isStopped = false;

        if(navMesh.velocity.sqrMagnitude == 0)
        {
            bossAnimation.Walk(false);
        }
        else
        {
            bossAnimation.Walk(true);
        }

        if(navMesh.remainingDistance <= 0.2f)
        {
            navMesh.velocity = Vector3.zero;
            navMesh.isStopped = true;

            StartCoroutine(WaitThenSearchForPlayer());
        }

    }

    IEnumerator WaitThenSearchForPlayer()
    {
        yield return new WaitForSeconds(Random.Range(1.0f,2.0f));

        bossState = BossState.SEARCH_FOR_PLAYER;
    }

}
