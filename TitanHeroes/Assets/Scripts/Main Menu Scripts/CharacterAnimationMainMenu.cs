using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationMainMenu : MonoBehaviour
{
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void TurnOnRootMotion()
    {
        animator.applyRootMotion = true;
    }

    void AppearGroundFloor()
    {
        MainMenuAnimationsController.instance.FloorSlideIn();
    }
}
