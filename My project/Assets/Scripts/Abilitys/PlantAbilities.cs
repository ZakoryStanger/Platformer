using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantAbilities : MonoBehaviour
{
    public GameObject enemy;
    public GameObject plant;
    // Start is called before the first frame update
    void Start()
    {
        plant.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (plant)
        {
                 
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        plant.SetActive(true);
        GetComponent<GameObject>();
        GameObject.Destroy(gameObject);
    }
}
