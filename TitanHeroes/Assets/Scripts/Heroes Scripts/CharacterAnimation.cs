using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{

    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();

    }

    public void Walk(bool walk)
    {
        animator.SetBool(AnimationTags.WALK_PARAMETER, walk);
    }

    public void Run(bool run)
    {
        animator.SetBool(AnimationTags.RUN_PARAMETER, run);
    }

    public void NormalAttack_1()
    {
        animator.SetTrigger(AnimationTags.NORMAL_ATTACK_1_TRIGGER);
    }

    public void NormalAttack_2()
    {
        animator.SetTrigger(AnimationTags.NORMAL_ATTACK_2_TRIGGER);
    }

    public void SpecialAttack_1()
    {
        animator.SetTrigger(AnimationTags.SPECIAL_ATTACK_1_TRIGGER);
    }

    public void SpecialAttack_2()
    {
        animator.SetTrigger(AnimationTags.SPECIAL_ATTACK_2_TRIGGER);
    }

    public void SpecialAttack_3()
    {
        animator.SetTrigger(AnimationTags.SPECIAL_ATTACK_3_TRIGGER);
    }

    public void Hit()
    {
        animator.SetTrigger(AnimationTags.HIT_TRIGGER);
    }

    public void Dead()
    {
        animator.SetTrigger(AnimationTags.DEAD_TRIGGER);
    }

    public void StopAnimation()
    {
        animator.StopPlayback();
    }

    public void BackToIdle()
    {
        animator.Play(AnimationTags.IDLE_ANIMATION);
    }
}
