using UnityEngine;

namespace _scripts.Player
{
    public class Object : MonoBehaviour, IInteract
    {
        public void Interact(IPlayerContext context)
        {
            context.SetFood(100f);
            Destroy(gameObject);
        }


  
    }
}
