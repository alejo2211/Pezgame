using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class AgarrePinzas : MonoBehaviour
{
    public Transform Punta;
    public bool Agarrado = false;
    public InputActionProperty trigger;
    public GameObject pez;
    public GameManager control;
    public GameObject particulas;
    public GameObject particulasBien;
    
    private void Start()
    {
    }

    void OnTriggerStay(Collider other)
    {
        float triggerValue = trigger.action.ReadValue<float>();
        if (triggerValue>0.9f && other.gameObject.CompareTag("Pez") && !Agarrado)
        {
            pez.SetActive(true);
            Destroy(other.gameObject);
            Agarrado = true;
        }
    }
    void Update()
    {
        if (Agarrado && trigger.action.ReadValue<float>()<0.2)
        {
            pez.SetActive(false);
            Agarrado = false;
            Instantiate(particulas, pez.transform.position, Quaternion.identity);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Agarrado && other.gameObject.CompareTag("Canasta"))
        {
            Agarrado = false;
            pez.SetActive(false);
            control.SumarPuntaje();
            Instantiate(particulasBien, pez.transform.position, Quaternion.identity);

        }
    }
}
