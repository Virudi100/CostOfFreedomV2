using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFXDelay : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(StartDecay());
    }

    IEnumerator StartDecay()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}
