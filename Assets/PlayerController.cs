using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    public float speed;

    public float jumpRate;
    public int maxJumps;
    private int jumpCount;

    public AudioSource jump_asrc;
    public AudioSource win_asrc;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        jumpCount = maxJumps;
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        animator.SetFloat("Horizontal Speed", Mathf.Abs(moveHorizontal));
        if(moveHorizontal < 0){
            sr.flipX = true;
        }else if(moveHorizontal > 0){
            sr.flipX = false;
        }

        if(jumpCount > 0 && Input.GetKeyDown(KeyCode.Space)){
            rb.velocity = new Vector2(moveHorizontal * speed, jumpRate);
            jump_asrc.Play();
            jumpCount--;
        }else{
            rb.velocity = new Vector2(moveHorizontal * speed, rb.velocity.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.collider.CompareTag("Ground")){
            Debug.Log("Hit Ground");
            jumpCount = maxJumps;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Dead Zone")){
            Debug.Log("You Lose!");
            SceneManager.LoadScene("MainMenu");
        } else if(collision.CompareTag("Cherry")){
            Debug.Log("You Win!");
            win_asrc.Play();
        }
    }
}
