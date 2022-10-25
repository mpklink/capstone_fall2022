using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariables : MonoBehaviour
{
    public int[] winning = new int[6];
    public int[] current = new int[6];

    // Start is called before the first frame update
    void Start()
    {
        winning[0] = Random.Range(1, 69);
        winning[1] = Random.Range(1, 69);
        winning[2] = Random.Range(1, 69);
        winning[3] = Random.Range(1, 69);
        winning[4] = Random.Range(1, 69);
        winning[5] = Random.Range(1, 25);

        current[0] = 0;
        current[1] = 0;
        current[2] = 0;
        current[3] = 0;
        current[4] = 0;
        current[5] = 0;
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
