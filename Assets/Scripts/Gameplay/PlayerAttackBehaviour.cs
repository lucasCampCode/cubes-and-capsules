using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerAttackBehaviour : MonoBehaviour
{
    [SerializeField]
    private float _attackRange = 2f;
    [SerializeField]
    private float _meleeRange = 2f;
    [SerializeField]
    private float _meleedamage = 1;
    [SerializeField]
    private float _timeToAttack = 1f;
    [SerializeField]
    private float _shootSpeed = 2f;

    public GameObject Target;
    public HealthBehaviour TargetHealth;

    private NavMeshAgent _agent;
    private BulletEmitterBehaviour _bulletEmmiter;
    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _bulletEmmiter = GetComponent<BulletEmitterBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Target)
            return;

        _agent.SetDestination(Target.transform.position);
        Vector3 direction = Target.transform.position - transform.position;
        float distance = direction.magnitude;
        if(distance < _attackRange)
        {
            float time = 0;
            time += Time.deltaTime;
            _agent.SetDestination(-direction);

            if(time > _timeToAttack/3 && distance < _meleeRange)
                TargetHealth.TakeDamage(_meleedamage);
            else if (time > _timeToAttack)
                _bulletEmmiter.Fire(transform.forward);
        }

    }
}
