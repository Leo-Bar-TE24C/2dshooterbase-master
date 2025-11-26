using System.Collections;
using System.Threading;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.UIElements;

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

    [SerializeField]
    float timeBetweenDash = 1;
    float timeSinceDash = 0;


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

        if (transform.position.y <= -20)
        {
            transform.position=new(-9,-3,0);
        }
        
    }
    void FixedUpdate()
    {
        timeSinceJump += Time.deltaTime;

        timeSinceDash += Time.deltaTime;

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

        if (Input.GetKey("x") == true && timeSinceDash > timeBetweenDash)
        {
            StartCoroutine(dash());
            timeSinceDash = 0;
        }


    }
    IEnumerator dash()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        timeSinceDash += Time.deltaTime;
        if (rotated == true)
        {
            rb.AddForce(Vector2.right * dashForce * -1, ForceMode2D.Impulse);
            yield return new WaitForSeconds(dashTime);
            rb.linearVelocityX = 0;
        }
        else
        {
            rb.AddForce(Vector2.right * dashForce * 1, ForceMode2D.Impulse);
            yield return new WaitForSeconds(dashTime);
            rb.linearVelocityX = 0;
        }
    }
}
