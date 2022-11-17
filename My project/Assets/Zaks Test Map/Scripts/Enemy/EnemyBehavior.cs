using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using Pathfinding;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class EnemyBehavior : MonoBehaviour
{
    public Transform target;
    public float speed = 10f;
    public float chaseDistance = 5f;
    Rigidbody2D rb;
    public float nextWaypointDistance = 3f;
    Path path;
    int CurrentWayPoint = 0;
    bool reachedEndOfPath = false;
    Seeker seeker;
    AIPath pathfinder;
    bool grounded;
    float jumpSpeed = 1.0f;
    Animator animator;
    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        seeker = GetComponent<Seeker>();
        InvokeRepeating("UpdatePath",0, 0.5f);
        pathfinder = GetComponent<AIPath>();
    }
    void UpdatePath()
    {
        if (seeker.IsDone())
        {
            seeker.StartPath(rb.position, target.position, OnPathComplete);
        }
    }
    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            CurrentWayPoint = 0;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if(path == null)
        {
            return;
            
        }
        if (CurrentWayPoint >= path.vectorPath.Count)
        {
            return;
        }
        if (path.GetTotalLength() < chaseDistance)
        {
            pathfinder.maxSpeed = speed;
        }
        else
        {
            pathfinder.maxSpeed = 0;
        }
    }
    void Update()
    {
        float movex = Input.GetAxis("Horizontal");
        Vector2 volocity = rb.velocity;
        volocity.x = movex * speed;
        rb.velocity = volocity;
        if (grounded)
        {
            rb.AddForce(new Vector2(0, 100 * jumpSpeed));
            animator.SetTrigger("PlayerJump");
        }
        if (rb.velocity.y < -0.1f && !grounded)
        {
            animator.SetTrigger("PFall");
        }
        animator.SetFloat("xInput", movex);
        animator.SetBool("grounded", grounded);
        if (movex < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (movex > 0)
        {
            spriteRenderer.flipX = false;
        }
    }
}
