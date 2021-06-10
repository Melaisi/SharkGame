using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{

    public GameObject[] hearts;

    private void Start()
    {
        GameManager.Instance.onHealthChange += refreshHealthUI;
    }

    public void refreshHealthUI()
    {
        bool flag = true;
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i == GameManager.Instance.Health)
            {
                flag = false;
            }
            hearts[i].SetActive(flag);
        }
    }

    private void OnDestroy()
    {

        GameManager.Instance.onHealthChange -= refreshHealthUI;
    }

}
