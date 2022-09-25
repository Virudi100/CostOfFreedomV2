using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPTurret : MonoBehaviour
{
    [HideInInspector] public int hpTurret = 2;
    [SerializeField]private GameObject[] _FxExplosion;
    [SerializeField] private AudioSource soundDeadTurret;

    public void Dead()
    {
        GameObject deadSound = Instantiate(soundDeadTurret.gameObject, transform.position, Quaternion.identity);
        deadSound.transform.position = gameObject.transform.position;
        deadSound.GetComponent<AudioSource>().Play();

        for (int i = 0; i < _FxExplosion.Length; i++)
        {
            Quaternion _rotate = Quaternion.Euler(0f, 90f, 0f);
            GameObject _FX = new GameObject();
            _FX = Instantiate(_FxExplosion[0],transform.position+new Vector3(0,2.5f,0),transform.rotation);
            _FX = Instantiate(_FxExplosion[1],transform.position+new Vector3(0,2.5f,0),transform.rotation*_rotate);
            _FX.transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
            _FX.GetComponent<ParticleSystem>().Play();
        }
        
        Destroy(gameObject);
    }
}
