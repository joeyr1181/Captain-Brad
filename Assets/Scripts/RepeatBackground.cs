using UnityEngine;

public class RepeatBackground : MonoBehaviour
{

    // This script repeats the background object when it moves past a certain point
    // It is useful for creating an endless scrolling effect
    private Vector3 startPos;
    private float repeatWidth;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = transform.position;
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < startPos.x - repeatWidth)
        {
            transform.position = startPos;
        }
    }
}
