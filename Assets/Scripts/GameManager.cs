using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public Button dealBtn;
    public Button hitBtn;
    public Button standBtn;
    public Button betBtn;
    void Start()
    {
        // Add Click listerns
        dealBtn.onClick.AddListener(() => DealClicked());
        hitBtn.onClick.AddListener(() => HitClicked());
        standBtn.onClick.AddListener(() => StandClicked());
    } 
    private void DealClicked()
    {
        throw new NotImplementedException();
    }
    private void HitClicked()
    {
        throw new NotImplementedException();
    }
 
    private void StandClicked()
    {
        throw new NotImplementedException();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
