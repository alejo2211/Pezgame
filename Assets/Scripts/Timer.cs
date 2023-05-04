using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timer = 0f;
    public TextMeshProUGUI textoTimer;
    public GameObject gameOver;
   
    void Update()
    {
        textoTimer.text = "" + (Mathf.CeilToInt( timer)).ToString();
        if (timer < 0)
        {
            gameOver.SetActive(true);
        }
        else
        {

            timer -= Time.deltaTime;
        }
    }
}
