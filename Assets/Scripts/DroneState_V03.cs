using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DroneState_V03 : MonoBehaviour
{
    NavMeshAgent _navMesh;
    private Rigidbody _rb;
    public Transform player;


    [Header("Shooting")]
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletspeed = 2f;
    private bool _canShoot = true;
    [SerializeField] private Data data;
    public AudioSource drone_shot_sound;
    public GameObject FXFire;
    
    

    private void Start()
    {

        _navMesh = gameObject.GetComponent<NavMeshAgent>();
        _rb = gameObject.GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void FixedUpdate()
    {
        if (data.isplaying == true)
        {
            _navMesh.SetDestination(player.transform.position);
            _navMesh.stoppingDistance = 8.0f;
            Vector3 playerTargeted = new Vector3(player.transform.position.x, transform.position.y - 0.4f,
                player.transform.position.z);
            gameObject.transform.LookAt(playerTargeted);
            StartCoroutine(Shoot());
        }
    }

    private IEnumerator Shoot()
    {
        if (_canShoot == true)
        {
            _canShoot = false;
            GameObject NewBullet = Instantiate(bulletPrefab, bulletSpawnPoint.transform.position, bulletSpawnPoint.transform.rotation);
            NewBullet.GetComponent<Rigidbody>().AddForce(bulletSpawnPoint.forward * bulletspeed);
            yield return new WaitForSeconds(1f);
            drone_shot_sound.Play();
            FXFire.GetComponent<ParticleSystem>().Play();
            _canShoot = true;
        }
    }
}
