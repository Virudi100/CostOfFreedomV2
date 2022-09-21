using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HPPlayer : MonoBehaviour
{
    public float hpPlayer, maxHpPlayer = 100f;
    float hpPlayerForBarLife, maxhpPlayerForBarLife;
    public Image lifeBarSprite;
    public GameObject[] borkenGlassArray;
    public GameObject[] _spotLightShutDown;
    public GameObject GameOverSprite;
    private bool _boolDead;
    public Text TextEnumerationLoadSceneOne;
    float _pauseGame = 0f;
    int _time = 5;
     private bool _nexTime;

    [Header("Ejection")]
    public Text TextEnumerationLoadSceneOneEjection;
    public GameObject GameOverSpriteEjection;

    [SerializeField] private Data data;

    private void FixedUpdate()
    {
        if (data.isplaying == true)
        {
            hpPlayerForBarLife = Mathf.Lerp(0.05f, 1f, hpPlayer / maxHpPlayer);
            lifeBarSprite.fillAmount = hpPlayerForBarLife;

            switch (hpPlayer) //HP bar
            {
                case 50:
                    borkenGlassArray[0].SetActive(true);
                    break;
                case 30:
                    borkenGlassArray[1].SetActive(true);
                    break;
                case 10:
                    borkenGlassArray[2].SetActive(true);
                    break;
                case 0:
                    data.isplaying = false;
                    break;
            }

            Debug.Log(_time);
        }
        else
        {
            Dead();
        }
    }

    public void Dead()
    {
        data.isplaying = false;


        GameOverSprite.SetActive(true);
        _boolDead = true;
        for (int i = 0; i < _spotLightShutDown.Length; i++)
        {
            _spotLightShutDown[i].SetActive(false);
        }


        if (_boolDead == true)
        {
            if (_nexTime == false)
            {
                StartCoroutine(CoroutineForLoadSceneOne());
            }

            TextEnumerationLoadSceneOne.text = ("You dead, return in load scene in : " + _time);
        }

        if (_time <= 0)
        {
            SceneManager.LoadScene(0);
        }
    }

    public void DeadEjection()
    {
        data.isplaying = false;


        GameOverSpriteEjection.SetActive(true);
        _boolDead = true;
        for (int i = 0; i < _spotLightShutDown.Length; i++)
        {
            _spotLightShutDown[i].SetActive(false);
        }


        if (_boolDead == true)
        {
            if (_nexTime == false)
            {
                StartCoroutine(CoroutineForLoadSceneOne());
            }

            TextEnumerationLoadSceneOneEjection.text = ("You dead, return in load scene in : " + _time);
        }

        if (_time <= 0)
        {
            SceneManager.LoadScene(0);
        }
    }

    IEnumerator CoroutineForLoadSceneOne()
    {
        _nexTime = true;
        yield return new WaitForSeconds(_time);
        _nexTime = false;
        _time--;

    }


}
