using UnityEngine;

namespace _scripts.Player
{
    public class Food : MonoBehaviour
    {
        [SerializeField] private Character character;
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                character.Eat();
                Destroy(this.gameObject);
            }
        }
    }
}