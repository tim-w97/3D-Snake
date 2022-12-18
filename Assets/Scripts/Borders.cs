using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Borders : MonoBehaviour
{
    public Transform snake;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Vector3 snakePosition = snake.position;

        if (this.name == "LeftBorder")
        {
            snakePosition.x = -0.5f;
        }
        else if (this.name == "RightBorder")
        {
            snakePosition.x = 0.5f;
        }
        else if (this.name == "TopBorder")
        {
            snakePosition.y = -0.5f;
        }
        else if (this.name == "BottomBorder")
        {
            snakePosition.y = 0.5f;
        }

        snake.position = snakePosition;
    }
}
