using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    Rigidbody _rb;
    public int damageBulletPlayer = 20;
    [SerializeField] Data data;

    private void Start()
    {
        StartCoroutine(StartDecay());
        _rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other){
            Debug.Log(other.gameObject.name);
        }

        //Impact Drone

        if (other.CompareTag("drone"))
        {
            Debug.Log("je touche le drone");
            other.gameObject.GetComponent<HPDrone>().hpDrone--;
            
            if (other.gameObject.GetComponent<HPDrone>().hpDrone <= 0)
            {
                data.droneDeadIndex++;
                other.gameObject.GetComponent<HPDrone>().Dead();
            }
        }

        //Impact Tourelle
        if (other.CompareTag("turret"))
        {
            Debug.Log("je touche une tourelle");
            other.gameObject.GetComponent<HPTurret>().hpTurret--;

            if(other.gameObject.GetComponent<HPTurret>().hpTurret <= 0)
            {
                other.gameObject.GetComponent<HPTurret>().Dead();
            }
            /*else
                Debug.Log("Turret HPLeft: " + other.gameObject.GetComponent<HPPlayer>().hpPlayer);
            */
        }


        //Impact Generateur

        if (other.CompareTag("generateur"))
        {
            Debug.Log("je touche un generateur");

            other.gameObject.GetComponent<GenerateurHP>().hpGenerateur--;

            if(other.gameObject.GetComponent<GenerateurHP>().hpGenerateur <= 0)
            {
                other.gameObject.GetComponent<GenerateurHP>().Dead();
            }
        }

        //Detruit la balle

        Destroy(gameObject);
    }

    IEnumerator StartDecay(){
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
