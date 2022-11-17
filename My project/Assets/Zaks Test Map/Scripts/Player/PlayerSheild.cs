using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Timers;
using UnityEngine;
using TMPro;

public class PlayerSheild : MonoBehaviour
{

    public GameObject player;
    public GameObject prefab;
    float timer = 0;
    public float summondelay = 1.0f;
    public AudioClip shootSound;
    public int sheildHealth = 10;
    public TextMeshProUGUI healthText;
    public bool active = false;
    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale > 0)

            //when the mouse is clicked
            if (Input.GetButtonDown("Fire3") && active)
            {
                GameObject Sheild = Instantiate(prefab, transform.position, Quaternion.identity);
                Sheild.GetComponent<Rigidbody2D>().velocity = new Vector2(10, 0);
                Vector3 mousePosition = Input.mousePosition;
                mousePosition.z = -Camera.main.transform.position.z;
                mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
                Vector2 shootDir = mousePosition - transform.position;
                shootDir.Normalize();
                Sheild.GetComponent<Rigidbody2D>().velocity = shootDir;
                Sheild.transform.up = shootDir;
                Destroy(Sheild, sheildHealth);
                sheildHealth = 10;
            }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "IcePowerUp")
        {
            active = true;
        }
    }
}
