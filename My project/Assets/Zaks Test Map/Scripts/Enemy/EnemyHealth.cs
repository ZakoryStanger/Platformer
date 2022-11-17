using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class EnemyHealth : MonoBehaviour
{
    public GameObject GameObject;
    public Slider slider;
    public string nextLVL;
    public int health = 15;
    // Start is called before the first frame update
    void Start()
    {
        slider.maxValue = health;
        slider.value = health;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Object.Destroy(GameObject);

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "PlayerBullet(Clone)")
        {
            health--;
            slider.value = health;
        }
        slider.value = health;
        Destroy(collision.gameObject);
    }
}