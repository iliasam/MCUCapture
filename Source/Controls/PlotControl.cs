using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OxyPlot.WindowsForms;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Axes;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace MCUCapture
{
    public partial class PlotControl : UserControl
    {
        //item is group of stuctured values - "structure" in C

        PlotView plot = new PlotView();
        LineSeries[] dataSeries;//number of series must be equal to number of values

        int DataItemTotalSize = 0;//single data item size in bytes
        int ValuesCount = 1;//one data item is containing several values
        int DataItemsCount = 1;//number of items in received data
        int PrevDataItemsCount = 1;

        Int64[,] ProcessedData;

        List<DataStructureItem> DataStructureList = new List<DataStructureItem>();

        DataConversionClass DataConversionObj = new DataConversionClass();

        bool ControlInitialized = false;

        public PlotControl()
        {
            InitializeComponent();
            InitDataStructure();
            LoadSettings();
            nudValuesCount.Value = (decimal)DataStructureList.Count;
            ValuesCount = DataStructureList.Count;
            InitChart();
            ChangeProcessedDataSize();

            dataGridView1.AutoGenerateColumns = false;
            //dataGridView1.Columns[3].DataPropertyName = "DataSize";
            //DataGridViewComboBoxColumn cb = (DataGridViewComboBoxColumn)dataGridView1.Columns[3];
            //cb.ValueMember = "DataSize";

            dataGridView1.DataSource = DataStructureList;
            UpdateItemTotalSize();

            ControlInitialized = true;
        }

        public void ProcessData(byte[] rxData, bool isBigEndian)
        {
            if (rxData.Length < 1)
                return;

            if (rxData.Length % DataItemTotalSize != 0)
                return;

            DataItemsCount = rxData.Length / DataItemTotalSize;
            if (DataItemsCount != PrevDataItemsCount)
            {
                ChangeProcessedDataSize();
            }
            PrevDataItemsCount = DataItemsCount;

            ParseData(rxData, isBigEndian);

            Invoke((MethodInvoker)(() =>
            {
                DrawData();
                lblItemsCnt.Text = $"Items Count: {DataItemsCount}";
            }));
        }


        void ParseData(byte[] rxData, bool isBigEndian)
        {
            int offsetBytes = 0;
            //processing every data item - there are many of them
            for (int dataItemIndex = 0; dataItemIndex < DataItemsCount; dataItemIndex++)
            {
                byte[] dataItemArray = new byte[DataItemTotalSize];
                Array.Copy(rxData, offsetBytes, dataItemArray, 0, DataItemTotalSize);
                Int64[] values = DataConversionObj.ProcessDataItem(dataItemArray, DataStructureList, isBigEndian);
                for (int valueIndex = 0; valueIndex < values.Length; valueIndex++)//copy
                {
                    ProcessedData[valueIndex, dataItemIndex] = values[valueIndex];
                }
                offsetBytes += DataItemTotalSize;
            }
        }

        void InitDataStructure()
        {
            DataStructureList = new List<DataStructureItem>();
            DataStructureItem item = new DataStructureItem();
            item.PlotName = "Value1";
            item.IsSigned = true;
            item.DataSize = 2;
            item.EnablePlot = true;
            DataStructureList.Add(item);
        }

        //************************************************************************

        void InitChart()
        {
            var model = new PlotModel { Title = "Data Plot" };
            model.PlotType = PlotType.XY;

            var leftAxis = new LinearAxis();
            leftAxis.Position = AxisPosition.Left;
            leftAxis.Title = "Value";
            model.Axes.Add(leftAxis);

            var downAxis = new LinearAxis();
            downAxis.Position = AxisPosition.Bottom;
            downAxis.Title = "Sample";
            downAxis.PositionAtZeroCrossing = false;
            model.Axes.Add(downAxis); 

            plot.Model = model;
            plot.Dock = System.Windows.Forms.DockStyle.Fill;
            plot.Location = new System.Drawing.Point(0, 0);
            plot.TabIndex = 0;
            plot.Model.Background = OxyColor.FromRgb(255, 255, 255);

            panel1.Controls.Add(plot);

            ChangePlotSeriesCount();
        }

        void DrawData()
        {
            plot.Model.Axes[0].Minimum = double.NaN;
            plot.Model.Axes[0].Maximum = double.NaN;

            for (int valueIndex = 0; valueIndex < ValuesCount; valueIndex++)
            {
                if (DataStructureList[valueIndex].EnablePlot == false)
                {
                    dataSeries[valueIndex].Points.Clear();
                    continue;
                }

                dataSeries[valueIndex].Points.Clear();
                for (int i = 0; i < DataItemsCount; i++)
                {
                    double y = ProcessedData[valueIndex, i];
                    dataSeries[valueIndex].Points.Add(new DataPoint(i, y));
                }
            }

            plot.Refresh();
        }

        //change number of plotted series
        void ChangePlotSeriesCount()
        {
            plot.Model.Series.Clear();

            dataSeries = new LineSeries[ValuesCount];
            for (int i = 0; i < ValuesCount; i++)
            {
                dataSeries[i] = new LineSeries();
                dataSeries[i].Title = DataStructureList[i].PlotName;
                dataSeries[i].Color = GetNewColor(i);
                plot.Model.Series.Add(dataSeries[i]);
            }
            plot.Model.InvalidatePlot(true);
            plot.Refresh();
        }

        OxyColor GetNewColor(int ValueCount)
        {
            switch (ValueCount)
            {
                case 0:
                    return OxyColors.Red;
                case 1:
                    return OxyColors.Blue;
                case 2:
                    return OxyColors.Gray;
                case 3:
                    return OxyColors.Violet;

                default: return OxyColors.Black;
            }
        }

        //************************************************************************

        private void nudItemsCount_ValueChanged(object sender, EventArgs e)
        {
            if (ControlInitialized == false)
                return;

            ValuesCount = (int)nudValuesCount.Value;
            //Update DataStructureList
            while (DataStructureList.Count != ValuesCount)
            {
                if (ValuesCount > DataStructureList.Count)
                {
                    //add
                    DataStructureItem item = new DataStructureItem();
                    item.PlotName = $"Value{DataStructureList.Count + 1}";
                    item.IsSigned = true;
                    item.DataSize = 2;
                    item.EnablePlot = true;
                    DataStructureList.Add(item);
                }
                else
                {
                    //remove
                    DataStructureList.RemoveAt(DataStructureList.Count - 1);
                }
            }

            UpdateItemTotalSize();
            ChangeProcessedDataSize();
            ChangePlotSeriesCount();

            //Update dataGridView1
            dataGridView1.EndEdit();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = DataStructureList;
            dataGridView1.Refresh();
        }

        void ChangeProcessedDataSize()
        {
            ProcessedData = new Int64[ValuesCount, DataItemsCount];
        }

        void UpdateItemTotalSize()
        {
            DataItemTotalSize = GetSingleDataItemSize();
            lblItemSize.Text = $"Item Size: {DataItemTotalSize} byte";
            lblItemsCnt.Text = $"Items Count: N/A";
        }

        //return size in bytes
        int GetSingleDataItemSize()
        {
            int cnt = 0;
            foreach (var item in DataStructureList)
            {
                cnt += item.DataSize;
            }
            return cnt;
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            UpdateItemTotalSize();
        }

        public void LoadSettings()
        {
            string path = Application.StartupPath + @"\PlotDataSettings.dat";

            if (File.Exists(path) == false)
                return;

            Stream stream = File.Open(path, FileMode.Open);

            BinaryFormatter bin = new BinaryFormatter();
            DataStructureList = (List<DataStructureItem>)bin.Deserialize(stream);
            stream.Close();
        }

        public void SaveSettings()
        {
            string path = Application.StartupPath + @"\PlotDataSettings.dat";

            FileStream fs = new FileStream(path, FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, DataStructureList);
            fs.Close();
        }

    }//end of class

    [Serializable]
    class DataStructureItem
    {
        public string PlotName { get; set; }
        public bool EnablePlot { get; set; }
        public bool IsSigned { get; set; }
        public int DataSize { get; set; }
    }
}
