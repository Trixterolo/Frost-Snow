using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateBullet : MonoBehaviour
{
    public GameObject myInstantiateBullet = null;

    public int currentClip, maxClipsize = 1, currentAmmo, maxAmmosize = 10;

    private void Update()
    {


        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            OnFire();
        }

        if(Input.GetKeyDown(KeyCode.Keypad3))
        {
            Reload();
        }
    }
    public void OnFire()
    {
        if(currentClip > 0)
        {
            GameObject bullet = Instantiate(myInstantiateBullet, transform.position, transform.rotation);
            currentClip--;
        }
    }

    public void Reload()
    {
        int reloadAmount = maxClipsize - currentClip; //how many bullets to refill clip
        reloadAmount = (currentAmmo - reloadAmount) >= 0 ? reloadAmount : currentAmmo; //checks if we have enough ammo to reload.
        currentClip += reloadAmount;
        currentAmmo -= reloadAmount;
    }

    public void AddAmmo(int ammoAmount)
    {
        currentAmmo+= ammoAmount;
        if(currentAmmo > maxAmmosize)
        {
            currentAmmo = maxAmmosize; 
        }
    }


}
