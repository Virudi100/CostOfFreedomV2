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

    private Vector3 prevInteractorPos;

    private void Awake()
    {
        standardpos = simple.gameObject.transform.localPosition;
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
        prevInteractorPos = Vector3.zero;                   //si la position precedente = 0
        
        interactorGO = null;
        simple.gameObject.transform.localPosition = standardpos;
    }

    private void Update()
    {
        if(isUsing == true)
        {
            if (prevInteractorPos == Vector3.zero)                    //si la position precedente = 0
            {
                prevInteractorPos = interactorGO.transform.localPosition;
            }

            Vector3 delta = interactorGO.transform.localPosition - prevInteractorPos;

            prevInteractorPos = interactorGO.transform.localPosition;

            Vector3 deplacement = new Vector3(delta.x * simple.gameObject.transform.forward.x, delta.y * simple.gameObject.transform.forward.y, delta.z * simple.gameObject.transform.forward.z);
            Vector3 clamp = new Vector3(deplacement.x, deplacement.y, Mathf.Clamp(deplacement.z, -0.28f,0.28f));

            simple.gameObject.transform.localPosition += clamp;


            /*
            float offset = -0.5f;
            Vector3 trackingLocal = transform.InverseTransformPoint(interactorGO.transform.position);
            gameObject.transform.localPosition = new Vector3(trackingLocal.x + offset, transform.localPosition.y, transform.localPosition.z);
            print(trackingLocal);*/
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
