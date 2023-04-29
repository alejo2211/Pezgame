using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pez : MonoBehaviour
{
    public GameObject[] checkPoints;
    public int indice;
    public float velocidad = 1;
    public float amplitudOnda;
    public float frecuenciaOnda;
    public AnimationCurve curvaSalta;
    public float alturaSalto;
    public Vector2 tiemposSaltos;
    public bool saltando = false;
    public float periodoSalto = 3;

    float tiempoSaltar;

    void Start()
    {
        checkPoints = GameObject.FindGameObjectsWithTag("point");
        CambiarCP();
        CambiarTiempoSaltar();
    }


    void Update()
    {
        Vector3 direccion = (checkPoints[indice].transform.position - transform.position);
        transform.forward = Vector3.Lerp(transform.forward, direccion.normalized, Time.deltaTime * 2f);

        if (!saltando)
        {
            if (tiempoSaltar < Time.time)
            {
                StartCoroutine(Saltar());
            }
            transform.Translate(amplitudOnda * Time.deltaTime * Mathf.Cos(Time.time * frecuenciaOnda), 0, velocidad * Time.deltaTime);
        }

        if (direccion.magnitude < 0.4f)
        {
            CambiarCP();
        }
    }

    IEnumerator Saltar()
    {
        saltando = true;

        for (int i = 0; i <= 40; i++)
        {
            transform.position = new Vector3(
                                              transform.position.x,
                                              checkPoints[indice].transform.position.y + curvaSalta.Evaluate(i/40f) * alturaSalto,
                                              transform.position.z);
            yield return new WaitForSeconds(Time.deltaTime * periodoSalto);
        }

        for (int i = 40; i >= 0; i--)
        {
            transform.position = new Vector3(
                                              transform.position.x,
                                              checkPoints[indice].transform.position.y + curvaSalta.Evaluate(i/40f) * alturaSalto,
                                              transform.position.z); 
            yield return new WaitForSeconds(Time.deltaTime * periodoSalto);
        }

        CambiarTiempoSaltar();
        saltando = false;
    }

    public void CambiarCP()
    {
        int nuevo;

        do
        {
            nuevo = Random.Range(0, checkPoints.Length);
        } while (nuevo == indice);
        indice = nuevo;
    }

    public void CambiarTiempoSaltar()
    {
        tiempoSaltar = Time.time + Random.Range(tiemposSaltos.x, tiemposSaltos.y);
    }
    public void Sumar()
    {
        GameManager manager = GameObject.Find("Manager").GetComponent<GameManager>();
        manager.Puntaje();
    }
}
