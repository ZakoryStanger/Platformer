using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Level_1_2 : MonoBehaviour
{
    public bool active = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            SceneManager.LoadScene("LVL2");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        active = true;
    }
}
