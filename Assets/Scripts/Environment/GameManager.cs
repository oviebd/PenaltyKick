using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public static GameManager shared;

    public GameInstances gameInstance;
   

    private void Awake()
    {
        if (shared == null)
        {
            shared = this;
        }
    }

    void Start()
    {
        
    }

    
}
