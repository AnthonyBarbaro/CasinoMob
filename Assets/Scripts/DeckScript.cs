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
        
    }

    // Update is called once per frame
    void GetCardValues()
    {
        int num = 0;
        for (int i = 0; i < cardSprites.Length; i++)
        {
            num = i;
            // count up to the amount of cards, 52
            // module to get the deck
            num %= 13;
            if (num > 10 || num == 0)
            {
                num = 10;
            }
            cardVal[i] = num++;
        }
        currentIndex = 1;
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
