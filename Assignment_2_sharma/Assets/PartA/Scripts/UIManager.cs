using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private int _lives = 3;
    private int _score = 0;
    [SerializeField]
    private Text _Plives;
    [SerializeField]
    private Text _Pscore;
    [SerializeField]
    private Text _gameOverText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Score(string shot)
    {
        if (shot == "AShot"&&_lives>0)
        {
            _score += 10;
            _Pscore.text="Score: "+_score.ToString();
        }
        else
        {
            if(shot=="Player")
            {
                _lives--;
                _Plives.text ="Lives: "+ _lives.ToString();
            }
            else
            {
                GameOver();
            }
        }
    }

    public void GameOver()
    {
       if(_score==900||_lives==0)
        {
            _gameOverText.text = "WINNER!!!!";
        }
        _gameOverText.gameObject.SetActive(true);
    }
}
