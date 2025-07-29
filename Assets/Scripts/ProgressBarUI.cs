using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarUI : MonoBehaviour
{
    

    [SerializeField] private Image barImage;
    [SerializeField] private CuttingCounter cuttingCounter;


    private void Start()
    {
        cuttingCounter.OnProGressChanged += CuttingCounter_OnProGressChanged;

        barImage.fillAmount = 0;

        Hide();
    }

    private void CuttingCounter_OnProGressChanged(object sender, CuttingCounter.OnProgressChangedEventArgs e)
    {
        barImage.fillAmount = e.progressNormalized;
        if(e.progressNormalized == 0 || e.progressNormalized == 1)
            Hide();
        else
            Show();
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }
    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
