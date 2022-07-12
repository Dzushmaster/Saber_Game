using System;
using System.Linq;
using Assets.Scripts.Infrastructure;
using UnityEngine;

namespace Assets.Scripts
{
    public class RobotController : Player
    {
        public override void ApplyAbility(Ability ability)
        {
            if (_abilities.ContainsKey(ability.Key))
            {
                throw new Exception("The ability exists in a player ability collection!");
            }

            _abilities.Add(ability.Key, ability);
        }

        private void Update()
        {
            if (Input.anyKey)
            {
                _abilities.Keys
                    .ToList()
                    .ForEach(key =>
                    {
                        if (Input.GetKey(key))
                        {
                            _abilities[key].Apply();
                        }
                    });
            }
        }

        public override void Die()
        {
            throw new System.NotImplementedException();
        }

        public override void Spawn(Checkpoint point)
        {
            throw new System.NotImplementedException();
        }
    }
}