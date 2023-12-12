using AosSdk.Core.PlayerModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class WorkerController : MonoBehaviour
{
    [SerializeField] private Animator _anim;
    [SerializeField] private Transform _playerPos;
    private NavMeshAgent _navMeshAgent;
    private bool _follow = false;
    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }
    private void Start()
    {
        API.Instance.SetLocationEvent += OnCheckState;
    }
    void Update()
    {
        if (!_follow)
            return;
        _navMeshAgent.SetDestination(_playerPos.position);
        if(_navMeshAgent.velocity==Vector3.zero)
            _anim.SetTrigger("Idle");
        else
            _anim.SetTrigger("Walk");
    }

    private void OnCheckState(string locationName)
    {
        if (locationName == "field")
        {
            _follow= true;
        }
        else if(locationName=="hall")
        {
            _follow = false;
        }   
    }
}
