using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon1 : MonoBehaviour
{

    [SerializeField] float turnSpeed = 0f;
    [SerializeField] float selfSpeed = 10f;
    private int stopped = 1;

    void Start()
    {
        stopped = 1;
        
    }

    void Update()
    {
        // Rotate Itself:
        //transform.Rotate(Vector3.forward * turnSpeed * Input.GetAxisRaw("Horizontal") * Time.deltaTime);

        // Self Rotate:
        transform.RotateAround(transform.parent.position, Vector3.forward, stopped * selfSpeed * Time.deltaTime);

        // Rotate Arround:
        transform.RotateAround(transform.parent.position, Vector3.forward * Input.GetAxisRaw("Horizontal"), stopped * turnSpeed * Time.deltaTime);
    }





}
