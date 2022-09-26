using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPDrone : MonoBehaviour
{
    [HideInInspector] public int hpDrone = 2;
    [SerializeField] private GameObject droneEntier;
    [SerializeField]private GameObject[] _FxExplosion;
    public static Action DeadDrone;
    [SerializeField] private AudioSource soundDeadDrone;

    public delegate void droneKilled();
    public static  event droneKilled OndroneDestroyed;
    
    public void Dead()
    {

        GameObject deadSound = Instantiate(soundDeadDrone.gameObject, transform.position, Quaternion.identity);
        deadSound.transform.position = gameObject.transform.position;
        deadSound.GetComponent<AudioSource>().Play();

        for (int i = 0; i < _FxExplosion.Length; i++)
        {
            GameObject _FX = Instantiate(_FxExplosion[i],transform.position,transform.rotation);
            _FX.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            _FX.GetComponent<ParticleSystem>().Play();
        }
        OndroneDestroyed?.Invoke();
        SignalLaunchRemoveObjectifManager();
        
        Destroy(droneEntier);
    }

    public void SignalLaunchRemoveObjectifManager()
    {
        DeadDrone?.Invoke();
    }

    
}
