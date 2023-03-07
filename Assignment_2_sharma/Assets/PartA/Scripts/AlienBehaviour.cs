using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienBehaviour : MonoBehaviour
{
    [SerializeField] 
    private GameObject _ashot;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.FloorToInt(Random.value * 10000.0f) % 5000 == 0)
        {
            Instantiate(_ashot, new Vector3(transform.position.x,
            transform.position.y, 0.5f), Quaternion.identity);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Shot")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
