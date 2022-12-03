using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TextUI : MonoBehaviour
{
    private TextMeshProUGUI textMeshProUGUI;
    
    // Start is called before the first frame update
    void Start()
    {
        textMeshProUGUI = gameObject.GetComponent<TextMeshProUGUI>();        
    }

    // Update is called once per frame
    void Update()
    {
        textMeshProUGUI.text = "Array: [" + GameManager.instance.Text[0] + "," + GameManager.instance.Text[1] + "," + GameManager.instance.Text[2] + "," + GameManager.instance.Text[3] + "," + GameManager.instance.Text[4] + "," + GameManager.instance.Text[5] + "," + GameManager.instance.Text[6] + "]";
    }
}
