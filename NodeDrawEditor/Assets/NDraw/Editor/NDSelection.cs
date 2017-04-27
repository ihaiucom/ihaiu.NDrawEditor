using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

namespace ihaiu.NDraws
{
    [Serializable]
    public class NDSelection
    {

        [SerializeField]
        private Vector2     scrollPosition;
        [SerializeField]
        private float       zoom;

        [NonSerialized]
        private NDChart         activeChart;
        [NonSerialized]
        private NDNode          activeNode;
        [NonSerialized]
        private NDTransition    activeTransition;


        [NonSerialized]
        private List<NDNode>    nodes;


        public Vector2 ScrollPosition
        {
            get
            {
                return this.scrollPosition;
            }
            set
            {
                this.scrollPosition = value;
            }
        }
        public float Zoom
        {
            get
            {
                return this.zoom;
            }
            set
            {
                this.zoom = value;
            }
        }


        public NDChart ActiveChart
        {
            get
            {
                return activeChart;
            }

            set
            {
                activeChart = value;
            }
        }

        public NDNode ActiveNode
        {
            get
            {
                if (this.ActiveChart == null || !this.ActiveChart.ContainsNode(this.activeNode))
                {
                    this.activeNode = null;
                }

                return this.activeNode;
            }

            set
            {
                if (this.ActiveChart != null)
                {
                    if (this.ActiveChart.ContainsNode(value))
                    {
                        this.activeNode = value;
                    }
                }
            }
        }



        public NDTransition ActiveTransition
        {
            get
            {
                if (this.ActiveChart == null || !this.ActiveChart.ContainsTransition(this.activeTransition))
                {
                    this.activeTransition = null;
                }
                return this.activeTransition;
            }

            set
            {
                if (this.ActiveChart != null)
                {
                    if (this.ActiveChart.ContainsTransition(value))
                    {
                        this.activeTransition = value;
                    }
                }
            }
        }

        public bool IsOrphaned
        {
            get
            {
                return this.ActiveChart == null;
            }
        }

        public static NDSelection None
        {
            get
            {
                return new NDSelection(null);
            }
        }

        public List<NDNode> Nodes
        {
            get
            {
                if (this.nodes == null)
                {
                    this.nodes = new List<NDNode>();
                    if (this.ActiveChart != null)
                    {
                        this.nodes.Add(ActiveChart.StartNode);
                    }
                }
                return this.nodes;
            }
        }


        public NDSelection(NDChart chart)
        {
            this.ActiveChart = chart;
            this.Zoom = 1f;
        }

        public bool IsFor(NDChart testChart)
        {
            if (testChart == null)
                return false;

            if (activeChart == null)
                return false;

            if (activeChart == testChart)
                return true;

            NDChart rootA = activeChart.RootChart;
            NDChart rootB = testChart.RootChart;

            return rootA == rootB || activeChart == rootB || rootA == testChart;
        }

        public void SanityCheck()
        {
//            if (this.ActiveChart != null)
//            {
//                List<NDNode> nodes = this.ActiveChart.Nodes;
//                for (int j = 0; j < nodes.Count; j++)
//                {
//                    NDNode fsmState = nodes[j];
//                    fsmState.Chart =ActiveFsm;
//                }
//            }
        }
    }

}