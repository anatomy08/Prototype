using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MobileControls : MonoBehaviour
{
   
    [SerializeField] float speed;
    [SerializeField] float jumpSpeed = 10f;
    [SerializeField] GameObject bullet;
    CapsuleCollider2D myCapsuleCollider;
    float horizontalMove;
    bool moveRight;
    bool moveLeft;
    bool isAlive = true;
    Rigidbody2D rb;

    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveLeft = false;
        moveRight = false;
        myCapsuleCollider = GetComponent<CapsuleCollider2D>();
    }

    
    void Update()
    { 
        if(!isAlive) {return;}
        Movement();
        Die();
    }

    public void pointerDownLeft()
    {
        moveLeft = true;
    }
    
    public void pointerUpLeft()
    {
        moveLeft = false;
    }
    public void pointerDownRight()
    {
        moveRight = true;
    }
    public void pointerUpRight()
    {
        moveRight = false;
    }

    void Movement()
    {
        if(moveLeft)
        {
            horizontalMove = -speed;
            
        }
        else if (moveRight)
        {
            horizontalMove = speed;
            
        }
        else
        {
            horizontalMove = 0;
        }

    }

      void FixedUpdate() 
    {
        rb.velocity = new Vector2(horizontalMove, rb.velocity.y);
    }

    public void Jump()
    {
        if(!isAlive) {return;}
        if(!myCapsuleCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))) 
        {
            return;
        }
        rb.velocity += new Vector2 (0f, jumpSpeed);  
    }

    void Die()
    {
        if (myCapsuleCollider.IsTouchingLayers(LayerMask.GetMask("Enemies", "Hazards")))
        {
            isAlive = false;
            Invoke(nameof(ResetLevel), 1f);
        }
    }

    void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}
