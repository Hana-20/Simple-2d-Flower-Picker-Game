using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public event System.Action OnPlayerDeath;
    public float speed;
    private float movement = 0f;
    private Rigidbody2D rigidbody;
    private float ScreenHalfWedth;
    private int life;
    private LevelManager Manager;

    // Start is called before the first frame update
    void Start()
    {
        Manager = FindObjectOfType<LevelManager>();
        rigidbody = GetComponent<Rigidbody2D>();
        ScreenHalfWedth = Camera.main.aspect * Camera.main.orthographicSize;
        

    }

    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxis("Horizontal");
        float velocity = movement * speed;
        transform.Translate(Vector2.right * velocity * Time.deltaTime);
        if (transform.position.x > ScreenHalfWedth)
        {
            transform.position = new Vector2(-ScreenHalfWedth, transform.position.y);

        }
        else
        {
            if (transform.position.x < -ScreenHalfWedth)
            {
                transform.position = new Vector2(ScreenHalfWedth, transform.position.y);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bomb")
        {

            life = Manager.LifeCounter();
            if (life == 0)
            {
                if (OnPlayerDeath != null)
                {
                    OnPlayerDeath();
                }
                Debug.Log("Game Over");
                gameObject.SetActive(false);
            }
        }
    }
}

