using UnityEngine;

public class PlayerMove : MonoBehaviour

{
    public float speed = 1f;

    public float jumpForce = 3f;

    private Rigidbody2D rb;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void SpriteFlip(float horizontalInput)
    {
        if (horizontalInput < 0)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(rb.linearVelocity.y) < 0.1f)
        {
            Debug.Log("Jump!");
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    void FixedUpdate()
    {
        // Menggerakan player ke kanan atau kiri menggunakan transform.translate
         float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(new Vector3(horizontalInput * speed * Time.deltaTime, 0f, 0f));
        SpriteFlip(horizontalInput);


        //// Mengaktifkan lompatan player jika player menyentuh tanah
        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(rb.linearVelocity.y) < 0.1f)
        {
            Debug.Log("Jump!");
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

}
