using System.Diagnostics.CodeAnalysis;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading;
using System.Threading.Tasks;

public class PlayerControler : MonoBehaviour
{
    [SerializeField]
    float speed = 0.02f;

    [SerializeField]
    GameObject kaboom;


    [SerializeField]
    GameObject boltPrefab;


    float timeSinceLastShot = 0;

    [SerializeField]
    float timeBetwenShots = 0.5f;


    float currentHP = 0;
    [SerializeField]
    float maxHP = 3;


    [SerializeField]
    Slider hpSlider;



    void Start()
    {
        currentHP = maxHP;
        hpSlider.maxValue = maxHP;
        hpSlider.value = currentHP;
    }

    void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");

        Vector2 movement = Vector2.right * inputX + Vector2.up * inputY;

        transform.Translate(movement * speed * Time.deltaTime);


        //-----------------------------------------------------------------------------------------------------------------
        //shoot
        timeSinceLastShot += Time.deltaTime;

        if (Input.GetAxisRaw("Fire1") > 0 && timeSinceLastShot > timeBetwenShots)
        {
            AudioSource speaker = GetComponent<AudioSource>();

            speaker.Play();

            Instantiate(boltPrefab, transform.position, Quaternion.identity);
            timeSinceLastShot = 0;
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            currentHP--;
            hpSlider.value--;
            if (currentHP <= 0)
            {
                SceneManager.LoadScene("GameOver");
            }
        }
    }
}