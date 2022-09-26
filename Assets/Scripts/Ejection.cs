using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(Rigidbody))]
public class Ejection : MonoBehaviour
{

    private Rigidbody rb;
    [SerializeField] private HPPlayer player;
    [SerializeField] private XRSimpleInteractable simple;
    public bool isEjected = false;
    [SerializeField] private Data data;
    

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        simple.selectEntered.AddListener(StartUsingManivelle);
    }

    private void OnDisable()
    {
        simple.selectEntered.RemoveListener(StartUsingManivelle);
    }

    private void StartUsingManivelle(SelectEnterEventArgs args)
    {
        if (data.isplaying == true)
        {
            if (isEjected == false)
            {
                isEjected = true;

                StartCoroutine(Eject());
            }
        }
    }

    IEnumerator Eject()
    {
        gameObject.GetComponent<BoxCollider>().enabled = false;
        gameObject.transform.parent = null;
        rb.isKinematic = false;
        rb.useGravity = true;
        rb.AddForce(Vector3.up * 2000f);
        player.DeadEjection();

        yield return new WaitForSeconds(1.5f);

        gameObject.GetComponent<CapsuleCollider>().enabled = true;


    }
}
