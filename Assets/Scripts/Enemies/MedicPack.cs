using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedicPack : MonoBehaviour
{
    private HPPlayer _hpPlayer;
    private float _healtBonus=50f;
    private void Start()
    {
        _hpPlayer = FindObjectOfType<HPPlayer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (_hpPlayer.hpPlayer+_healtBonus <= 100f)
            {
                _hpPlayer.hpPlayer += _healtBonus;
                
                if (_hpPlayer.hpPlayer > 50f)
                {
                    for (int i = 0; i < _hpPlayer.borkenGlassArray.Length; i++)
                    {
                        _hpPlayer.borkenGlassArray[i].SetActive(false);
                    }
                }
                
            }
            else
            {
                _hpPlayer.hpPlayer = 100f;
                for (int i = 0; i < _hpPlayer.borkenGlassArray.Length; i++)
                {
                    _hpPlayer.borkenGlassArray[i].SetActive(false);
                }
            }
            Destroy(gameObject);
        }
    }
}
