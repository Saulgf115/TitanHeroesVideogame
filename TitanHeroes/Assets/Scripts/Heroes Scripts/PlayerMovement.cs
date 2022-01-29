using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    BaseMovement baseMovement;

    CharacterAnimation playerAnimation;

    Quaternion screenMovement_space;
    Vector3 screenMovementForward;
    Vector3 screenMovement_Right;

    // Start is called before the first frame update
    void Awake()
    {
        baseMovement = GetComponent<BaseMovement>();
        baseMovement.movementDirection = Vector3.zero;

        playerAnimation = GetComponent<CharacterAnimation>();
    }

    private void Start()
    {
        SetMovementScreen();
    }

    // Update is called once per frame
    void Update()
    {
        MovementInput();
    }

    void MovementInput()
    {
        baseMovement.movementDirection = Input.GetAxis(AxisManager.HORIZONTAL_AXIS) * screenMovement_Right + Input.GetAxis(AxisManager.VERTICAL_AXIS) * screenMovementForward;

        //animate character
        if(Input.GetAxis(AxisManager.HORIZONTAL_AXIS) != 0.0f || Input.GetAxis(AxisManager.VERTICAL_AXIS) != 0.0f)
        {
            playerAnimation.Walk(true);
        }
        else
        {
            playerAnimation.Walk(false);
        }



        //this is to avoid increment the velocity in diagonal and clmap it to 1 (max value is 1)
        if (baseMovement.movementDirection.sqrMagnitude > 1)
        {
            baseMovement.movementDirection.Normalize();
        }
    }

    void SetMovementScreen()
    {
        screenMovement_space = Quaternion.Euler(0.0f,Camera.main.transform.eulerAngles.y,0.0f);
        screenMovementForward = screenMovement_space * Vector3.forward;
        screenMovement_Right = screenMovement_space * Vector3.right;
    }
}
