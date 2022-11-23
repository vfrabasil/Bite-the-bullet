using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon2 : MonoBehaviour
{

    [SerializeField] float turnSpeed = 0f;
    [SerializeField] float selfSpeed = 20f;
    
    void Start()
    {
        
    }

    void Update()
    {

        // Self Rotate:
        transform.RotateAround(transform.parent.position, Vector3.back, selfSpeed * Time.deltaTime);

        // Rotate Arround:
        transform.RotateAround(transform.parent.position, Vector3.forward * Input.GetAxisRaw("Vertical"), turnSpeed * Time.deltaTime);
    }
}
