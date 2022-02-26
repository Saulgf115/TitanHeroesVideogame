using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountdownController : MonoBehaviour
{

    public static CountdownController instance;

    AudioSource audioSource;
    Animator animator;

    public GameObject[] countdowns;

    public GameObject countdown1, countdown2, countdown3;

    //GMCameraAnimationController cameraAnimationsController;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();

        MakeSingleton();
    }

    void MakeSingleton()
    {
        if(instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public void StartCountdown()
    {
        animator.enabled = true;
        
      
        Countdown3();
    }

    void Countdown3()
    {
        //countdowns[0].SetActive(true);
        countdown3.SetActive(true);

        //animator.Play(AnimationTags.COUNTDOWN_3_ANIMATION);

    }

    void Countdown2()
    {
        //countdowns[0].SetActive(false);
        //countdowns[1].SetActive(true);

        countdown3.SetActive(false);
        countdown2.SetActive(true);

       animator.Play(AnimationTags.COUNTDOWN_2_ANIMATION);
    }

    void Countdown1()
    {
        //countdowns[0].SetActive(false);
        //countdowns[1].SetActive(false);
        //countdowns[2].SetActive(true);

        countdown2.SetActive(false);
        countdown1.SetActive(true);

        animator.Play(AnimationTags.COUNTDOWN_1_ANIMATION);
    }

    void ActivateMainCamera()
    {
        countdown1.SetActive(false);
        GMCameraAnimationController.instance.TurnOnMainCamera();
    }


    public void PlayCountdownSound()
    {
        audioSource.Play();
        Debug.Log("DEBERIA ESCUCHARSE00");
    }
}
