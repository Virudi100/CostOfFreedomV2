using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPTurret : MonoBehaviour
{
    [HideInInspector] public int hpTurret = 2;
    [SerializeField]private GameObject[] _FxExplosion;

    public void Dead()
    {
        for (int i = 0; i < _FxExplosion.Length; i++)
        {
            GameObject _FX = new GameObject();
            _FX = Instantiate(_FxExplosion[i],transform.position+new Vector3(0,3f,0),transform.rotation);
            _FX.transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
            _FX.GetComponent<ParticleSystem>().Play();
        }
        Destroy(gameObject);
    }
}
