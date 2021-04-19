using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovementBehaviour : MonoBehaviour
{
    [SerializeField]
    private Camera _camera;
    private Rigidbody _rigidbody;
    private NavMeshAgent _agent;
    private PlayerAttackBehaviour _playerAttack;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _agent = GetComponent<NavMeshAgent>();
        _playerAttack = GetComponent<PlayerAttackBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        //set teh camera to an offset of the player to seem like its following
        _camera.transform.position = new Vector3(transform.position.x, transform.position.y +  10f,transform.position.z + -10f);
        //Create a ray that starts at a screen point
        RaycastHit hit;
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        //Checks to see if the ray hits any object in the world
        if (Physics.Raycast(ray, out hit))
        {
            //Find the direction the player should go towards
            Vector3 moveDir = new Vector3(hit.point.x, transform.position.y, hit.point.z);
            //Create a place to where teh player will move to
            if (Input.GetMouseButton(0))
            {
                if (hit.collider.gameObject.CompareTag("enemy"))
                {
                    _playerAttack.Target = hit.collider.gameObject;
                }
                else
                {
                    _playerAttack.Target = null;
                    _agent.SetDestination(moveDir);
                }
            }
        }
    }
}
