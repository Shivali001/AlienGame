using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    protected bool _isFacingRight = false;
    protected float _maxSpeed = 1.5f;
    protected Rigidbody2D _rb2d;
    public void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Flip()
    {
        _isFacingRight = !_isFacingRight;
        Vector3 enemyScale = transform.localScale;
        enemyScale.x = enemyScale.x * -1;
        transform.localScale = enemyScale;
    }

   

}
