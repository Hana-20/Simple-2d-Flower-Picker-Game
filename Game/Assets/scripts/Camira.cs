using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camira : MonoBehaviour
{
    public float offSet;
    public GameObject player;
    public float SmothOffSet;
    private Vector3 PlayerPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.localScale.x < 0)
        {
           PlayerPosition = new Vector3(player.transform.position.x - offSet, transform.position.y, transform.position.z);
        }
        else
        {
            PlayerPosition = new Vector3(player.transform.position.x + offSet, transform.position.y, transform.position.z);
        }
        transform.position = Vector3.Lerp(transform.position, PlayerPosition, offSet * Time.deltaTime);
    }
}
