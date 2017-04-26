using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;


namespace ihaiu.NDraws
{
    [Serializable]
    public class NDChart 
    {
        #region Attribute
        [SerializeField]
        private bool locked;

        [SerializeField]
        private string fileName;

        [SerializeField]
        private List<NDNode>        nodes = new List<NDNode>();

        [SerializeField]
        private List<NDTransition>  transitions = new List<NDTransition>();
        #endregion



        #region Property
        public bool Locked
        {
            get
            {
                return this.locked;
            }
        }


        public string FileName
        {
            get
            {
                return this.fileName;
            }


            set
            {
                this.fileName = value;
            }
        }

        public List<NDNode> Nodes
        {
            get
            {
                return this.nodes;
            }
            set
            {
                this.nodes = value;
            }
        }


        public List<NDTransition> Transitions
        {
            get
            {
                return this.transitions;
            }
            set
            {
                this.transitions = value;
            }
        }
        #endregion
    }
}
