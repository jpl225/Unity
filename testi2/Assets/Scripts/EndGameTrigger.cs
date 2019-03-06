using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameTrigger : MonoBehaviour
{
    public int levelNum;
    public bool finalLevel;
    public GameObject playAgainButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            if (finalLevel)
            {
                playAgainButton.SetActive(true);
            }
            else
            {
                Application.LoadLevel("Level" + levelNum);
            }
        }
    }

    public void restartGame()
    {
        Application.LoadLevel("Level1");
    }
}
