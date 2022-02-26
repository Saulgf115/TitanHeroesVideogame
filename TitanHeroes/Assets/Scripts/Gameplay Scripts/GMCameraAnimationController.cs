using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GMCameraAnimationController : MonoBehaviour
{

    Animator animator;

    public static GMCameraAnimationController instance;

    public GameObject[] cameras;


    public GameObject mainCamera, camera1, camera2;


    public delegate void ScreenMovement();
    public static event ScreenMovement screenMovement;


    //public CountdownController countdown;

    public Camera UI_Camera;
    public GameObject fightFX;

    private void Awake()
    {
        animator = GetComponent<Animator>();

        //countdown = GetComponent<CountdownController>();

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
   

    void TurnOnCamera2()
    {
        //cameras[1].SetActive(false);
        //cameras[2].SetActive(true);

        camera1.SetActive(false);
        camera2.SetActive(true);

        animator.Play(AnimationTags.CAMERA_2_ANIMATION);

        GameplayController.instance.SpawnPlayer();
    }

    public void TurnOnMainCamera()
    {
        //cameras[2].SetActive(false);

        //cameras[0].SetActive(true);

        camera2.SetActive(false);

        mainCamera.SetActive(true);

        //here we need add more code
        if(screenMovement != null)
        {
            screenMovement();
        }

        Instantiate(fightFX, UI_Camera.ScreenToWorldPoint(new Vector3(Screen.width / 2.0f,Screen.height / 2.0f,UI_Camera.nearClipPlane * 4.0f)),Quaternion.identity);
    }

    void StartCountdownAnimation()
    {
        //countdown.StartCountdown();
        CountdownController.instance.StartCountdown();
    }
}
