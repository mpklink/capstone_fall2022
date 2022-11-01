using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariables : MonoBehaviour
{
    public int[] winning = new int[5];
    public int[] current = new int[5];

    // Start is called before the first frame update
    void Start()
    {
        // Overworld scene
        winning[0] = Random.Range(1, 69);
        winning[1] = Random.Range(1, 69);
        
        // Elevator scene
        winning[2] = Random.Range(1, 69);

        // Library scene
        //winning[3] = Random.Range(1, 69);
        //winning[4] = Random.Range(1, 69);
        winning[3] = Random.Range(1, 4761);

        // Book selection scene
        winning[4] = Random.Range(1, 25);

        // Overworld
        current[0] = 0;
        current[1] = 0;
        
        // Elevator
        current[2] = 0;
        
        // Library
        current[3] = 0;

        // Book Selection
        current[4] = 0;
        
        //current[5] = 0;
    }

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
