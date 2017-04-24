using UnityEngine;
using System.Collections;


namespace ihaiu.NDraws
{
    public class NDChart 
    {
        [SerializeField]
        private bool locked;


        public bool Locked
        {
            get
            {
                return this.locked;
            }
        }
    }
}
