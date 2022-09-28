using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;


public class TutorialManager : ObjectifManager
{

    public Data lenomquetuveux;
    private int _droneleft = 2;

    public void Start()
    {
        lenomquetuveux.isplaying = true;
    }

    void OnEnable()
    {
        HPDrone.OndroneDestroyed += LevelLoader;
    }

    void OnDisable()
    {
        HPDrone.OndroneDestroyed -= LevelLoader;
    }

    private void LevelLoader()
    {
        _droneleft --;
        {
            if (_droneleft == 0)
            {
                
                StartCoroutine(LoadingDelay());   
               // Debug.Log("Changement de Scene !!!");
                SceneManager.LoadScene("Level1");
            }
        }
    }

    private IEnumerator LoadingDelay()
    {
        yield return new WaitForSeconds(15f);
    }




}
