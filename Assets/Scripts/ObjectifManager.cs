using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class ObjectifManager : MonoBehaviour
{
    
    public int _numberDrone;
    public Text TextObjectif;
    private string _droneString;
    private string _TotalString;

    
    private void FixedUpdate()
    {
        
        if (_numberDrone > 0)
        {
            _droneString = "@- Detruire : " + _numberDrone + " ennemies";
        }
        else
        {
            _droneString = "";
        }
        
        _TotalString = "Objectif : " + _droneString;
        _TotalString = _TotalString.Replace("@", Environment.NewLine);
        TextObjectif.text = _TotalString;

    }
}
