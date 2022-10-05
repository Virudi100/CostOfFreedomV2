using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;

public class LevelManagerEndScene : MonoBehaviour
{
    
    void Start()
    {
        var _player = GameObject.FindGameObjectWithTag("Player");
        var _LifeBar = GameObject.FindGameObjectWithTag("Life bar");
        var _crosshair = GameObject.FindGameObjectWithTag("Crosshair");
        
        if (_player != null)
        {
            _LifeBar.SetActive(false);
            _crosshair.SetActive(false);
        }
    }
}
