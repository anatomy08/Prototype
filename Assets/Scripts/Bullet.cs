using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    MobileControls player;
    Rigidbody2D myRigidBody;
    [SerializeField] float bulletSpeed = 5f;

    float xSpeed;

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<MobileControls>();
        xSpeed = player.transform.localScale.x * bulletSpeed;
    }

    
    void Update()
    {
        myRigidBody.velocity = new Vector2 (xSpeed, 0f);
    }
}
