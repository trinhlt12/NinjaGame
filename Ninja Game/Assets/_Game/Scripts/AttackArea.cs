using System;
using System.Collections;
using System.Collections.Generic;
using _Game.Scripts;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("Player"))
        {
            Debug.Log("Hit");
            other.GetComponent<Character>().OnHit(30f);
        }
    }
}
