using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgarrePinzas : MonoBehaviour
{
    public Transform Punta;
    public bool Agarrado = false;
    private Rigidbody rb;
    private Collider ObjetoCollider;

    private void Start()
    {
        rb = Punta.GetComponent<Rigidbody>();
        ObjetoCollider = Punta.GetComponent<Collider>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (!Agarrado&&other.gameObject.CompareTag("Pez"))
        {
            Punta.position = other.transform.position;
            other.transform.parent = Punta;
            other.transform.localPosition = Vector3.zero;
            other.transform.localRotation = Quaternion.identity;
            Agarrado = true;
        }
    }
    void Update()
    {
        if (Agarrado)
        {
            Punta.position = transform.position;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (Agarrado && other.gameObject.CompareTag("Canasta"))
        {
            Agarrado = false;
            Transform pez = Punta.GetChild(0);
            pez.parent = null;
            pez.gameObject.AddComponent<Rigidbody>();
            Punta.position = transform.position;
        }
    }
}
