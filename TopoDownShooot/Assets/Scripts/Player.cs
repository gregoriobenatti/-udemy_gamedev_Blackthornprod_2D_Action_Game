
using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    public float speed;
    public int health;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public Animator hurtPanel;
    
    private Rigidbody2D rb;
    private Animator animator;
    private Vector2 moveAmount;
    private SceneTransition sceneTransitions;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sceneTransitions = FindObjectOfType<SceneTransition>();
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
        UpdateHealthUI(health);
        hurtPanel.SetTrigger("hurt");

        if (health <= 0)
        {
            Destroy(gameObject);
            sceneTransitions.LoadScene("Lose");
        }
    }

    public void ChangeWeapon(Weapon weaponToEquip)
    {
        Destroy(GameObject.FindGameObjectWithTag("Weapon"));
        Instantiate(weaponToEquip, transform.position, transform.rotation, transform);
    }

    void UpdateHealthUI(int currentHealth)
    {
        for (var i = 0; i < hearts.Length; i++)
        {
            hearts[i].GetComponent<Image>().sprite = i < currentHealth ? fullHeart : emptyHeart;
        }
    }

    public void Heal(int healAmount)
    {
        if (health + healAmount > 5)
        {
            health = 5;
        }
        else
        {
            health += healAmount;   
        }
        
        UpdateHealthUI(health);
    }

}
 