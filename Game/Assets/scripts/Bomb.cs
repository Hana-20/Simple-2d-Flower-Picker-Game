using UnityEngine.UI;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private LevelManager manager;
    public float speed;
    private Animator animator;
    private float visibleHightTreshold;

    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<LevelManager>();
        animator = GetComponent<Animator>();
        visibleHightTreshold = Camera.main.orthographicSize - transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        if (transform.position.y+10 < (-1) * visibleHightTreshold)
        {
            Destroy(gameObject);
        }

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("triggered");
            animator.SetBool("IsActive", true);
            
        }

    }

}
