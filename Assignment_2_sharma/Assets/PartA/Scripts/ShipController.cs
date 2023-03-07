using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]

public class ShipController : MonoBehaviour
{
    private float _speed = 5;
    private float _boundary = 3.0f;
    private Rigidbody2D _rb2d;
    private Animator _anim;
 
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
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "AShot")
        {
            Destroy(gameObject);
            GameObject[] objects=GameObject.FindGameObjectsWithTag("Flame");
            foreach (GameObject obj in objects)
            {
                GameObject.Destroy(obj);
            }
            Destroy(other.gameObject);
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ashot"))
        {
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
            Die();
        }
    }

    private void Die()
    {
        _rb2d.bodyType = RigidbodyType2D.Static;
        _anim.SetTrigger("death");
        Invoke("Live", 2.0f);
    }

    private void Live()
    {
        _anim.SetTrigger("live");
    }
}
