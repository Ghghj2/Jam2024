using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key : MonoBehaviour
{
    [SerializeField] bool isCollected = false;
    [SerializeField] float expectedX;
    [SerializeField] float expectedY; 
    [SerializeField] float flightHeight = 1f; 
    [SerializeField] float keySpeed = 2;
    
    void Start()
    {
        
    }

    void Update()
    {
        if(isCollected) {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            Vector2 playerPosition = player.transform.position;
            Vector2 keyPosition = transform.position;

            float distanceX = (playerPosition.x - keyPosition.x);
            float distanceY = (playerPosition.y + flightHeight) - keyPosition.y;
            float distanceSpeed = Mathf.Sqrt(Mathf.Pow(distanceX, 2) + Mathf.Pow(distanceY, 2));

            transform.Translate( distanceX * Time.deltaTime * keySpeed, distanceY * Time.deltaTime * keySpeed * distanceSpeed, 0);
        }
        
    }

    void OnTriggerEnter2D(Collider2D  collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isCollected = true;
        }
    }
}
