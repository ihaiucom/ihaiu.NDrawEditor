using System;
using UnityEngine;

namespace ihaiu.NDraws
{
    [Serializable]
    public class NDChartTemplate : ScriptableObject
    {
        [SerializeField]
        private string  category;
        public NDChart  chart;

        public string Category
        {
            get
            {
                return this.category;
            }
            set
            {
                this.category = value;
            }
        }

        public void OnEnable()
        {
            if (this.chart != null)
            {
                this.chart.UsedInTemplate = this;
            }
        }
    }
}