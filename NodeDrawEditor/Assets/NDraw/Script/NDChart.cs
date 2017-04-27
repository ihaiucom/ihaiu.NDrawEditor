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
        private NDChartTemplate     usedInTemplate;

        [NonSerialized]
        private NDChart             host;

        [NonSerialized]
        private NDChart             rootHost;

        [NonSerialized]
        private List<NDChart>       subChartList;




        [SerializeField]
        private bool                locked;

        [SerializeField]
        private string              fileName;

        [SerializeField]
        private string              name;

        [SerializeField]
        private List<NDNode>        nodes       = new List<NDNode>();

        [SerializeField]
        private List<NDTransition>  transitions = new List<NDTransition>();

        [SerializeField]
        private NDNode              startNode;

        [SerializeField]
        private NDNode              activeNode;
        #endregion



        #region Property
        public NDChart Host
        {
            get
            {
                return this.host;
            }
            private set
            {
                this.host = value;
            }
        }

        public bool IsSubChart
        {
            get
            {
                return this.host != null;
            }
        }

        public NDChart RootChart
        {
            get
            {
                NDChart chart;
                if ((chart = this.rootHost) == null)
                {
                    chart = (this.rootHost = this.GetRootChart());
                }
                return chart;
            }
        }
        public List<NDChart> SubChartList
        {
            get
            {
                List<NDChart> list;
                if ((list = this.subChartList) == null)
                {
                    list = (this.subChartList = new List<NDChart>());
                }
                return list;
            }
        }



        public NDChartTemplate UsedInTemplate
        {
            get
            {
                return this.usedInTemplate;
            }
            set
            {
                this.usedInTemplate = value;
            }
        }

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


        public string Name
        {
            get
            {
                return this.name;
            }


            set
            {
                this.name = value;
            }
        }

        public NDNode StartNode
        {
            get
            {
                if (!ContainsNode(startNode))
                {
                    startNode = null;
                }

                return startNode;
            }

            set
            {
                this.startNode = value;
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


        public NDNode ActiveNode
        {
            get
            {
                return this.activeNode;
            }

            private set
            {
                this.activeNode = value;
            }
        }

        #endregion


        #region Metho
        public bool ContainsNode(NDNode node)
        {
            if (node == null)
                return false;
            
            return nodes.Contains(node);
        }

        public void AddNode(NDNode node)
        {
            if (node == null)
                return;
            
            if (!nodes.Contains(node))
            {
                nodes.Add(node);

                if (StartNode == null)
                {
                    StartNode = node;
                }
            }
        }

        public void RemoveNode(NDNode node)
        {
            if (nodes.Contains(node))
            {
                nodes.Remove(node);
            }
        }

        public bool ContainsTransition(NDTransition tran)
        {
            if (tran == null)
                return false;
            
            return transitions.Contains(tran);
        }

        public void AddTransition(NDTransition tran)
        {
            if (tran == null)
                return;
            
            if (!transitions.Contains(tran))
            {
                transitions.Add(tran);
            }
        }

        public void RemoveTransition(NDTransition tran)
        {
            if (transitions.Contains(tran))
            {
                transitions.Remove(tran);
            }
        }

        private NDChart GetRootChart()
        {
            NDChart chart = this;
            while (chart.Host != null)
            {
                chart = chart.Host;
            }
            return chart;
        }
        #endregion

    }
}
