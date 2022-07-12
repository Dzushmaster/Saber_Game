using UnityEngine;
using Assets.Scripts;

namespace Assets.Scripts.Infrastructure
{
    public abstract class Reward : MonoBehaviour
    {
        [SerializeField]
        private Ability _ability;

        public abstract void Activate();


        private void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.Equals(GameManager.Player.gameObject))
            {
                return;
            }

            GameManager.Player.ApplyAbility(_ability);
        }
    }
}