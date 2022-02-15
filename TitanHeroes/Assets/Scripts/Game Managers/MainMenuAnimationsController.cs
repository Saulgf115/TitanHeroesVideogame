using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuAnimationsController : MonoBehaviour
{

    public static MainMenuAnimationsController instance;

    AudioSource heroes_Appear_Sound;

    public GameObject[] thunderFX;

    public Animator[] hero_Animators;
    public Animator floor_Animator;

    public float appear_Heroes_Time = 2.0f;
    public float shakeTime = 0.1f;



    private void Awake()
    {
        MakeInstance();

        heroes_Appear_Sound = GetComponent<AudioSource>();
    }

    void Start()
    {
        StartCoroutine(ActivateAnimations());
    }

    public void MakeInstance()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void FloorSlideIn()
    {
        floor_Animator.Play(AnimationTags.SLIDE_IN_ANIMATION);
    }

    IEnumerator ActivateAnimations()
    {
        yield return new WaitForSeconds(appear_Heroes_Time);

        for(int i=0;i<hero_Animators.Length;i++)
        {
            hero_Animators[i].Play(AnimationTags.SLIDE_IN_ANIMATION);
        }
    }
}
