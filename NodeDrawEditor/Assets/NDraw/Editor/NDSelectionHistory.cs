using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEditor;

namespace ihaiu.NDraws
{
    [Serializable]
    public class NDSelectionHistory 
    {
        [Serializable]
        public class HistoryItem
        {
            [SerializeField]
            private NDChartTemplate chartTemplate;
            [NonSerialized]
            private NDChart         chart;
           
            public NDChart Chart
            {
                get
                {
                    if (this.chart != null)
                    {
                        return chart;
                    }
                   
                    if (this.chartTemplate == null)
                    {
                        return null;
                    }
                    return this.chartTemplate.chart;
                }
            }

            public HistoryItem(NDChart chart)
            {
                if (chart != null)
                {
                    this.chart = chart;
                    this.chartTemplate = chart.UsedInTemplate;
                }
            }
            public bool IsFor(NDChart testChart)
            {
                if (testChart == null)
                    return false;


                if (chart == null)
                    return false;


                if (chart == testChart)
                    return true;

                NDChart rootA = chart.RootChart;
                NDChart rootB = testChart.RootChart;


                return rootA == rootB || chart == rootB || rootA == testChart;
            }
        }


        [SerializeField]
        private List<HistoryItem> backList              = new List<HistoryItem>();
        [SerializeField]
        private List<HistoryItem> forwardList           = new List<HistoryItem>();
        [SerializeField]
        private List<NDSelection> selectionCache        = new List<NDSelection>();
        [SerializeField]
        private List<HistoryItem> recentlySelectedList  = new List<HistoryItem>();



        private void AddHistoryItem(NDChart chart)
        {
            if (chart == null || (this.backList.Count > 0 && this.backList[0].IsFor(chart)))
            {
                return;
            }
            this.forwardList.Clear();
            this.backList.Insert(0, new HistoryItem(chart));
            this.recentlySelectedList.RemoveAll((HistoryItem r) => r.Chart == chart);
            this.recentlySelectedList.Insert(0, new HistoryItem(chart));
        }

        private NDSelection GetSelection(NDChart chart)
        {
            if (chart == null)
            {
                return NDSelection.None;
            }
            using (List<NDSelection>.Enumerator enumerator = this.selectionCache.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    NDSelection current = enumerator.Current;
                    if (current.IsFor(chart))
                    {
                        return current;
                    }
                }
            }

            NDSelection fsmSelection = new NDSelection(chart);
            this.selectionCache.Add(fsmSelection);
            return fsmSelection;
        }

        public int RecentlySelectedCount
        {
            get
            {
                return this.recentlySelectedList.Count;
            }
        }

        public void Clear()
        {
            this.backList.Clear();
            this.forwardList.Clear();
            this.selectionCache.Clear();
            this.recentlySelectedList.Clear();
        }

        public List<NDChart> GetRecentlySelectedChart()
        {
            List<NDChart> list = new List<NDChart>();
            using (List<HistoryItem>.Enumerator enumerator = this.recentlySelectedList.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    NDChart chart = enumerator.Current.Chart;
                    if(chart != null)
                        list.Add(chart);
                }
            }
            return list;
        }

        public NDSelection SelectChart(NDChart chart)
        {
            AddHistoryItem(chart);
            return GetSelection(chart);
        }
        public bool CanMoveBack()
        {
            return this.backList.Count > 1;
        }
        public bool CanMoveForward()
        {
            return this.forwardList.Count > 0;
        }
        public NDChart MoveBack()
        {
            HistoryItem historyItem = this.backList[0];
            this.backList.RemoveAt(0);
            this.forwardList.Insert(0, historyItem);
            return this.backList[0].Chart;
        }
        public NDChart MoveForward()
        {
            HistoryItem historyItem = this.forwardList[0];
            this.forwardList.RemoveAt(0);
            this.backList.Insert(0, historyItem);
            return historyItem.Chart;
        }
        public void SanityCheck()
        {
            using (List<NDSelection>.Enumerator enumerator = this.selectionCache.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    NDSelection current = enumerator.Current;
                    current.SanityCheck();
                }
            }
            this.selectionCache.RemoveAll((NDSelection r) => r.IsOrphaned);
            this.backList.RemoveAll((HistoryItem r) => r.Chart == null);
            this.forwardList.RemoveAll((HistoryItem r) => r.Chart == null);
            this.recentlySelectedList.RemoveAll((HistoryItem r) => r.Chart == null);
        }


        public void DebugGUI()
        {
            GUILayout.Label("Back List: ", EditorStyles.boldLabel, new GUILayoutOption[0]);
            using (List<HistoryItem>.Enumerator enumerator = this.backList.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    HistoryItem current = enumerator.Current;
                    GUILayout.Label(Labels.GetFullChartLabelWithInstanceID(current.Chart), new GUILayoutOption[0]);
                }
            }
            GUILayout.Label("Forward List: ", EditorStyles.boldLabel, new GUILayoutOption[0]);
            using (List<HistoryItem>.Enumerator enumerator2 = this.forwardList.GetEnumerator())
            {
                while (enumerator2.MoveNext())
                {
                    HistoryItem current2 = enumerator2.Current;
                    GUILayout.Label(Labels.GetFullChartLabelWithInstanceID(current2.Chart), new GUILayoutOption[0]);
                }
            }
            GUILayout.Label("RecentlySelectedList: ", EditorStyles.boldLabel, new GUILayoutOption[0]);
            using (List<HistoryItem>.Enumerator enumerator3 = this.recentlySelectedList.GetEnumerator())
            {
                while (enumerator3.MoveNext())
                {
                    HistoryItem current3 = enumerator3.Current;
                    GUILayout.Label(Labels.GetFullChartLabelWithInstanceID(current3.Chart), new GUILayoutOption[0]);
                }
            }
            GUILayout.Label("SelectionCache: ", EditorStyles.boldLabel, new GUILayoutOption[0]);
            using (List<NDSelection>.Enumerator enumerator4 = this.selectionCache.GetEnumerator())
            {
                while (enumerator4.MoveNext())
                {
                    NDSelection current4 = enumerator4.Current;
                    GUILayout.Label(Labels.GetFullChartLabelWithInstanceID(current4.ActiveChart), new GUILayoutOption[0]);
                }
            }
        }
    }
}
