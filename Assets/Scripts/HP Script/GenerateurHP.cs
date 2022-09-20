using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateurHP : MonoBehaviour
{
    [HideInInspector] public int hpGenerateur = 2;
    [SerializeField] private GameObject destroyed;

    private void Start()
    {
        destroyed.SetActive(false);
    }

    public void Dead()
    {
        destroyed.SetActive(true);
        Destroy(gameObject);
    }
}
