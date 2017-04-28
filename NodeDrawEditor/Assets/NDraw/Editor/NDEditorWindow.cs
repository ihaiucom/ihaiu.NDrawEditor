using UnityEngine;
using System.Collections;


namespace ihaiu.NDraws
{
    public class NDEditorWindow : BaseEditorWindow
    {

        public static void OpenWindow()
        {
            GetWindow<NDEditorWindow>();
        }

        private static NDEditorWindow instance;
        public static bool IsOpen()
        {
            return instance != null;
        }


        public NDEditor ndEditor;

        public override void Initialize()
        {
            instance = this;

            if (ndEditor == null)
            {
                ndEditor = new NDEditor();
            }

            ndEditor.InitWindow(this);
            ndEditor.OnEnable();
            NDEditor.SelectChart(testChart);
        }


        override public void DoGUI()
        {
            ndEditor.OnGUI();
        }


        private NDChart _testChart;
        public NDChart testChart
        {
            get
            {
                if (_testChart == null)
                {
                    NDChart chart = new NDChart();

                    NDNode start = new NDNode("Start");
                    chart.AddNode(start);


                    NDNode con = new NDNode("Condition");
                    chart.AddNode(con);


                    NDNode ihaiu = new NDNode("ihaiu");
                    chart.AddNode(ihaiu);


                    NDNode end = new NDNode("End");
                    chart.AddNode(end);


                    chart.AddTransition(new NDTransition(NDEvent.Entered, start, ihaiu));
                    chart.AddTransition(new NDTransition(NDEvent.Finished, start, con));
                    chart.AddTransition(new NDTransition(NDEvent.Finished, con, ihaiu));
                    chart.AddTransition(new NDTransition(NDEvent.Finished, ihaiu, end));


                    _testChart = chart;
                }

                return _testChart;
            }
        }
    }

}