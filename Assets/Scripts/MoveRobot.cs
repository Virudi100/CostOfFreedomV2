using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRobot : MonoBehaviour
{

    [SerializeField] private GameObject cockpit;
    [SerializeField] private float speed = 3;
    public AudioSource engineSound;
    private bool accelerationcheck;
    private bool signalToTimer= false;
    private float _accelerationTimer = 0;
    

    private void Start()
    {
        accelerationcheck = false;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("ZDFront"))
        {
            cockpit.transform.Translate(Vector3.forward * speed * Time.deltaTime);
            accelerationcheck = false;
        }

        if (other.gameObject.CompareTag("ZDBack"))
        {
            cockpit.transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ZDFront"))
        {
            Robotgoingvroum();
        }
    }

    private void Robotgoingvroum()
    {
        if (accelerationcheck == false)
        {
            engineSound.Play();
            accelerationcheck = true;
        }
    }
    


}
