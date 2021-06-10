using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// Update Text with score value 
/// </summary>
public class UIGameOverManager : MonoBehaviour
{

    public TMP_Text tryAgainText;

    

    // Update is called once per frame
    void Update()
    {
        tryAgainText.text = "Your Score is:" + GameManager.Instance.score;
    }
}
