using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Manivelle : MonoBehaviour
{
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

            Vector3 deplacement = new Vector3(delta.x * simple.gameObject.transform.InverseTransformDirection(simple.gameObject.transform.forward).x, delta.y * simple.gameObject.transform.InverseTransformDirection(simple.gameObject.transform.forward).y, delta.z * simple.gameObject.transform.InverseTransformDirection(simple.gameObject.transform.forward).z);

            simple.gameObject.transform.localPosition += deplacement;

            Vector3 clamped = new Vector3(simple.gameObject.transform.localPosition.x, simple.gameObject.transform.localPosition.y,Mathf.Clamp(simple.gameObject.transform.localPosition.z, -0.28f, 0.28f));

            simple.gameObject.transform.localPosition = clamped;


            /*
            float offset = -0.5f;
            Vector3 trackingLocal = transform.InverseTransformPoint(interactorGO.transform.position);
            gameObject.transform.localPosition = new Vector3(trackingLocal.x + offset, transform.localPosition.y, transform.localPosition.z);
            print(trackingLocal);*/
        }
    }


    
}
