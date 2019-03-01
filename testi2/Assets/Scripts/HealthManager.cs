using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour //NewBehaviourScript : MonoBehaviour
{
    public GameObject[] hearts;
    private int health;

    // Start is called before the first frame update
    void Start()
    {
        health = hearts.Length;    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
