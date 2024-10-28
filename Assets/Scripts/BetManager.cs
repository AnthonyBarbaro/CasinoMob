using UnityEngine;
using TMPro; // Import the TextMeshPro namespace

public class BetManager : MonoBehaviour
{
    public int playerBalance = 1000; // Player starts with $1000
    public int currentBet = 0;       // Current bet amount

    public TextMeshProUGUI balanceText; // Reference to the balance text UI
    public TextMeshProUGUI betText;     // Reference to the current bet text UI

    void Start()
    {
        UpdateUI(); // Initialize the UI at the start of the game
    }

    // Method to add a bet
    public void AddToBet(int amount)
    {
        if (playerBalance >= amount)
        {
            currentBet += amount;
            playerBalance -= amount;
            UpdateUI(); // Update the UI after placing the bet
        }
        else
        {
            Debug.Log("Not enough balance to place this bet.");
        }
    }

    // Method to clear the current bet
    public void ClearBet()
    {
        playerBalance += currentBet; // Return the bet to the balance
        currentBet = 0;              // Reset the current bet amount
        UpdateUI();                  // Update the UI
    }

    // Method to update the UI
    void UpdateUI()
    {
        balanceText.text = "Cash: $" + playerBalance.ToString(); // Update the balance text
        betText.text = "Bet: $" + currentBet.ToString();            // Update the bet text
    }
}
