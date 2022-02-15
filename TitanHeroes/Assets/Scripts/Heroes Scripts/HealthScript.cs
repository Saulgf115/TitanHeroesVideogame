using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    [Header("Health Attributes")]
    public float health = 100.0f;
    CharacterAnimation characterAnimation;
    public bool isPlayer = false;


    // Start is called before the first frame update
    void Awake()
    {
        characterAnimation = GetComponent<CharacterAnimation>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ApplyDamage(float damage)
    {
        health -= damage;

        if(health <= 0.0f)
        {
            //we died

            characterAnimation.Dead();

            health = Mathf.Clamp(health,0.0f,0.0f);
        }
        else
        {
            if(!isPlayer)
            {
                characterAnimation.Hit();
            }
        }
    }
}
