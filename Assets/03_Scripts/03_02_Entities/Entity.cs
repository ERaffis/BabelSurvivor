using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField] public string entityName;
    [Space]
    [SerializeField] public float maxHealth;
    [SerializeField] public float currentHealth;
    [Space] 
    [SerializeField] public float movementSpeed;

}