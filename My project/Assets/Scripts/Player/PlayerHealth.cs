using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using System;
using System.Threading;

public class PlayerHealth : MonoBehaviour
{
    public int health = 15;
    public Slider slider;
    public TextMeshProUGUI HealthText;
    public bool active = false;
    float timer = 2;
    public float healDelay;
    // Start is called before the first frame update
    void Start()
    {
        slider.maxValue = health;
        slider.value = health;
    }

    // Update is called once per frame
    void Update()
    {
        HealthText.text = "RED=" + health;
        timer = Time.deltaTime;
        if (active)
        {
            if (health < 50)
            {
                health ++;
            }
            if (health > 50)
            {
                health = 50;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "EnemyBullet(Clone)")
        {
            health--;
            slider.value = health;
            if (health <= 0)
            {
                Scene scene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(scene.name);
            }
            
        }
        if (collision.gameObject.tag == "LightPowerUp")
        {
            active = true;
        }
    }
}
