using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager manager;
    public TextMeshProUGUI puntuacionText;

     public int puntuacion;

   
    public void SumarPuntaje()
    {
        puntuacion++;
        puntuacionText.text = "PUNTAJE: " + puntuacion.ToString();
        Debug.Log("Peces agarrados" + puntuacionText);

    }
}
