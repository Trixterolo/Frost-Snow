using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AmmoText : MonoBehaviour
{
    [SerializeField] InstantiateBullet bullet;
    [SerializeField] TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        UpdateAmmoText();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateAmmoText();
        
    }

    public void UpdateAmmoText()
    {
        text.text = $"{bullet.currentClip}/{bullet.maxClipsize} | {bullet.currentAmmo}/{bullet.maxAmmosize}" + ":" + " Keypad 1/2 to Aim, 3 to Reload, KeyEnter to Shoot";
    }
}
