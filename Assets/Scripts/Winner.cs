using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Winner : MonoBehaviour
{
    
    public static string winner;
    private TextMeshProUGUI WinnerText;


    private void Start()
    {
        WinnerText = GetComponent<TextMeshProUGUI>();
        
        WinnerText.text = winner;
    }
}
