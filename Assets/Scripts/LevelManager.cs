using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject dronePrefab;
    [SerializeField] private Data data;

    [SerializeField] private int spawnIndex = 0;

    [SerializeField] private List<GameObject> enemiesListOne;
    [SerializeField] private List<GameObject> enemiesListTwo;

    [SerializeField] private List<GameObject> enemiesListOneSecond;
    [SerializeField] private List<GameObject> enemiesListTwoSecond;

    //First part
    [Header("First Zone")]
    [SerializeField] private BoxCollider triggerExitSpawn;
    private bool isTrigger = false;
    [SerializeField] private Transform spawnDroneLeftFirst;
    [SerializeField] private Transform spawnDroneRightFirst;
    [SerializeField] private Transform spawnDroneLeftSecond;
    [SerializeField] private Transform spawnDroneRightSecond;
    [SerializeField] private GameObject ffGenerateurL;
    [SerializeField] private GameObject ffGenerateurR;
    [SerializeField] private GameObject generateurL;
    [SerializeField] private GameObject generateurR;
    [SerializeField] private GameObject ffDoor;

    //Second Part
    [Header("Second Zone")]
    [SerializeField] private BoxCollider triggerExitFirstZone;
    private bool isTriggerSecondZone = false;
    [SerializeField] private Transform spawnDroneLeftFirst2;
    [SerializeField] private Transform spawnDroneRightFirst2;
    [SerializeField] private Transform spawnDroneLeftSecond2;
    [SerializeField] private Transform spawnDroneRightSecond2;
    [SerializeField] private GameObject ffGenerateurL2;
    [SerializeField] private GameObject ffGenerateurR2;
    [SerializeField] private GameObject generateurL2;
    [SerializeField] private GameObject generateurR2;
    [SerializeField] private GameObject ffDoor2;

    //End Level
    [Header("End Zone")]
    [SerializeField] private BoxCollider triggerEndLevel;
    private bool isTriggerEndLevel = false;

    private bool inFirstZone = false;
    private bool inSecondZone = false;
    private bool inEndZone = false;

    private void Start()
    {
        data.droneDeadIndex = 0;
        inFirstZone = true;
    }

    void FixedUpdate()
    {
        //First Zone/////////////////////////////////////////////////////////////////////////////////////////////////////
        if (inFirstZone)
        {
            if (isTrigger == false)
            {
                if (triggerExitSpawn.GetComponent<DetectPlayer>().isPlayerPast == true && triggerExitSpawn != null)         //le joueur sort du hangarSpawn
                {
                    isTrigger = true;

                    while (spawnIndex <= 1)             //Spawn les premiers Enemies de Gauche
                    {
                        Debug.Log("Spawn Left");
                        enemiesListOne.Add(Instantiate(dronePrefab, spawnDroneLeftFirst.position, Quaternion.identity));
                        spawnIndex++;
                    }

                    while (spawnIndex <= 3)             //Spawn les premiers Enemies de Droite
                    {
                        Debug.Log("Spawn Right");
                        enemiesListOne.Add(Instantiate(dronePrefab, spawnDroneRightFirst.position, Quaternion.identity));
                        spawnIndex++;
                    }

                    Destroy(triggerExitSpawn.gameObject);
                }
            }
            else if (data.droneDeadIndex == 4)      //si le joueur a tué les premiers enemies
            {

                while (spawnIndex <= 5)             //Spawn les seconds Enemies de Gauche
                {
                    enemiesListTwoSecond.Add(Instantiate(dronePrefab, spawnDroneLeftSecond.position, Quaternion.identity));
                    spawnIndex++;
                }

                while (spawnIndex <= 7)              //Spawn les seconds Enemies de Droite
                {
                    enemiesListTwoSecond.Add(Instantiate(dronePrefab, spawnDroneRightSecond.position, Quaternion.identity));
                    spawnIndex++;
                }
            }
            else if (data.droneDeadIndex >= 8)
            {
                Destroy(ffGenerateurL);
                Destroy(ffGenerateurR);
            }
            if (generateurL == null && generateurR == null)
            {
                Destroy(ffDoor);
                inFirstZone = false;
                inSecondZone = true;
            }
        }

        //Second Zone/////////////////////////////////////////////////////////////////////////////////////////////////////
        if (inSecondZone)
        {
            if (isTriggerSecondZone == false)
            {
                if (triggerExitFirstZone.GetComponent<DetectPlayer>().isPlayerPast == true && triggerExitFirstZone != null)         //le joueur sort du hangarSpawn
                {
                    isTriggerSecondZone = true;

                    while (spawnIndex <= 9)             //Spawn les premiers Enemies de Gauche
                    {
                        Debug.Log("Spawn Left");
                        enemiesListOneSecond.Add(Instantiate(dronePrefab, spawnDroneLeftFirst2.position, Quaternion.identity));
                        spawnIndex++;
                    }

                    while (spawnIndex <= 11)             //Spawn les premiers Enemies de Droite
                    {
                        Debug.Log("Spawn Right");
                        enemiesListOneSecond.Add(Instantiate(dronePrefab, spawnDroneRightFirst2.position, Quaternion.identity));
                        spawnIndex++;
                    }

                    Destroy(triggerExitFirstZone.gameObject);
                }
            }
            else if (data.droneDeadIndex == 12)      //si le joueur a tué les premiers enemies
            {

                while (spawnIndex <= 13)             //Spawn les seconds Enemies de Gauche
                {
                    enemiesListTwo.Add(Instantiate(dronePrefab, spawnDroneLeftSecond2.position, Quaternion.identity));
                    spawnIndex++;
                }

                while (spawnIndex <= 15)              //Spawn les seconds Enemies de Droite
                {
                    enemiesListTwo.Add(Instantiate(dronePrefab, spawnDroneRightSecond2.position, Quaternion.identity));
                    spawnIndex++;
                }
            }
            else if (data.droneDeadIndex >= 16)
            {
                Destroy(ffGenerateurL2);
                Destroy(ffGenerateurR2);
            }
            if (generateurL2 == null && generateurR2 == null)
            {
                Destroy(ffDoor2);
                inSecondZone = false;
                inEndZone = true;
            }
        }

        //End Zone/////////////////////////////////////////////////////////////////////////////////////////////////////
        if (inEndZone)
        {
            if (isTriggerEndLevel == false)
            {
                if (triggerEndLevel.GetComponent<DetectPlayer>().isPlayerPast == true && triggerEndLevel != null)         //le joueur sort du hangarSpawn
                {
                    SceneManager.LoadScene(2);
                }
            }
        }
    }
}


