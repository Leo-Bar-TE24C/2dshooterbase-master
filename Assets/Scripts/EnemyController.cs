using UnityEngine;
using UnityEngine.UIElements;

public class EnemyController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Vector2 position = new();
        position.x = Random.Range(-7f, 7f);
        position.y = Camera.main.orthographicSize + 1;

        transform.position = position;
    }
    // --------------------------------------------------------------------------------------------------------------------------

    [SerializeField]
    GameObject kaboomprefab;

    // --------------------------------------------------------------------------------------------------------------------------

    [SerializeField]
    float speed = 2;

    // --------------------------------------------------------------------------------------------------------------------------
    void Update()
    {
        Vector2 movement = Vector2.down * speed * Time.deltaTime;

        transform.Translate(movement);

        if (transform.position.y < -Camera.main.orthographicSize - 1)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(this.gameObject);
        Instantiate(kaboomprefab, transform.position, Quaternion.identity);
    }
}
