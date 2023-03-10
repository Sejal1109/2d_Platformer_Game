using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class enemyMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private float min;
    private float max;
    [SerializeField] private Vector3[] positions;
    private bool isFacingRight = true;
    private int index;

    void Start() 
    {
        List<float> xpos = new List<float>();
        foreach(Vector3 x in positions)
        {
            xpos.Add(x[0]);
        }
        min = xpos.Min();
        max = xpos.Max();
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, positions[index], Time.deltaTime * speed);

        if (transform.position == positions[index]) 
        {
            if (index == positions.Length - 1)
            {
                index = 0;
            }
            else {
                index++;
            }
        }

        if (min == max)
        {
            isFacingRight = !isFacingRight;
        }
        else if (transform.position.x == min && !isFacingRight)
        {
            Flip();
        }
        else if (transform.position.x == max && isFacingRight)
        {
            Flip();
        }
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

}

