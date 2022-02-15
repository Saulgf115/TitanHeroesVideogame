using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackFXController : MonoBehaviour
{

    public GameObject normalAttack;

    public GameObject specialAttack_Preab_1, specialAttack_Preab_2, specialAttack_Preab_3;

    public Transform specialAttack_Position_1, specialAttack_Position_2, specialAttack_Position_3,normalAttack_Position;

    [HideInInspector]
    public Transform specialAttack_Position_2_1, specialAttack_Position_2_2;

    public bool is_Lei_Zhengzi;
    public bool is_BadeerAngel;
    public bool is_Lian_You;
    public bool is_Evil_King;
    public bool is_Dark_Sorcerer;


    //here will be script for badeer angel
    void ActivateNormalAttack()
    {
        normalAttack.SetActive(true);
    }

    void DeactivateNormalAttack()
    {
        normalAttack.SetActive(false);
    }

    void Spawn_SpecialAttackEffect_1()
    {
        if(is_BadeerAngel || is_Lei_Zhengzi)
        {
            Instantiate(specialAttack_Preab_1,specialAttack_Position_1.position,Quaternion.identity);
        }

        if(is_Lian_You || is_Evil_King || is_Dark_Sorcerer)
        {
            Instantiate(specialAttack_Preab_1,specialAttack_Position_1.position,transform.rotation);
        }
    }

    void Spawn_SpecialAttackEffect_2()
    {
        if (is_Evil_King || is_Lei_Zhengzi)
        {
            Instantiate(specialAttack_Preab_2, specialAttack_Position_2.position, transform.rotation);
        }

        if (is_BadeerAngel)
        {
            GameObject special2 = Instantiate(specialAttack_Preab_2);
            special2.transform.position = specialAttack_Position_2.position;
            special2.transform.SetParent(specialAttack_Position_2);

            //call angel script
        }

        if(is_Lian_You)
        {
            Instantiate(specialAttack_Preab_2, specialAttack_Position_2.position, Quaternion.identity);
        }

        if(is_Dark_Sorcerer)
        {
            Instantiate(specialAttack_Preab_2, specialAttack_Position_1.position, transform.rotation);

            Instantiate(specialAttack_Preab_2, specialAttack_Position_2.position, transform.rotation);

            Instantiate(specialAttack_Preab_2, specialAttack_Position_3.position, transform.rotation);
        }

    }

    void Spawn_SpecialAttackEffect_3()
    {
        if (is_Evil_King || is_Lei_Zhengzi || is_BadeerAngel || is_Lian_You)
        {
            Instantiate(specialAttack_Preab_3, specialAttack_Position_3.position, transform.rotation);
        }

       

        if (is_Dark_Sorcerer)
        {
            Instantiate(specialAttack_Preab_3, specialAttack_Position_1.position, transform.rotation);

            Instantiate(specialAttack_Preab_3, specialAttack_Position_2.position, transform.rotation);

            Instantiate(specialAttack_Preab_3, specialAttack_Position_3.position, transform.rotation);
        }

    }


    void Spawn_NormalAttackEffect()
    {
        //Instantiate(normalAttack, normalAttack_Position.position, Quaternion.identity);
        Instantiate(normalAttack, normalAttack_Position.position, transform.rotation);
    }


}
