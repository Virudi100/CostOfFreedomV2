using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public GameObject lookUp;
    public GameObject lookDown;
    private float _canvasCountdown;
    private float currCountdownValue;
    private float currCountdownValueBis;
    private void Start()
    {
        StartCoroutine(StartCountdown());
        StartCoroutine(StartCountdownBis());
    }

    public IEnumerator StartCountdown(float countdownvalue = 10)
    {
        currCountdownValue = countdownvalue;
        while (currCountdownValue > 0)
        {
            Debug.Log("countdown " + currCountdownValue);
            yield return new WaitForSeconds(1.0f);
            currCountdownValue--;
            lookUp.gameObject.SetActive(true);
        }
        lookUp.gameObject.SetActive(false);
        lookDown.gameObject.SetActive(true);
    }
   
    public IEnumerator StartCountdownBis(float countdownvalueBis = 20)
    {
        currCountdownValueBis = countdownvalueBis;
        while (currCountdownValueBis > 0)
        {
            Debug.Log("countdown " + currCountdownValueBis);
            yield return new WaitForSeconds(1.0f);
            currCountdownValueBis--;
        }
        lookDown.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
