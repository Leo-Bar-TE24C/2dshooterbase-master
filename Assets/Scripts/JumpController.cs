using UnityEngine;

public class JumpController : MonoBehaviour
{
    void Start()
    {

    }
    [SerializeField]
    float speed;

    [SerializeField]
    LayerMask groundLayer;

    [SerializeField]
    GameObject groundChecker;

    [SerializeField]
    float jumpForce = 1;

    [SerializeField]
    float timeBetweenJump = 1;

    float timeSinceJump = 1;

    [SerializeField]
    float jumpNumMax = 1;
    float jumpNum;

    void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        transform.Translate(inputX * speed * Time.deltaTime * Vector2.right);
    }
    void FixedUpdate()
    {
        timeSinceJump += Time.deltaTime;

        bool isGrounded = Physics2D.OverlapCircle(groundChecker.transform.position, .3f, groundLayer);

        if (isGrounded == true)
        {
            jumpNum = jumpNumMax;
        }

        if (Input.GetAxisRaw("Jump") > 0 && timeSinceJump >= timeBetweenJump && jumpNum > 0)
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();

            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            timeSinceJump = 0;
            jumpNum--;
        }

    }
}
