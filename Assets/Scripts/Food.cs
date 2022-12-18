using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MoveAppleToNewRandomPosition();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        MoveAppleToNewRandomPosition();
    }

    private void MoveAppleToNewRandomPosition()
    {
        Vector3 newPosition = new Vector3(
            Random.Range(-5, 5) * 0.1f,
            Random.Range(-5, 5) * 0.1f,
            this.transform.position.z
        );

        this.transform.position = newPosition;
    }
}
