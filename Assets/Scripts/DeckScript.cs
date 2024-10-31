using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using UnityEngine;

public class DeckScript : MonoBehaviour
{
    public Sprite[] cardSprites;
    int[] cardVal = new int[53];
    int currentIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        GetCardValues();
    }

    // Update is called once per frame
    void GetCardValues()
    {
        for (int i = 0; i < cardSprites.Length; i++)
        {
            int num = i % 13 + 1;  // Ranges from 1 to 13

            // Face cards (Jack, Queen, King) should have a value of 10
            if (num > 10)
            {
                num = 10;
            }

            cardVal[i] = num;
        }
        currentIndex = 0;  // Start dealing from the first card
    }

    public void Shuffle()
    {
        for (int i = cardSprites.Length - 1; i > 0; i--)
        {
            int j = Mathf.FloorToInt(UnityEngine.Random.Range(0.0f, 1.0f) * cardSprites.Length - 1) + 1;
            Sprite face = cardSprites[i];
            cardSprites[i] = cardSprites[j];
            cardSprites[j] = face;

            int value = cardVal[i];
            cardVal[i] = cardVal[j];
            cardVal[j] = value;
        }
        currentIndex = 0;
    }
    public int DealCard(CardScript cardScript)
    {
        cardScript.SetSprite(cardSprites[currentIndex]);
        cardScript.SetValue(cardVal[currentIndex++]);
        currentIndex++;
        return cardScript.GetValueOfCard();
    }
    public Sprite GetCardBack()
    {
        return cardSprites[0];
    }
}
