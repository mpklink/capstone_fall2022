using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpeedBonus : MonoBehaviour
{
    public static float CalculateSpeedBoost(float speed, float multi)
    {
        if ((multi * speed) < 50f)
        {
            return multi * speed;
        }
        
        else
        {
            return 50f;
        }
    }
}
