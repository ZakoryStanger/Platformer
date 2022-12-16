using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.Security.Permissions;

public class Coins : MonoBehaviour
{
    public int coins = 0;
    public TextMeshProUGUI healthText;
    // Start is called before the first frame update
    void Start()
    {
        healthText.text = "Coins: " + coins;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            coins ++;
            healthText.text = "Coins: " + coins;
            Destroy(gameObject);
        }
    }
}
