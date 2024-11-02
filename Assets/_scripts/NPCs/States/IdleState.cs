using UnityEngine;

namespace _scripts.NPCs.States
{
    public class IdleState : INpcState
    {
        public void EnterState()
        {
            Debug.Log("Entró a Idle");
        }

        public void UpdateState()
        {
            
        }

        public void ExitState()
        {
            
        }
    }
}