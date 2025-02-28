using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    #region VARIABLES
    
    [SerializeField] private Animator animator;

    private float _hp;
    private string _currentAnimName;
    private bool IsDead => _hp <= 0;

    #endregion


    private void Start()
    {
        OnInit();
    }

    public virtual void OnInit()
    {
        _hp = 100;
    }

    public virtual void OnDespawn()
    {
        
    }
    
    protected void ChangeAnim(string animName)
    {
        if (_currentAnimName == animName) return;
        animator.ResetTrigger(animName);
        _currentAnimName = animName;
        animator.SetTrigger(_currentAnimName);
    }

    private void OnHit(float damage)
    {
        if (IsDead)
        {
            _hp -= damage;

            if (_hp <= damage)
            {
                OnDeath();
            }
        }
    }

    private void OnDeath()
    {
        
    }
    
    
}
