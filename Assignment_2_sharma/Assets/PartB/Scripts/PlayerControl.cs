using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    private float _speed = 4.5f;
    private Rigidbody2D _rb2d;
    private Animator _anim;
    private float _jumpForce = 12.0f;
    private bool _isGrounded;
    public Vector3 respawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
       respawnPoint = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * _speed;
        Vector2 movement = new Vector2(deltaX,
        _rb2d.velocity.y);
        _rb2d.velocity = movement;

        _anim.SetFloat("speed", Mathf.Abs(deltaX));
        if (!Mathf.Approximately(deltaX, 0))
        {
            transform.localScale = new Vector3(Mathf.Sign(deltaX),
            1, 1);
        }
        if (_isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            _rb2d.AddForce(Vector2.up * _jumpForce,
            ForceMode2D.Impulse);
        }
       /* if (transform.position.y < -0.5f)
        {
            transform.position = respawnPoint;
        }*/

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _isGrounded = true;
        }
        else
        {
            if(collision.gameObject.tag == "Enemy")
            {
                respawnPoint = collision.transform.position;
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _isGrounded = false;
        }
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }




}
