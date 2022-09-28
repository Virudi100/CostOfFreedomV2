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
    private float _accelerationTimer = 0;

    public delegate void OnRobotGoingVroum();

    public static event OnRobotGoingVroum Robotgoingvroum;

    private void Start()
    {
        accelerationcheck = false;
    }

    private void FixedUpdate()
    {
       // PlayEngine();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("ZDFront"))
        {
            cockpit.transform.Translate(Vector3.forward * speed * Time.deltaTime);
            //accelerationcheck = true;
        }

        if (other.gameObject.CompareTag("ZDBack"))
        {
            cockpit.transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
    }



/*private void PlayEngine()
{
    if ( _accelerationTimer == 0f && accelerationcheck == true)
    {
        Debug.Log("lala");
        engineSound.Play();
        _accelerationTimer += Time.fixedDeltaTime;
        if (_accelerationTimer >= 10f)
        {
            Debug.Log("loulou");
            _accelerationTimer = 0f;
            accelerationcheck = false;
        }
    }
    
}
*/
}
