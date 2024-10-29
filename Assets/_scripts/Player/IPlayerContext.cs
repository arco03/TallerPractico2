
using UnityEngine;

namespace _scripts.Player
{
    public interface IPlayerContext
    {
        float GetOxygen();
        void SetOxygen(float amount);
        float GetFood();
        void SetFood(float food);
    }
    
    public class PlayerContext : MonoBehaviour, IPlayerContext
    {
        [SerializeField] private Character character;
        
        public float GetOxygen()
        {
            return character.currentEnergy;
        }

        public void SetOxygen(float amount)
        {
            character.currentEnergy = amount;
        }

        public float GetFood()
        {
            return character.HungerDuration;
        }

        public void SetFood(float food)
        {
            character.HungerDuration = food;
        }
    }

    public interface IInteract
    {
        void Interact(IPlayerContext context);
    }

    public class Apple : MonoBehaviour, IInteract
    {
        public void Interact(IPlayerContext context)
        {
            context.SetFood(100f);
            Destroy(gameObject);
        }
    }
}

