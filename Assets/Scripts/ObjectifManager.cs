using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ObjectifManager : MonoBehaviour
{
    private List<DroneState_V03> _droneNumber = new List<DroneState_V03>();
    private List<GenerateurHP> _generateurNumber = new List<GenerateurHP>();
    [SerializeField] private Text TextObjectif;
    

    void Update()
    {
        _droneNumber = FindObjectsOfType<DroneState_V03>().ToList();
        _generateurNumber = FindObjectsOfType<GenerateurHP>().ToList();

        TextObjectif.text = "Objectif : - Detruire " + _generateurNumber.Count + " Generateurs " + "- Detruire " +
                            _droneNumber.Count + " ennemies";
    }
}
