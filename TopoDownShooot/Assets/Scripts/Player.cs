
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float health;
    
    private Rigidbody2D rb;
    private Animator animator;
    private Vector2 moveAmount;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        var moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveAmount = moveInput.normalized * speed;
        
        animator.SetBool("isRunning", moveInput != Vector2.zero);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveAmount * Time.fixedDeltaTime);
    }
    
    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        
        if (health <= 0)
        {
            Destroy(gameObject);   
        }
    }
}
 