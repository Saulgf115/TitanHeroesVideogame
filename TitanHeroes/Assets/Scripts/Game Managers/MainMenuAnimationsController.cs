using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class MainMenuAnimationsController : MonoBehaviour
{

    

    public static MainMenuAnimationsController instance;

    AudioSource heroes_Appear_Sound;

    public GameObject[] thunderFX;

    public Animator[] hero_Animators;
    public Animator floor_Animator;

    public float appear_Heroes_Time = 2.0f;
    public float shakeTime = 0.1f;

    public CinemachineVirtualCamera cinemaCamera;
    CinemachineBasicMultiChannelPerlin shakeFX;

    private void Awake()
    {
        MakeInstance();

        heroes_Appear_Sound = GetComponent<AudioSource>();
    }

    void Start()
    {
        StartCoroutine(ActivateAnimations());

        shakeFX = cinemaCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
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

    public void PlayerHeroAppearSound()
    {
        heroes_Appear_Sound.Play();
    }

    public void ActivateThunderFX()
    {
        heroes_Appear_Sound.Stop();

        for(int i=0;i<thunderFX.Length;i++)
        {
            thunderFX[i].SetActive(true);
        }

        StartCoroutine(ShakeCamera());
    }

    IEnumerator ActivateAnimations()
    {
        yield return new WaitForSeconds(appear_Heroes_Time);

        for(int i=0;i<hero_Animators.Length;i++)
        {
            hero_Animators[i].Play(AnimationTags.SLIDE_IN_ANIMATION);
        }
    }

    IEnumerator ShakeCamera()
    {
        shakeFX.m_AmplitudeGain = 10;
        shakeFX.m_FrequencyGain = 3.0f;

        yield return new WaitForSeconds(shakeTime);

        shakeFX.m_AmplitudeGain = 0.0f;
        shakeFX.m_FrequencyGain = 0.0f;
    }
}
