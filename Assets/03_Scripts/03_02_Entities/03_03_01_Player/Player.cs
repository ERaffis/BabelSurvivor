using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    public SphereCollider preventSpawnSphere;

    public void SetMaxHealth(float newMaxHealth)
    {
        this.maxHealth = newMaxHealth;
    }

    public void SetCurrentHealth(float newCurrentHealth)
    {
        this.currentHealth = newCurrentHealth;
    }
}
