using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    //public GameObject manager;
    public TextMeshProUGUI puntuacionText;

    int puntuacion;

    public void Puntaje()
    {
        puntuacion++;
        puntuacionText.text = "PUNTAJE: " + puntuacion.ToString();
    }
}
