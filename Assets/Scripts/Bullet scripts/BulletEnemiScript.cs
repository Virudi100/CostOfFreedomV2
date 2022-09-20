using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemiScript : MonoBehaviour
{
    Rigidbody _rb;
    public float damageBulletPlayer = 20f;

    private void Start()
    {
        StartCoroutine(StartDecay());
        _rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //Impact Joueur

        if (other.CompareTag("Player"))
        {
            //Debug.Log("joueur dit aie");
            other.gameObject.GetComponent<HPPlayer>().hpPlayer--;

            if (other.gameObject.GetComponent<HPPlayer>().hpPlayer <= 0)
            {
                other.gameObject.GetComponent<HPPlayer>().Dead();
            }
            /*else
                Debug.Log("Player HPLeft: " + other.gameObject.GetComponent<HPPlayer>().hpPlayer);*/
        }

        //Detruit la balle

        Destroy(gameObject);
    }

    IEnumerator StartDecay()
    {
        yield return new WaitForSeconds(10);
        Destroy(gameObject);
    }
}
