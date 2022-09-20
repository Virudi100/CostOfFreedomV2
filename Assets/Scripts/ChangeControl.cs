using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeControl : MonoBehaviour
{
    private int indexControl = 0;
    [SerializeField] private Material[] matFrontCockpit;
    [SerializeField] private GameObject controlNormal;
    [SerializeField] private GameObject controlInverse;
    [SerializeField] private Data data;

    private void Start()
    {
        controlNormal.SetActive(true);
        controlInverse.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (data.isplaying == true)
        {
            if (other.CompareTag("PlayerHand"))
            {
                switch (indexControl)
                {
                    case 0:
                        indexControl++;
                        controlNormal.SetActive(false);
                        controlInverse.SetActive(true);
                        gameObject.GetComponent<MeshRenderer>().material = matFrontCockpit[indexControl];
                        break;

                    case 1:
                        indexControl = 0;
                        controlNormal.SetActive(true);
                        controlInverse.SetActive(false);
                        gameObject.GetComponent<MeshRenderer>().material = matFrontCockpit[indexControl];
                        break;
                }
            }
        }

    }
}
