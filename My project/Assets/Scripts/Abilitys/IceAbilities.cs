using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class IceAbilities : MonoBehaviour
{
    public GameObject Ice;
    // Start is called before the first frame update
    void Start()
    {
        Ice.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Ice.SetActive(true);
        GetComponent<GameObject>();
        GameObject.Destroy(gameObject);
    }
}
