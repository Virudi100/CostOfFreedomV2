using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
public class GunBehaviour : Viewfinder
{
    public Transform SpawnBullet;
    public GameObject Bullet;
    float _powerImpulseBullet= 3000;
    bool _isPressed;
    private bool canShoot = true;


    private void Update() {
       
            _CrosshairPos();
            if (_isPressed == true && canShoot == true)
            {
                StartCoroutine(_instantiateBulletPrefab());
            }
        
    }
    

    private void OnEnable() {
        TriggerPressedForFire.FireSignalPositiveBool +=_FireBoolTrue;
        TriggerPressedForFire.FireSignalNegativeBool +=_FireBoolFalse;
    }
    private void OnDisable() {
        TriggerPressedForFire.FireSignalPositiveBool -=_FireBoolTrue;
        TriggerPressedForFire.FireSignalNegativeBool -=_FireBoolFalse;
    }

    IEnumerator _instantiateBulletPrefab()
    {
        canShoot = false;

        SpawnBullet.LookAt(RayPos());        
        GameObject _newBullet = Instantiate(Bullet,SpawnBullet.transform.position,Quaternion.identity);
        _newBullet.GetComponent<Rigidbody>().AddForce(SpawnBullet.forward*_powerImpulseBullet);

        yield return new WaitForSeconds(0.3f);
        
        canShoot = true;
    }    

    void _FireBoolTrue(){
        _isPressed=true;
    }
    void _FireBoolFalse(){
        _isPressed=false;
    }
}