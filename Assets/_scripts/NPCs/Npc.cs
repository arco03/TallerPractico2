using UnityEngine;
using UnityEngine.AI;

namespace _scripts.NPCs
{
    public abstract class Npc : MonoBehaviour
    {
        public float npcSpeed;
        public Transform[] wayPoints;
        private INpcState _currentState;
        
        private NavMeshAgent _navMeshAgent;

        private void Awake()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _navMeshAgent.speed = npcSpeed;
        }

        // Method for change the state
        public void ChangeState(INpcState newState)
        {
            _currentState = newState;
            _currentState.EnterState();
        }

        // Update the state
        private void Update()
        {
            _currentState?.UpdateState();
        }

        // Interact with character
        public abstract void Interact();
    }
}
