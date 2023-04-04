using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PanelCharacterInfo : MonoBehaviour
{
    public double threshold = 2f;
    double PressHoldTimer;
    bool isholding;
    Image test;

    public void StartHold(GameObject filler)
    {
        test = filler.GetComponent<Image>();
        test.fillAmount = 0;
        test.gameObject.SetActive(true);
        isholding = true;
        PressHoldTimer = 0;
    }

    private void Update()
    {
        if (isholding)
        {
            PressHoldTimer += Time.deltaTime;
            if (PressHoldTimer > 1f)
            {
                test.fillAmount = (float)PressHoldTimer - 1f;
            }
        }
    }
    public void StopHold(GameObject selectPanel)
    {
        if (PressHoldTimer > 2f)
        {
            selectPanel.SetActive(true);
        }

        isholding = false;
        test.fillAmount = 0;
        test.gameObject.SetActive(false);
        Debug.Log("Holding time: " + PressHoldTimer);
    }

}