using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    private float _speed = 5;
    private float _boundary = 3.0f;
    private Rigidbody2D _rb2d;
    [SerializeField]
    private GameObject _shot;
    // Start is called before the first frame update
    void Start()
    {
        _rb2d= GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 vel = _rb2d.velocity;
        if (Input.GetKey(KeyCode.RightArrow))
        {
            vel.x = _speed;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            vel.x = -_speed;
        }
        else
        {
            vel.x = 0;
        }
        _rb2d.velocity = vel;
        Vector3 pos = transform.position;
        if (pos.x > _boundary)
        {
            pos.x = _boundary;
        }
        else if (pos.x < -_boundary)
        {
            pos.x = -_boundary;
        }
        transform.position = pos;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(_shot, new
            Vector3(transform.position.x, transform.position.y, 0.5f),
            Quaternion.identity);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "AShot")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
