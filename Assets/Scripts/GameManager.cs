using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.RestService;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public Button dealBtn;
    public Button hitBtn;
    public Button standBtn;
    public Button betBtn;

    private int standClicks = 0;

    // all the Text elements 
    public Text standBtnText;
    public Text scoreText;
    public Text dealerScoreText;
    public Text betsText;
    public Text cashText;
    //public Text mainText;
    // Card Hiding Dealers 2nd Card
    public GameObject hideCard;
    int pot = 0;

    // Access the player and dealers script

    public PlayerScript playerScript;
    public PlayerScript dealerScript;
    void Start()
    {
        // Add Click listerns
        dealBtn.onClick.AddListener(() => DealClicked());
        hitBtn.onClick.AddListener(() => HitClicked());
        standBtn.onClick.AddListener(() => StandClicked());
    } 
    private void DealClicked()
    {
        //Hide dealer hand score at the start
        dealerScoreText.gameObject.SetActive(false);    
        GameObject.Find("DECK").GetComponent<DeckScript>().Shuffle();
        playerScript.StartHand();
        dealerScript.StartHand();
        // to display Score 
        scoreText.text = "Hand: " +  playerScript.handValue.ToString();
        dealerScoreText.text = "Dealer Hand: " + dealerScript.handValue.ToString();

        //remove the buttons after deal 

        dealBtn.gameObject.SetActive(false);
        hitBtn.gameObject.SetActive(true);
        standBtn.gameObject.SetActive(true);
        standBtnText.text = "Stand";
        // Set Standard Pot Size
        pot = 40;
        betsText.text = pot.ToString();

    }
    private void HitClicked()
    {
        //Check that there is room
        if(playerScript.GetCard() <= 10)
        {
            playerScript.GetCard();
        }
    }
 
    private void StandClicked()
    {
        standClicks++;
        if (standClicks > 1) Debug.Log("end Function");
        HitDealer();
        standBtnText.text = "Call";
    }
    private void HitDealer()
    {
        while (dealerScript.handValue < 16 && dealerScript.cardIndex < 10)
        {
            dealerScript.GetCard();
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
