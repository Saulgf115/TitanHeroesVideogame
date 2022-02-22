using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackInput : MonoBehaviour
{
    CharacterAnimation playerAnimation;

    public bool isLian_You;

    // Start is called before the first frame update
    void Awake()
    {
        playerAnimation = GetComponent<CharacterAnimation>();

        
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
    }

    void CheckInput()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            if(isLian_You)
            {
                if(Random.Range(0,2) > 0)
                {
                    playerAnimation.NormalAttack_1();
                }
                else
                {
                    playerAnimation.NormalAttack_2();
                }
            }
            else
            {
                playerAnimation.NormalAttack_1();
            }

            
        }


        if (Input.GetKeyDown(KeyCode.J))
        {
            playerAnimation.SpecialAttack_1();
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            playerAnimation.SpecialAttack_2();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            playerAnimation.SpecialAttack_3();
        }
    }

}
