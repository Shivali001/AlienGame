using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Behaviour :EnemyBehaviour
{
    //private bool _triggered;
    void FixedUpdate()
    {
        if (_isFacingRight == true)
        {
            _rb2d.velocity =
            new Vector2(_maxSpeed, _rb2d.velocity.y);
        }
        else
        {
            _rb2d.velocity =
            new Vector2(_maxSpeed * -1, _rb2d.velocity.y);
        }
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Wall")
        {
            Flip();
        }
      
    }
}
