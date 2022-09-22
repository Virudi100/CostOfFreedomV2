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

    private float prevInteractorPosZ = 0f;

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

        if (prevInteractorPosZ == 0f)                    //si la position precedente = 0
        {
            prevInteractorPosZ = interactorGO.transform.localPosition.z;
        }

        
    }

    private void StopUsingManivelle(SelectExitEventArgs args)
    {
        isUsing = false;
        prevInteractorPosZ = 0f;                   //si la position precedente = 0
        
        interactorGO = null;
        transform.localPosition = standardpos;
    }

    private void Update()
    {
        if(isUsing == true)
        {
            float delta = Mathf.Clamp(interactorGO.transform.localPosition.z - prevInteractorPosZ, -0.1f, 0.1f);

            prevInteractorPosZ = interactorGO.transform.localPosition.z;

            transform.localPosition = new Vector3(delta * transform.forward.x, delta * transform.forward.y, delta * transform.forward.z);


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
