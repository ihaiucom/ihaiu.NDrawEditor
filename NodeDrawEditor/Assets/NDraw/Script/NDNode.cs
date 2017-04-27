using UnityEngine;
using System.Collections;
using System;

namespace ihaiu.NDraws
{
    [Serializable]
    public class NDNode 
    {
        protected string    _name;
        protected int       _index;

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


        public int Index
        {
            get
            {
                return _index;
            }

            set
            {
                _index = value;
            }
        }

        public NDNode()
        {
        }


        public NDNode(string name)
        {
            _name = name;
        }

    }
}