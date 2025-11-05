using UnityEngine;

public class Follow_Controller : MonoBehaviour
{
    [SerializeField]
    GameObject up;

    [SerializeField]
    GameObject left;

    [SerializeField]
    GameObject right;

    [SerializeField]
    GameObject down;


    [SerializeField]
    GameObject target;

    [SerializeField]
    LayerMask playerLayer;
    void Start()
    {
        Vector3 pos = transform.position;
        pos.x = target.transform.position.x;
        transform.position = pos;
    }
    // Update is called once per frame
    void Update()
    {
        bool goUp = Physics2D.OverlapCircle(up.transform.position, .3f, playerLayer);
        bool goLeft = Physics2D.OverlapCircle(left.transform.position, .3f, playerLayer);
        bool goRight = Physics2D.OverlapCircle(right.transform.position, .3f, playerLayer);
        bool goDown = Physics2D.OverlapCircle(down.transform.position, .3f, playerLayer);

        while (goRight == true)
        {
            
        }
        while (goLeft == true)
        {
            
        }
        while (goUp == true)
        {
            
        }
        while (goDown == true)
        {
            
        }
    }

}
