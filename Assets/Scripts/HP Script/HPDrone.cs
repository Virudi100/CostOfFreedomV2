using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPDrone : MonoBehaviour
{
    [HideInInspector] public int hpDrone = 2;
    [SerializeField] private GameObject droneEntier;
    [SerializeField]private GameObject[] _FxExplosion;
    private ObjectifManager _objectifManager;

    private void Start()
    {
        _objectifManager = GetComponent<ObjectifManager>();
    }

    public void Dead()
    {
        for (int i = 0; i < _FxExplosion.Length; i++)
        {
            GameObject _FX = new GameObject();
            _FX = Instantiate(_FxExplosion[i],transform.position,transform.rotation);
            _FX.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            _FX.GetComponent<ParticleSystem>().Play();
        }

        _objectifManager._numberDrone--;
        Destroy(droneEntier);

    }
}
