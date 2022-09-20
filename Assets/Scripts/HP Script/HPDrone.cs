using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPDrone : MonoBehaviour
{
    [HideInInspector] public int hpDrone = 2;
    [SerializeField] private GameObject droneEntier;

    public void Dead()
    {
        //Ded drone

        Destroy(droneEntier);

    }
}
