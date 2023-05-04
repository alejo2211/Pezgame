using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class SpawnPez : MonoBehaviour
{
    public Transform[] spwnPez;

    public GameObject prefab;

    private void Update()
    {
        
    }

    void Start()
    {
        StartCoroutine(Insta_Enemi(20));
    }

    IEnumerator Insta_Enemi(int count)
    {
        for (int i = 0; i < count; i++)
        {
            int ran = Random.Range(0, spwnPez.Length);
            GameObject newEnemi = Instantiate(prefab, spwnPez[ran].position, spwnPez[ran].rotation);
            yield return new WaitForSeconds(6);
        }
    }

}
