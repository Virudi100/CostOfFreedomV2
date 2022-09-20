using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SpawnManagerScriptableObject", order = 1)]
public class Data : ScriptableObject
{
    public int droneDeadIndex = 0;
    public bool isplaying = true;
}
