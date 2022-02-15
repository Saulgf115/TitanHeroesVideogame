using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackDamage : MonoBehaviour
{

    public LayerMask layerMask;
    public float radius = 1.0f;
    public float damage = 1.0f;

    public bool dealMultipleDamage = false;

    public bool disable_Script = false;

    public bool detectCollisionAfterDelay = false;

    bool canDetectCollision = true;

    public float delayTime = 1.0f;


    // Start is called before the first frame update
    void Start()
    {
        if(detectCollisionAfterDelay)
        {
            canDetectCollision = false;
            StartCoroutine(CollisionAfterDelay());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(canDetectCollision)
        {
            DetectCollision();
        }
    }

    void DetectCollision()
    {
        Collider[] hit = Physics.OverlapSphere(transform.position,radius,layerMask);

        if(hit.Length > 0)
        {
            if(dealMultipleDamage)
            {
                for(int i=0;i<hit.Length;i++)
                {
                    //print("DEAL DAMAGE MULTIPLE TIMES");
                    hit[i].GetComponent<HealthScript>().ApplyDamage(damage);
                }
            }
            else
            {
                //print("DEAL DAMAGE ONCE");
                hit[0].GetComponent<HealthScript>().ApplyDamage(damage);
            }

            if(disable_Script)
            {
                enabled = false;
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
    }

    IEnumerator CollisionAfterDelay()
    {
        yield return new WaitForSeconds(delayTime);

        canDetectCollision = true;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position,radius);
    }
}
