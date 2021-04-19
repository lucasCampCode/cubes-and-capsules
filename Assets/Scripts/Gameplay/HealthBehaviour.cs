using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBehaviour : MonoBehaviour
{
    [SerializeField]
    private float _health;
    [SerializeField]
    private bool _destroyOnDeath = true;

    public float Health { get{ return _health; } }

    public void TakeDamage(float damage)
    {
        _health -= damage;
        if (_health < 0)
            _health = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //If the object health is lower or equal to 0, destroy the object
        if (_health <= 0 && _destroyOnDeath)
            Destroy(gameObject);
        else if (_health <= 0)
            gameObject.SetActive(false);
    }
}
