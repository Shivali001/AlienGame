using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienShotBehaviour : MonoBehaviour
{
    private float _speed = -4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, _speed * Time.deltaTime, 0);
        if (transform.position.y < -16)
        {
            Destroy(gameObject);
        }
    }
}
