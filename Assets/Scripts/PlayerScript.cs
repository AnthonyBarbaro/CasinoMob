using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    // for Player and Dealer
    // get the other scripts
    public CardScript cardScript;
    public DeckScript deckScript;
    // total value of hand
    public int handValue = 0;
    // how much money they have
    private int money = 1000;
    public GameObject[] hand;
    // tracking index and how many aces to for 1 to 11 
    public int cardIndex = 0;
    List<CardScript> aceList = new List<CardScript>();

    public int GetCard()
    {
        //getting the value
        int cardVal = deckScript.DealCard(hand[cardIndex].GetComponent<CardScript>());
        // showing the card on the game
        hand[cardIndex].GetComponent<Renderer>().enabled = true;
        handValue += cardVal;
        // check to see if its a 1
        if (cardVal == 1)
        {
            aceList.Add(hand[cardIndex].GetComponent<CardScript>());
        }
        cardIndex++;
        return handValue;
    }
    public void StartHand()
    {
        GetCard();
        GetCard();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
