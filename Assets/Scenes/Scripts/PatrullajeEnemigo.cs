using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrullajeEnemigo : MonoBehaviour
{
    public Transform[] puntosDePatrulla;
    public int puntoObjetivo;
    public float speed;

    void Start()
    {
        puntoObjetivo = 0;
    }


    void Update()
    {
        if (transform.position == puntosDePatrulla[puntoObjetivo].position)
        {
            increaseTargetInt();
        }

        transform.position = Vector3.MoveTowards(transform.position, puntosDePatrulla[puntoObjetivo].position, speed * Time.deltaTime);
    }

    void increaseTargetInt()
    {
        puntoObjetivo++;

        if(puntoObjetivo >= puntosDePatrulla.Length)
        {
            puntoObjetivo = 0;
        }
    }
}
