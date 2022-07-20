using UnityEngine.UI;
using UnityEngine;

public class Flower : MonoBehaviour
{
    private LevelManager manager;
    public float speed;
    private float visibleHightTreshold;
    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<LevelManager>();
        visibleHightTreshold = Camera.main.orthographicSize - transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        if(transform.position.y<(-1)*visibleHightTreshold)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            
            if (tag == "Bink")
            {
                manager.BinkCounter(1);
            }
            else
            {
                if (tag == "Blue")
                {
                    manager.BlueCounter(1);
                }

                else
                {
                    if (tag == "White")
                    {
                        manager.WhiteCounter(1);
                    }
                }
               
            }
            Destroy(gameObject);
            Debug.Log("triggered");
        }

    }

}
