using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienFactory : MonoBehaviour
{
    [SerializeField]
    private GameObject _alien;

    // Start is called before the first frame update
    void Start()
    {
        MakeAliens();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void MakeAliens()
    {
        for (int i = 0; i < 15; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                Instantiate(_alien, new Vector3((i - 7) * 0.5f,
                (j - 2) * 0.8f, 0), Quaternion.identity);
            }
        }
    }
}
