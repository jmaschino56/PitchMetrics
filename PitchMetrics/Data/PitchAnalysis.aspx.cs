using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using PitchMetrics.Models;

namespace PitchMetrics
{
    public partial class PitchAnalysis : System.Web.UI.Page
    {
       
        private int pitchcounter
        {
            get
            {
                if (Session["pitchcounter"] == null)
                    return 1;

                return (int)Session["pitchcounter"];
            }
            set
            {
                Session["pitchcounter"] = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            string FirstName = (string)Session["FirstName"];
            string LastName = (string)Session["LastName"];
            firstNamelbl.Text = FirstName;
            lastNamelbl.Text = LastName;
        }

        protected void ImportCSV(object sender, EventArgs e)
        {
            string ext = Path.GetExtension(FileUpload1.FileName);
            string[] validFileTypes = { "csv" };
            bool isValidType = validFileTypes.Any(t => ext == "." + t);
            if (isValidType)
            {
                errorMessagelbl.Text = "";
                //Upload and save the file.
                string csvPath = Server.MapPath("~/Files/") + Path.GetFileName(FileUpload1.PostedFile.FileName);
                FileUpload1.SaveAs(csvPath);
                List<string> frameNoStringList = new List<string>();
                List<string> xStringList = new List<string>();
                List<string> yStringList = new List<string>();
                List<string> zStringList = new List<string>();
                List<string> intensityStringList = new List<string>();
                using (var reader = new StreamReader(csvPath))
                {

                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(',');

                        frameNoStringList.Add(values[0]);
                        xStringList.Add(values[3]);
                        yStringList.Add(values[4]);
                        zStringList.Add(values[5]);
                        intensityStringList.Add(values[0]);

                    }
                }
                //remove header and convert to appropriate list
                frameNoStringList = frameNoStringList.Skip(1).ToList();
                List<int> frameNoIntList = frameNoStringList.Select(s => Convert.ToInt32(s)).ToList();

                xStringList = xStringList.Skip(1).ToList();
                List<double> xDoubleList = xStringList.Select(s => Convert.ToDouble(s)).ToList();

                yStringList = yStringList.Skip(1).ToList();
                List<double> yDoubleList = yStringList.Select(s => Convert.ToDouble(s)).ToList();

                zStringList = zStringList.Skip(1).ToList();
                List<double> zDoubleList = zStringList.Select(s => Convert.ToDouble(s)).ToList();

                intensityStringList = intensityStringList.Skip(1).ToList();
                List<int> intensityIntList = intensityStringList.Select(s => Convert.ToInt32(s)).ToList();

                List<int> removeIdxList = new List<int>();
                for (int i = 0; i < xDoubleList.Count; i++)
                {
                    if (xDoubleList[i] < -0.1)
                    {
                        frameNoIntList.RemoveAt(i);
                        xDoubleList.RemoveAt(i);
                        yDoubleList.RemoveAt(i);
                        zDoubleList.RemoveAt(i);
                        intensityIntList.RemoveAt(i);
                    }
                    if (xDoubleList[i] > 55.1)
                    {
                        frameNoIntList.RemoveAt(i);
                        xDoubleList.RemoveAt(i);
                        yDoubleList.RemoveAt(i);
                        zDoubleList.RemoveAt(i);
                        intensityIntList.RemoveAt(i);
                    }
                }
                for (int i = 0; i < xDoubleList.Count; i++)
                {
                    if (yDoubleList[i] < -7.0)
                    {
                        frameNoIntList.RemoveAt(i);
                        xDoubleList.RemoveAt(i);
                        yDoubleList.RemoveAt(i);
                        zDoubleList.RemoveAt(i);
                        intensityIntList.RemoveAt(i);
                    }
                    if (yDoubleList[i] > 7.0)
                    {
                        frameNoIntList.RemoveAt(i);
                        xDoubleList.RemoveAt(i);
                        yDoubleList.RemoveAt(i);
                        zDoubleList.RemoveAt(i);
                        intensityIntList.RemoveAt(i);
                    }
                }
                for (int i = 0; i < xDoubleList.Count; i++)
                {
                    if (zDoubleList[i] < -0.1)
                    {
                        frameNoIntList.RemoveAt(i);
                        xDoubleList.RemoveAt(i);
                        yDoubleList.RemoveAt(i);
                        zDoubleList.RemoveAt(i);
                        intensityIntList.RemoveAt(i);
                    }
                    if (zDoubleList[i] > 8.0)
                    {
                        frameNoIntList.RemoveAt(i);
                        xDoubleList.RemoveAt(i);
                        yDoubleList.RemoveAt(i);
                        zDoubleList.RemoveAt(i);
                        intensityIntList.RemoveAt(i);
                    }
                }
                for (int i = 0; i < xDoubleList.Count; i++)
                {
                    if (intensityIntList[i] < 20)
                    {
                        frameNoIntList.RemoveAt(i);
                        xDoubleList.RemoveAt(i);
                        yDoubleList.RemoveAt(i);
                        zDoubleList.RemoveAt(i);
                        intensityIntList.RemoveAt(i);
                    }
                    if (intensityIntList[i] > 25)
                    {
                        frameNoIntList.RemoveAt(i);
                        xDoubleList.RemoveAt(i);
                        yDoubleList.RemoveAt(i);
                        zDoubleList.RemoveAt(i);
                        intensityIntList.RemoveAt(i);
                    }
                }


                double hBrake = computeBrake(yDoubleList);
                double vBrake = computeBrake(zDoubleList);
                hBreaklbl.Text = brakeCalc(hBrake);
                vBreaklbl.Text = brakeCalc(vBrake);

                double velocity = veloCalc(xDoubleList, frameNoIntList);
                velocitylbl.Text = veloString(velocity);

                int spinRate = spinRateCalc(velocity, hBrake, vBrake);
                spinRatelbl.Text = srString(spinRate);

                double AUC = aucCalc(xDoubleList, zDoubleList);
                auclbl.Text = aucString(AUC);

                Queue xQueue = new Queue();
                Queue yQueue = new Queue();
                Queue xQueue1 = new Queue();
                Queue zQueue = new Queue();
                for(int i = 0; i < xDoubleList.Count; i++)
                {
                    xQueue.Enqueue(xDoubleList[i]);
                    yQueue.Enqueue(yDoubleList[i]);
                    xQueue1.Enqueue(xDoubleList[i]);
                    zQueue.Enqueue(zDoubleList[i]);
                }
                graphTopView(xQueue, yQueue);
                graphSideView(xQueue1, zQueue);
            }
            else
                errorMessagelbl.Text = "Please upload a CSV file.";
        }
        protected int spinRateCalc(double vlcy, double hB, double vB)
        {
            string hand = (string)Session["ThrowingHand"];
            string pitchType = pitchTypeDDL.SelectedItem.Text;
            double spinRateCalculation;

            if (hand == "Right")
            {
                if (pitchType == "4-Seam Fastball")
                    spinRateCalculation = 645.189 + 17.4268 * vlcy + (-15.1232 * (hB / 12.00)) + (-6.19979 * (vB / 12.00));
                else if (pitchType == "2-Seam Fastball")
                    spinRateCalculation = 895.91 + 13.6153 * vlcy + (-36.0004 * (hB / 12.00)) + (-11.4232 * (vB / 12.00));
                else if (pitchType == "Cutter         ")
                    spinRateCalculation = 2428.36 + (-0.3646) * vlcy + (-30.9157 * (hB / 12.00)) + (-11.7124 * (vB / 12.00));
                else if (pitchType == "Sinker         ")
                    spinRateCalculation = 540.741 + 17.3031 * vlcy + (-7.61082 * (hB / 12.00)) + (6.9547 * (vB / 12.00));
                else if (pitchType == "Splitter       ")
                    spinRateCalculation = -2163.73 + 43.1581 * vlcy + (-38.6206 * (hB / 12.00)) + (-30.8566 * (vB / 12.00));
                else if (pitchType == "Slider         ")
                    spinRateCalculation = 3028.65 + (-7.08982) * vlcy + (-15.8509 * (hB / 12.00)) + (-7.0898 * (vB / 12.00));
                else if (pitchType == "Curveball      ")
                    spinRateCalculation = 2207.58 + 3.8413 * vlcy + (-52.193 * (hB / 12.00)) + (-20.5368 * (vB / 12.00));
                else if (pitchType == "Knuckle-Curve  ")
                    spinRateCalculation = 1646.14 + 10.9177 * vlcy + (-35.9926 * (hB / 12.00)) + (-10.293 * (vB / 12.00));
                else if (pitchType == "Changeup       ")
                    spinRateCalculation = 1760.23 + 1.0025 * vlcy + (-26.3112 * (hB / 12.00)) + (-22.0447 * (vB / 12.00));
                else if (pitchType == "Knuckleball    ")
                    spinRateCalculation = 3272.03 + -26.0277 * vlcy + (-48.6704 * (vB / 12.00));
                else
                    spinRateCalculation = -1;
            }
            else if (hand == "Left ")
            {
                if (pitchType == "4-Seam Fastball")
                    spinRateCalculation = 793.408 + 15.8943 * vlcy + (0.7774 * (hB / 12.00)) + (-1.7694 * (vB / 12.00));
                else if (pitchType == "2-Seam Fastball")
                    spinRateCalculation = 1116.52 + 11.0587 * vlcy + (30.3841 * (hB / 12.00)) + (-3.3250 * (vB / 12.00));
                else if (pitchType == "Cutter         ")
                    spinRateCalculation = -487.481 + 29.8182 * vlcy + (17.4149 * (hB / 12.00)) + (18.4206 * (vB / 12.00));
                else if (pitchType == "Sinker         ")
                    spinRateCalculation = -289.292 + 27.0463 * vlcy + (49.7309 * (hB / 12.00)) + (-52.3558 * (vB / 12.00));
                else if (pitchType == "Splitter       ")
                    spinRateCalculation = -2163.73 + 43.1581 * vlcy + (38.6206 * (hB / 12.00)) + (-30.8566 * (vB / 12.00));
                else if (pitchType == "Slider         ")
                    spinRateCalculation = 2021.31 + 1.5763 * vlcy + (30.2979 * (hB / 12.00)) + (-11.9175 * (vB / 12.00));
                else if (pitchType == "Curveball      ")
                    spinRateCalculation = 2493.52 + 0.8936 * vlcy + (0.6435 * (hB / 12.00)) + (-17.3804 * (vB / 12.00));
                else if (pitchType == "Knuckle-Curve  ")
                    spinRateCalculation = 3379.06 + (-11.5026) * vlcy + (-46.2289 * (hB / 12.00)) + (-2.6884 * (vB / 12.00));
                else if (pitchType == "Changeup       ")
                    spinRateCalculation = 1181.83 + 8.9878 * vlcy + (27.5945 * (hB / 12.00)) + (-28.8073 * (vB / 12.00));
                else if (pitchType == "Knuckleball    ")
                    spinRateCalculation = 3272.03 + -26.0277 * vlcy + (-48.6704 * (vB / 12.00));
                else
                    spinRateCalculation = -1;
            }
            else
                spinRateCalculation = 1;
            return Convert.ToInt32(spinRateCalculation);
        }
        public string srString(int computedSpinRate)
        {
            string computedSpinRateString = computedSpinRate + " rpm";
            return computedSpinRateString;
        }
        public double veloCalc(List<double> x, List<int> f)
        {
            double position0 = x[0];
            double position1 = x[1];
            double time0 = Convert.ToDouble(f[0]) / 30; //Divide by number of frames per sec
            double time1 = Convert.ToDouble(f[1]) / 30; //Divide by number of frames per sec
            double velocityCalculation = Math.Round(Math.Abs(0.681818 * ((position0 - position1) / (time0 - time1))), 1);
            return velocityCalculation;
        }
        public string veloString(double computedVelocity)
        {
            string computedVelocityString = computedVelocity + " mph";
            return computedVelocityString;
        }
        public double computeBrake(List<double>j)
        {
            double computedHBreak = Math.Round(12 * (j.First() - j.Last()), 2);
            return computedHBreak;
        }
        public double aucCalc(List<double>x, List<double>z)
        {
            double integral = 0;
            for (int i = 1; i < x.Count; i++)
            {
                integral += (z[i] + z[i - 1]) / 2 * (x[i] - x[i - 1]);
            }
            return Math.Abs(Math.Round(integral, 2));
        }
        public string aucString(double area)
        {
            string areaString = area + " ft^2";
            return areaString;
        }
        public string brakeCalc(double computedBrake)
        {
            string computedBrakeString = computedBrake.ToString() + "\"";
            return computedBrakeString;
        }
        protected void graphTopView(Queue x, Queue y)
        {
            double[] top = new double[x.Count];
            double[] bottom = new double[x.Count];
            double[] topExtra = new double[x.Count];
            double[] bottomExtra = new double [x.Count];
            for (int i = 0; i < x.Count; i++)
            {
                top[i] =  0.71;
                bottom[i] = -0.71;
                topExtra[i] = 0.96;
                bottomExtra[i] = -0.96;
            }

            DataTable dt = new DataTable();

            dt.Columns.Add("X");
            dt.Columns.Add("Y");
            for (int i = 0; i < x.Count; i++)
            {
                DataRow row = dt.NewRow();
                row["X"] = x.Dequeue();
                row["Y"] = y.Dequeue(); //have to switch x and y because of ti logging
                dt.Rows.Add(row);
            }

            Chart1.DataSource = dt;
            for (int i = 0; i < x.Count; i++)
            {
                Chart1.Series["Series1"].Points.Add(topExtra[i]);
                Chart1.Series["Series2"].Points.Add(bottomExtra[i]);
                Chart1.Series["Series3"].Points.Add(top[i]);
                Chart1.Series["Series4"].Points.Add(bottom[i]);
            }
            Chart1.Series["Series5"].XValueMember = "X";
            Chart1.Series["Series5"].YValueMembers = "Y";
            Chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
            Chart1.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;
            Chart1.ChartAreas["ChartArea1"].AxisX.MajorTickMark.Enabled = false;
            Chart1.ChartAreas["ChartArea1"].AxisY.MajorTickMark.Enabled = false;
            Chart1.DataBind();
        }
        protected void graphSideView(Queue x, Queue z)
        {
            double[] top1 = new double[x.Count];
            double[] bottom1 = new double[x.Count];
            double[] topExtra1 = new double[x.Count];
            double[] bottomExtra1 = new double[x.Count];
            for (int i = 0; i < x.Count; i++)
            {
                topExtra1[i] = 3.75;
                top1[i] = 3.50;
                bottom1[i] = 1.5;
                bottomExtra1[i] = 1.25;
            }

            DataTable dt = new DataTable();

            dt.Columns.Add("X");
            dt.Columns.Add("Z");
            for (int i = 0; i < x.Count; i++)
            {
                DataRow row = dt.NewRow();
                row["X"] = x.Dequeue();
                row["Z"] = z.Dequeue(); 
                dt.Rows.Add(row);
            }

            Chart2.DataSource = dt;
            for (int i = 0; i < x.Count; i++)
            {
                Chart2.Series["Series1"].Points.Add(topExtra1[i]);
                Chart2.Series["Series2"].Points.Add(top1[i]);
                Chart2.Series["Series3"].Points.Add(bottom1[i]);
                Chart2.Series["Series4"].Points.Add(bottomExtra1[i]);
            }
            Chart2.Series["Series5"].XValueMember = "X";
            Chart2.Series["Series5"].YValueMembers = "Z";
            Chart2.ChartAreas["ChartArea2"].AxisX.MajorGrid.Enabled = false;
            Chart2.ChartAreas["ChartArea2"].AxisY.MajorGrid.Enabled = false;
            Chart2.ChartAreas["ChartArea2"].AxisX.MajorTickMark.Enabled = false;
            Chart2.ChartAreas["ChartArea2"].AxisY.MajorTickMark.Enabled = false;
            Chart2.DataBind();
        }
       
        protected void saveBTN_Click(object sender, EventArgs e)
        {
            
            if (IsValid)
            {
                var parameters = SqlDataSource2.InsertParameters;
                parameters["Date"].DefaultValue = dateTxt.Text;
                parameters["FirstName"].DefaultValue = firstNamelbl.Text;
                parameters["LastName"].DefaultValue = lastNamelbl.Text;
                parameters["PitchNo"].DefaultValue = pitchNoTxt.Text;
                parameters["PitchType"].DefaultValue = pitchTypeDDL.SelectedItem.Text;
                parameters["Velocity"].DefaultValue = velocitylbl.Text;
                parameters["SpinRate"].DefaultValue = spinRatelbl.Text;
                parameters["HorizontalBreak"].DefaultValue = hBreaklbl.Text;
                parameters["VerticalBreak"].DefaultValue = vBreaklbl.Text;
                parameters["AUC"].DefaultValue = auclbl.Text;

                SqlDataSource2.Insert();
                velocitylbl.Text = "";
                spinRatelbl.Text = "";
                hBreaklbl.Text = "";
                vBreaklbl.Text = "";
                auclbl.Text = "";
                pitchcounter++;
                pitchNoTxt.Text = pitchcounter.ToString();
            }
        }

        protected void dateTxt_PreRender(object sender, EventArgs e)
        {
            dateTxt.Text = DateTime.Today.ToString("yyyy-MM-dd");
        }

        protected void pitchNoTxt_PreRender(object sender, EventArgs e)
        {
            pitchNoTxt.Text = pitchcounter.ToString();
        }
    }
}


