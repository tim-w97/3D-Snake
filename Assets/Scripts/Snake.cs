using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    public Transform tailPiecePrefab;

    private float elapsedTime;

    private Vector3 direction;

    private List<Transform> snake;

    // Start is called before the first frame update
    void Start()
    {
        direction = Vector3.right;
        elapsedTime = 0;

        snake = new List<Transform>();

        NewGame();
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();

        elapsedTime += Time.deltaTime;

        if (elapsedTime > 0.5f)
        {
            elapsedTime = 0;
            MoveSnake();
        }
    }

    private void NewGame()
    {
        for (int i = 1; i < snake.Count; i++)
        {
            Destroy(snake[i].gameObject);
        }

        snake.Clear();
        
        this.transform.position = Vector3.zero;
        snake.Add(this.transform);
    }

    private void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            direction = Vector3.left;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            direction = Vector3.right;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            direction = Vector3.up;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            direction = Vector3.down;
        }
    }

    private void MoveSnake()
    {
        for (int i = snake.Count - 1; i > 0; i--)
        {
            snake[i].position = snake[i - 1].position;
        }

        snake[0].position = this.transform.position;

        this.transform.Translate(direction * 0.1f);
    }

    private void GrowTail()
    {
        Transform newTailPiece = Instantiate(tailPiecePrefab);

        newTailPiece.position = snake[snake.Count - 1].position;

        snake.Add(newTailPiece);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Food")
        {
            GrowTail();
        }

        if (other.tag == "Tail" && snake.Count > 2)
        {
            NewGame();
        }
    }
}
