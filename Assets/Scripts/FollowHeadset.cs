using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowHeadset : MonoBehaviour
{
    [SerializeField] private GameObject vrHeadset;
    
    [SerializeField] private Data data;

    private void Update()
    {
        if (data.isplaying == true)
        {
            gameObject.transform.position = vrHeadset.transform.position;
        }
    }
}
