using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCollector : MonoBehaviour
{
    // Declare and/or init variable.
    [Header("Config")]
    [SerializeField] private Text coinsText;
    public int coins = 0;

    private void OnTriggerEnter(Collider other)
    {
        // If player bumps into an object with "Coin" tag, the object will be removed and increments the coin score.
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            coins++;
            coinsText.text = "Coins: " + coins;
        }
    }
}
