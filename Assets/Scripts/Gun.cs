using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gun
{
    float damage;
    float cartridgeVolume;
    float bulletSpeed;
    float timeOfFire;
    float bulletQuantity = 0f;
    public Gun(float damage, float cartridgeVolume, float rateOfFire, float bulletSpeed)
    {
        this.damage = damage;
        this.cartridgeVolume = cartridgeVolume;
        this.timeOfFire = rateOfFire;
        this.bulletSpeed = bulletSpeed;
    }
    public Gun(float damage, float cartridgeVolume)
    {
        this.damage = damage;
        this.cartridgeVolume = cartridgeVolume;
    }
    public Gun()
    {
        damage = 10f;
        cartridgeVolume = 10f;
        bulletSpeed = 100f;
        timeOfFire = 0.1f;
    }
    public virtual void Fire()
    {
        bulletQuantity -= 1f;
    }
    public virtual void Reload()
    {
        bulletQuantity = cartridgeVolume;
    }
}
