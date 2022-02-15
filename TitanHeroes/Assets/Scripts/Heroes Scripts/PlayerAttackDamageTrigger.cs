using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackDamageTrigger : MonoBehaviour
{

    public float damage = 1.0f;
    public bool isPlayer = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider target)
    {
        if(isPlayer)
        {
            if(target.tag == TagManager.ENEMY_TAG || target.tag == TagManager.BOSS_TAG)
            {
                //print("Deal adamge to enemy");
                target.GetComponent<HealthScript>().ApplyDamage(damage);
            }
        }
        else
        {
            if(target.tag == TagManager.PLAYER_TAG)
            {
                //print("Deal damage to player");
                target.GetComponent<HealthScript>().ApplyDamage(damage);
            }
        }
    }
}
