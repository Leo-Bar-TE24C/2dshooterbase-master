using UnityEngine;

public class BoltControler : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Destroy(this.gameObject, 3);
    }
    [SerializeField]
    float speed = 5f;

    // Update is called once per frame
    void Update()
    {
        Vector2 movement = Vector2.up * speed;
        transform.Translate(movement * Time.deltaTime);


        if (transform.position.y > Camera.main.orthographicSize + 1)
        {
            Destroy(this.gameObject);
        }
    }



    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
        }
    }
}
