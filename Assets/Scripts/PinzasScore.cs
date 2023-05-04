using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PinzasScore : MonoBehaviour
{   
    public   GameManager control;
    public TextMeshProUGUI puntuacionText;

    private  void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(("Pez") ))
        {

            control.SumarPuntaje();

            

            Debug.Log("Puntuacion" + control.puntuacion);
        }
    }
}
