using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundLife : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Delay());
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
