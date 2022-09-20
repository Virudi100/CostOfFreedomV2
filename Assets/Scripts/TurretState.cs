using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretState : MonoBehaviour
{
    private Rigidbody _rb;
    public Transform anchor;
    public Transform fixation;
    public GameObject player;

    [Header("Shooting")]
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletspeed = 1f;
    private bool _canShoot = true;
    public AudioSource bulletSound;
    
    [SerializeField] private Data data;

    private void Start() {
        _rb = gameObject.GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void FixedUpdate() {
        if (data.isplaying == true)
        {
            Vector3 targetForAnchor = new Vector3(player.transform.position.x, anchor.transform.position.y,
                player.transform.position.z);
            anchor.transform.LookAt(targetForAnchor);
            Vector3 targetForFixation = new Vector3(player.transform.position.x, player.transform.position.y,
                player.transform.position.z);
            fixation.transform.LookAt(targetForFixation);
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
            bulletSound.Play();
            _canShoot = true;
        }
    }
}
