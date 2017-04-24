using UnityEngine;
using System.Collections;

namespace ihaiu.NDraws
{
    public class NDNode 
    {
        protected string _name;
        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }
    }
}