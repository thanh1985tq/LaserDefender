using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] int damgage = 100;
    // Start is called before the first frame update
    
    public int GetDamage()
    {
        return damgage;
    }
}
