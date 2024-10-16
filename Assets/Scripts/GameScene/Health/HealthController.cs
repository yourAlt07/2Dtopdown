using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthController : MonoBehaviour
{
[SerializeField] public float curHP=10;
[SerializeField] public float maxHP=10;
[SerializeField] public GameObject graphics;

public bool IsInvincible {get;set;}

private Animator _animator;

public UnityEvent OnDied;
public UnityEvent OnDamaged;
public UnityEvent OnHealthChanged;
public UnityEvent Remove;

// DIVIDER
public void Start(){
    IsInvincible=false;
    _animator=graphics.GetComponent<Animator>();

}
public void TakeDamage(float dmg){
    if (curHP == 0){
        return;
    }
    if(IsInvincible){
        return;
    }
    curHP-=dmg;
    OnHealthChanged.Invoke();
    if (curHP < 0){
        curHP=0;
    }
    if (curHP==0){
        OnDied.Invoke();
        GetComponent<Rigidbody2D>().velocity=Vector2.zero;

    }else{
        OnDamaged.Invoke();
    }
}

public void AddHealth(float amt){
    if(curHP==maxHP){
        return;
    }
    curHP+=amt;
    OnHealthChanged.Invoke();
    if(curHP>maxHP){
        curHP=maxHP;
    }
}
public void RemoveFromScene(){
    // curHP=0;
    // Remove.Invoke();
}
}
