using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateFX : MonoBehaviour
{
    public float rotationSpeed_X;
    public float rotationSpeed_Y;
    public float rotationSpeed_Z;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
    }
    
    void Rotate()
    {
        transform.Rotate(new Vector3(rotationSpeed_X,rotationSpeed_Y,rotationSpeed_Z) * Time.deltaTime);
    }
}
