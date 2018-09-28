using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
    public class EnemyAI : MonoBehaviour
    {
        public NavMeshAgent navmeshagent;
        public Transform target;

        //public void Awake()
        //{
        //    navmeshagent = GetComponent<NavMeshAgent>();
        //}

        void Update()
        {
            Destino();
        }

        public void Destino()
        {
            navmeshagent.SetDestination(target.position);
        }

        public void Maweke()
        {
            navmeshagent = GetComponent<NavMeshAgent>();
        }
    }
}
