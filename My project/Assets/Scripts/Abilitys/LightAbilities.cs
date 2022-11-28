using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightAbilities : MonoBehaviour
{
    public GameObject Light;
    // Start is called before the first frame update
    void Start()
    {
        Light.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Light.SetActive(true);
        GetComponent<GameObject>();
        GameObject.Destroy(gameObject);
    }
}
