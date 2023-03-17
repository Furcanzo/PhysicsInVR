using System.Collections.Generic;
using UnityEngine;

namespace Impacts
{
    public class PistolsSettings : MonoBehaviour
    {
        public List<GameObject> pistols;

        private List<Pistol> _realPistols = new List<Pistol>();

        private void Start()
        {
            foreach (GameObject pistol in pistols)
            {
                _realPistols.Add(pistol.GetComponent<Pistol>());
            }
        }

        public void SetMass(float mass)
        {
            foreach (Pistol pistol in _realPistols)
            {
                pistol.massOfCannonball = mass;
            }
        }

        public void SetInitialForce(float initialForce)
        {
            foreach (Pistol pistol in _realPistols)
            {
                pistol.startForce = initialForce;
            }
        }
    }
}
