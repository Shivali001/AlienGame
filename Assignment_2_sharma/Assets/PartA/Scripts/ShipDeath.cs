using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipDeath : MonoBehaviour
{
    private Animator _anim;
    private Rigidbody2D _rb2d;
    // Start is called before the first frame update
    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ashot"))
        {
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
