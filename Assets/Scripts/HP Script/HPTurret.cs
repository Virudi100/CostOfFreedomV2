using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPTurret : MonoBehaviour
{
    [HideInInspector] public int hpTurret = 2;

    public void Dead()
    {
        //Ded turret

        Destroy(gameObject);

    }
}
