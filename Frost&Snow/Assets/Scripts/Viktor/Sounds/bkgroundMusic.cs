using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bkgroundMusic : MonoBehaviour
{
    public AudioSource backgroundSource;
    
    private void Start()
    {
        backgroundSource.Play();
    }

    
}
