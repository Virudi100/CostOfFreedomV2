using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class Viewfinder : MonoBehaviour
{
    public Transform headPosition;
    private RaycastHit hit;
    private RaycastHit hitWindshield;
    private RaycastHit hitWindshieldForNormalGet;
    public GameObject sphereViewfinder;
    public GameObject[] CrosshairCollider;
    public GameObject SpriteCrosshair;
    GameObject _SpriteCrosshair;
    bool _presentCrosshair = false;
    int IgnoreLayerMask = 1 << 2;
    
    [SerializeField] private Data data;

    private void Update()
    {
        if (data.isplaying == true)
        {
            sphereViewfinder.transform.position = RayPos();
        }
    }
    public Vector3 RayPos()
    {
        if (Physics.Raycast(headPosition.transform.position, headPosition.transform.forward, out hit, Mathf.Infinity, ~IgnoreLayerMask))
        {
            return hit.point;
        }

        return Vector3.zero;
        /*else
        {
            hit.point = headPosition.transform.position + headPosition.transform.forward * 100;
            return hit.point;
        }*/
    }
    public Vector3 _CrosshairRayReturnPoint()
    {
        if (Physics.Raycast(headPosition.transform.position, headPosition.transform.forward, out hitWindshield, Mathf.Infinity, IgnoreLayerMask))
        {
            return hitWindshield.point;
        }
        return hitWindshield.point;
    }

    public Vector3 _CrosshairRayReturnNormal()
    {
        if (Physics.Raycast(headPosition.transform.position, headPosition.transform.forward, out hitWindshieldForNormalGet, Mathf.Infinity, IgnoreLayerMask))
        {
            return hitWindshieldForNormalGet.normal;
        }
        return hitWindshieldForNormalGet.normal;
    }

    public void _CrosshairPos()
    {
        if (hitWindshield.point != null)
        {
            if (_presentCrosshair == false)
            {
                _presentCrosshair = true;
                _SpriteCrosshair = Instantiate(SpriteCrosshair, transform.position, transform.rotation);
            }
            _SpriteCrosshair.SetActive(true);
            _SpriteCrosshair.transform.position = _CrosshairRayReturnPoint();      //<-- gros probleme de transform du player qui va vers le centre world
            _SpriteCrosshair.transform.forward = _CrosshairRayReturnNormal();
        }
        else
        {
            _SpriteCrosshair.SetActive(false);
        }
    }
}
