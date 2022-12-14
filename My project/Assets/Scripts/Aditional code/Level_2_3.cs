using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_2_3 : MonoBehaviour
{
    public bool active = false;
    // Start is called before the first frame update
    void Start()
    {
        if (active)
        {
            SceneManager.LoadScene("LVL3");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            active = true;
        }
    }
}
