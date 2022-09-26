using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class ObjectifManager : MonoBehaviour
{
    private int _numberDrone=0;
    public Text _ObjectifText;
    [SerializeField] private AudioSource aSourceObjectif;

    private void OnEnable()
    {
        LevelManager.spawnDrone += addDrone;
        HPDrone.DeadDrone += RemoveDrone;
    }

    private void OnDisable()
    {
        LevelManager.spawnDrone -= addDrone;
        HPDrone.DeadDrone -= RemoveDrone;
    }

    void addDrone()
    {
        _numberDrone++;
        UpdatText();
    }

    void RemoveDrone()
    {
        _numberDrone--;
        UpdatText();
        if(_numberDrone == 0)
        {
            aSourceObjectif.Play();
        }
    }

    void UpdatText()
    {
        if (_numberDrone > 0)
        {
            _ObjectifText.text =
                "-Detruire : " + _numberDrone + " drone ennemies";
        }
        else
        {
            _ObjectifText.text = "";
        }
    }
}
