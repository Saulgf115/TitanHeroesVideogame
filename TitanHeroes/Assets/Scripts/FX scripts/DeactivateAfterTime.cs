using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateAfterTime : MonoBehaviour
{

    public float Timer = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DeactivateGameObject", Timer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DeactivateGameObject()
    {
        gameObject.SetActive(false);
    }
}
