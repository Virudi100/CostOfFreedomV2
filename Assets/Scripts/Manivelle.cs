using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Manivelle : MonoBehaviour
{
    [SerializeField] private GameObject cockpit;
    private float speed = 3f;
    [SerializeField] private XRSimpleInteractable simple;
    private bool isUsing = false;
    private GameObject interactorGO;
    private Vector3 standardpos;

    private void Awake()
    {
        standardpos = transform.localPosition;
    }

    private void OnEnable()
    {
        simple.selectEntered.AddListener(StartUsingManivelle);
        simple.selectExited.AddListener(StopUsingManivelle);
    }

    private void OnDisable()
    {
        simple.selectEntered.RemoveListener(StartUsingManivelle);
        simple.selectExited.RemoveListener(StopUsingManivelle);
    }

    private void StartUsingManivelle(SelectEnterEventArgs args)
    {
        isUsing = true;
        interactorGO = args.interactorObject.transform.gameObject;
    }

    private void StopUsingManivelle(SelectExitEventArgs args)
    {
        isUsing = false;
        interactorGO = null;
        transform.localPosition = standardpos;
    }

    private void Update()
    {
        if(isUsing == true)
        {
            float offset = -0.5f;
            Vector3 trackingLocal = transform.InverseTransformPoint(interactorGO.transform.position);
            gameObject.transform.localPosition = new Vector3(trackingLocal.x + offset, transform.localPosition.y, transform.localPosition.z);
            print(trackingLocal);


            /*float offset = 0f;
            Vector3 tracking = interactorGO.transform.position;
            transform.position = new Vector3(transform.position.x, transform.position.y,tracking.z + offset);*/
            //transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.Clamp((tracking.z + offset),8.1f,8.6f));         // -0.8         -0.2
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("ZDFront"))
        {
            cockpit.transform.Translate(Vector3.forward * speed * Time.deltaTime);
            //print("move forward");
        }

        if(other.gameObject.CompareTag("ZDBack"))
        {
            cockpit.transform.Translate(Vector3.back * speed * Time.deltaTime);
            //print("move backward");
        }
    }
}
