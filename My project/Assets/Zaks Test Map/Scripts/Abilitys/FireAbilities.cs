using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAbilities : MonoBehaviour
{
    public GameObject Fire;
    public GameObject prefab;
    public float BulletSpeed = 10.0f;
    public float bulletlifetime = 2.0f;
    public bool active = false;
    // Start is called before the first frame update
    void Start()
    {
        Fire.SetActive(false);
        active = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Fire.SetActive(true);
        active = true;
        GetComponent<GameObject>();
        GameObject.Destroy(gameObject);
    }
}
