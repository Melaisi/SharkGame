using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToRight : MonoBehaviour
{
    public float speed = 1;
    public float xDestroy; // game objects will be destroied if equal or less than this point 
    Vector3 movement;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.onGameStateChange += gameStateChange;
        movement.x = -speed;
    }
    private void OnDestroy()
    {
        GameManager.Instance.onGameStateChange -= gameStateChange;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (movement * Time.deltaTime * speed);
        // Destroy game object if pass the z boundary
        if (transform.position.x <= xDestroy)
        {
            Destroy(gameObject);
        }
    }

    
    private void gameStateChange(GameManager.GameState from, GameManager.GameState to)
    { 
        if (from == GameManager.GameState.Playing && to == GameManager.GameState.GameOver)
        {
            Destroy(gameObject);
        }
    }
}
