using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDamageController : MonoBehaviour
{

    public GameObject attackPoint_1;
    public GameObject attackPoint_2;

    void Turn_On_AttackPoint1()
    {
        attackPoint_1.SetActive(true);
    }

    void Turn_Off_AttackPoint1()
    {
        if(attackPoint_1.activeInHierarchy)
        {
            attackPoint_1.SetActive(false);
        }
    }

    void Turn_On_AttackPoint2()
    {
        attackPoint_2.SetActive(true);
    }

    void Turn_Off_AttackPoint2()
    {
        if (attackPoint_2.activeInHierarchy)
        {
            attackPoint_2.SetActive(false);
        }
    }

}
