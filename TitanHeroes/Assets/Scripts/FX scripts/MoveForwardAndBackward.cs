using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForwardAndBackward : MonoBehaviour
{

    public float moveSpeed = 10.0f;


    public bool moveForwardAndBackward;
    // Start is called before the first frame update
    void Start()
    {
        if(moveForwardAndBackward)
        {
            StartCoroutine(ChangeDirection());
        }
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        transform.Translate(transform.forward * moveSpeed * Time.deltaTime,Space.World);
    }

    IEnumerator ChangeDirection()
    {
        yield return new WaitForSeconds(3.0f);

        moveSpeed *= -1.0f;
    }
}
