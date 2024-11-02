using _scripts.NPCs.States;
using UnityEngine;

namespace _scripts.NPCs
{
    public class NpcController : Npc
    {
        private void Start()
        {
            ChangeState(new IdleState());
        }

        public override void Interact()
        {
            // Lógica de interacción específica con el jugador
            Debug.Log("El NPC está interactuando con el jugador");
            // Cambiar a otro estado si es necesario (ej. ChangeState(new TalkingState());)
        }
    }
}