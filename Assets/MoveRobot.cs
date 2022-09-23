using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRobot : MonoBehaviour
{

    [SerializeField] private GameObject cockpit;
    [SerializeField] private float speed = 3;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("ZDFront"))
        {
            cockpit.transform.Translate(Vector3.forward * speed * Time.deltaTime);
            //print("move forward");
        }

        if (other.gameObject.CompareTag("ZDBack"))
        {
            cockpit.transform.Translate(Vector3.back * speed * Time.deltaTime);
            //print("move backward");
        }
    }
}
