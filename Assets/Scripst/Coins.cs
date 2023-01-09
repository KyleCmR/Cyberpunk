using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public int coinAcquired;
    [SerializeField] TMPro.TextMeshProUGUI coinsCountText;
    
    public void Add(int count)
    {
        coinAcquired += count;
        coinsCountText.text = "Coins: " + coinAcquired.ToString();
    }
}
