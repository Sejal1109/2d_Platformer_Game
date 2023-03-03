using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float speed = 0.5f;
    [SerializeField] private Animator anim = null;
    private bool isFacingRight = false;
    private GameObject obj;

    void update()
    {
        //float movementx = obj.getaxis("horizontal");
        //if (movementx > 0 && !isfacingright)
        //{
        //    flip();
        //}
        //else if (movementx < 0 && isfacingright)
        //{
        //    flip();
        //}

    }

    //private void flip()
    //{
    //    isfacingright = !isfacingright;
    //    vector3 thescale = transform.localscale;
    //    thescale.x *= -1;
    //    transform.localscale = thescale;
    //}
}