using System.Collections;
using System.Threading.Tasks;
using Assets.Scripts.Infrastructure;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Scripts.Abilities
{
    public class DashAbility : Ability
    {
        private bool canDash = true;
        public float dashCooldown;
        private float cooldown;
        //private Vector4 color;
        private IEnumerator cooldownMethod;
        //private Color basicColor;
        //private Color finishColor = new Color(191,191,191, 1);
        public override void Activate(GameObject player)
        {
            if (canDash)
            {
                canDash = false;
                player.GetComponent<Rigidbody>().AddForce(player.transform.forward * 100f, ForceMode.Impulse);
                Material wheelColor = player.transform.GetChild(0).Find("wheel_low").GetComponent<MeshRenderer>().material;
                //basicColor = wheelColor;
                cooldownMethod = Cooldown(wheelColor);
                StartCoroutine(cooldownMethod);
            }
        }
        private IEnumerator Cooldown(Material wheelColor)
        {
            float changeColor;
            cooldown = 0;
            while (true)
            {
                cooldown += Time.deltaTime;
                changeColor = cooldown / dashCooldown;
            //    color = Color.Lerp(basicColor.linear, finishColor.linear, changeColor);
            //    Debug.Log(color);
            //    wheelColor.SetColor("_EmissionColor", color);
                if (cooldown >= dashCooldown)
                {
                    canDash = true;
                    StopCoroutine("Cooldown");
                }
                yield return null;
            }
        }
    }
}