using UnityEngine;

public class kaboom : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    float lifetimemax = 1;
    void Start()
    {

        Destroy(this.gameObject, lifetimemax);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
