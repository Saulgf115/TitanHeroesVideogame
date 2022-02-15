using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackDamage : MonoBehaviour
{

    public LayerMask layerMask;
    public float radius = 1.0f;
    public float damage = 1.0f;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] hit = Physics.OverlapSphere(transform.position,radius,layerMask);


        if(hit.Length > 0)
        {
            //Debug.Log("Deal daamge player");

            hit[0].GetComponent<HealthScript>().ApplyDamage(damage);

            gameObject.SetActive(false);
        }

    }
}
