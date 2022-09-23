using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemiScript : MonoBehaviour
{
    public float damageBulletPlayer = 20f;
    [SerializeField] private GameObject rocket;
    [SerializeField] private GameObject bullet;

    private void Start()
    {
        StartCoroutine(StartDecay());
    }

    private void OnTriggerEnter(Collider other)
    {
        //Impact Joueur

        if (other.CompareTag("Player"))
        {
            Debug.Log("joueur dit aie");
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

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log(other.name);
        if (other.CompareTag("Player"))
        {
            Debug.Log("joueur dit aie");
            other.gameObject.GetComponent<HPPlayer>().hpPlayer--;

            if (other.gameObject.GetComponent<HPPlayer>().hpPlayer <= 0)
            {
                other.gameObject.GetComponent<HPPlayer>().Dead();
            }

        }

        //Detruit la balle

        Destroy(rocket);
        Destroy(bullet);
    }

    IEnumerator StartDecay()
    {
        yield return new WaitForSeconds(10);
        Destroy(gameObject);
    }
}
