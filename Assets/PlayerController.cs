using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public SpriteRenderer sr;
    public float speed;
    public float jumpRate;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        if(moveHorizontal < 0){
            sr.flipX = true;
        }else if(moveHorizontal > 0){
            sr.flipX = false;
        }

        if(Input.GetKeyDown(KeyCode.Space)){
            rb.velocity = new Vector2(moveHorizontal * speed, jumpRate);
        }else{
            rb.velocity = new Vector2(moveHorizontal * speed, rb.velocity.y);
        }
    }
}
