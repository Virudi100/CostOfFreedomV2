using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretState : MonoBehaviour
{
    public Transform anchor;
    public Transform fixation;
    public GameObject player;

    [Header("State Machine")]
    public turretStatut state = turretStatut.None;
    public turretStatut nextState = turretStatut.None;

    [Header("Shooting")]
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletspeed = 1f;
    private bool _canShoot = true;
    public AudioSource bulletSound;

    [Header("Detection")]
    [SerializeField] private Transform canonTurret;
    public int detectionIndex = 100;

    [Header("Data")]
    [SerializeField] private Data data;

    [Header("Destroyed Model")]
    public GameObject destroyedGo;

    [Header("Raycast")]
    private RaycastHit rayHit;
    Vector3 direction;

    //Bool: le player a t'il etait detecter ?
    private bool playerDetected = false;

    public enum turretStatut
    {
        None,
        Shooting,
        Patrol,
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        state = turretStatut.Patrol;
        destroyedGo.SetActive(false);
    }
    private void FixedUpdate()
    {
        if (data.isplaying == true)
        {

            if (CheckForTransition())
            {
                TransitionOrChangeState();
            }
            StateBehavior();
        }
    }

    private bool CheckForTransition()
    {
        switch (state)
        {
            case turretStatut.None:
                break;

            case turretStatut.Shooting:                     //Si le joueur n'est plus detecter je repasse en patrouille

                if (!playerDetected)
                {
                    nextState = turretStatut.Patrol;
                    return true;
                }
                break;

            case turretStatut.Patrol:                   //Si le joueur est detecter je passe en alerte

                if (playerDetected)
                {
                    nextState = turretStatut.Shooting;
                    return true;
                }
                break;
        }
        return false;
    }

    // on applique les actions associées au transitions
    private void TransitionOrChangeState()
    {
        switch (nextState)
        {
            case turretStatut.None:
                break;


            case turretStatut.Shooting:
                break;

            case turretStatut.Patrol:;
                break;
        }
        state = nextState;
    }

    // on applique le comportement des états
    private void StateBehavior()
    {
        switch (state)
        {
            case turretStatut.None:
                break;

            case turretStatut.Shooting:
                TurnTurret();
                Detecte();
                if (_canShoot == true)
                {
                    _canShoot = false;
                    StartCoroutine(Shoot());
                }
                break;

            ///////////////////////////

            case turretStatut.Patrol:
                Detecte();
                break;

            //////////////////////////
        }
    }

    private void Detecte()
    {
        if (player.gameObject != null)
        {
            direction = Vector3.Normalize(player.transform.position - canonTurret.position);

            if (Physics.Raycast(canonTurret.position, direction, out rayHit, detectionIndex))
            {
                if (rayHit.collider.gameObject.CompareTag("Player"))
                {
                    playerDetected = true;
                }
                else
                    playerDetected = false;

                Debug.DrawRay(canonTurret.position, direction, Color.green);
            }
        }
    }

    private void TurnTurret()
    {
        if (playerDetected)
        {
            fixation.transform.rotation = Quaternion.LookRotation(new Vector3(direction.x, direction.y, direction.z) * Time.deltaTime);
        }
    }


    private IEnumerator Shoot()
    {
        GameObject NewBullet = Instantiate(bulletPrefab, bulletSpawnPoint.transform.position, bulletSpawnPoint.transform.rotation);
        //NewBullet.GetComponent<Rigidbody>().AddForce(bulletSpawnPoint.forward * bulletspeed);
        yield return new WaitForSeconds(4f);
        bulletSound.Play();
        _canShoot = true;

    }
}
