using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Infrastructure
{
    public abstract class Player : MonoBehaviour
    {
        [SerializeField]
        protected Dictionary<KeyCode, Ability> _abilities;

        public abstract void ApplyAbility(Ability ability);

        public abstract void Die();

        public abstract void Spawn(Checkpoint point);
    }
}