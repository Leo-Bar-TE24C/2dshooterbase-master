using System.Collections;
using System.Threading;
using Unity.PlasticSCM.Editor.WebApi;
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

    [SerializeField]
    float dashForce;
    bool rotated = false;

    [SerializeField]
    float dashTime = 1;

    void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");

        if (rotated == true) { transform.Translate(inputX * speed * Time.deltaTime * Vector2.right * -1); }



        else { transform.Translate(inputX * speed * Time.deltaTime * Vector2.right); }

        if (Input.GetKey("left") && rotated == false)
        {
            transform.Rotate(0, 180, 0);
            rotated = true;
        }
        if (Input.GetKey("right") && rotated == true)
        {
            transform.Rotate(0, -180, 0);
            rotated = false;
        }
    }
    void FixedUpdate()
    {
        timeSinceJump += Time.deltaTime;

        bool isGrounded = Physics2D.OverlapCircle(groundChecker.transform.position, .3f, groundLayer);

        if (isGrounded == true)
        {
            jumpNum = jumpNumMax;
        }
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        if (Input.GetAxisRaw("Jump") > 0 && timeSinceJump >= timeBetweenJump && jumpNum > 0)
        {

            rb.linearVelocityY = 0;

            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            timeSinceJump = 0;
            jumpNum--;
        }

        if (Input.GetKey("x") == true)
        {
            StartCoroutine(dash());
        }


    }
    IEnumerator dash()
    {
    Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rotated == true)
        {
            rb.AddForce(Vector2.right * dashForce * -1, ForceMode2D.Impulse);
            yield return new WaitForSeconds(dashTime);
            rb.AddForce(Vector2.right * dashForce, ForceMode2D.Impulse);
        }
        else
        {
            rb.AddForce(Vector2.right * dashForce, ForceMode2D.Impulse);
            yield return new WaitForSeconds(dashTime);
            rb.AddForce(Vector2.right * dashForce * -1, ForceMode2D.Impulse);
        }



        

        }
}
