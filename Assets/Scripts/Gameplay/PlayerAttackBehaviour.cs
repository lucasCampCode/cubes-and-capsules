using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerAttackBehaviour : MonoBehaviour
{
    public GameObject Target;
    private NavMeshAgent _agent;
    [SerializeField]
    private float _attackRange = 1f;

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Target)
            return;

        _agent.SetDestination(Target.transform.position);
        float distance = (Target.transform.position - transform.position).magnitude;
        if(distance < _attackRange)
        {

        }
    }
}
