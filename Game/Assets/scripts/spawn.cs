using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    private Vector2 ScreenWedth;
    private Vector2 spawnPosition;
    public GameObject Object;
    public float SecondesBettwenSpawns;
    private float nextTime;
    // Start is called before the first frame update
    void Start()
    {
        ScreenWedth = new Vector2(Camera.main.aspect * Camera.main.orthographicSize,Camera.main.orthographicSize );
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextTime)
        {
            nextTime = Time.time + SecondesBettwenSpawns;
            spawnPosition = new Vector2(Random.Range(-ScreenWedth.x, ScreenWedth.x), ScreenWedth.y);
            Instantiate(Object, spawnPosition, Quaternion.identity);
        }
    }
}
