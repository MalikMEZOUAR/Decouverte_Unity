using UnityEngine;

public class player_movement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveDirectionX=0;
    public float moveDirectionY=0;
    public float moveSpeed = 5;
    public float jumpForce = 7;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveDirectionX = Input.GetAxis("Horizontal");
        moveDirectionY = Input.GetAxis("Vertical");
    }

    private void Jump(){
        rb.linearVelocity = new Vector2(
            rb.linearVelocity.x,
            moveDirectionY * jumpForce
        );
    }

    private void FixedUpdate(){
        rb.linearVelocity = new Vector2 (
            moveDirectionX * moveSpeed,
            rb.linearVelocity.y
        );
    }
}
