using System.Threading.Tasks;
using Assets.Scripts.Infrastructure;
using UnityEngine;

namespace Assets.Scripts.Abilities
{
    public class DashAbility : Ability
    {
        public override void Activate(GameObject player)
        {
            player.GetComponent<Rigidbody>().AddForce(player.transform.forward * 100f, ForceMode.Impulse);
            Task.Delay(3000);
        }
    }
}