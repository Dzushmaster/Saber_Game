using UnityEngine;

namespace Assets.Scripts.Infrastructure
{
    public abstract class Ability
    {
        public KeyCode Key { get; set; }

        public abstract void Activate(GameObject obj);
    }
}