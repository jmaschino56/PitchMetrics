using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using PitchMetrics;
using PitchMetrics.Models;

namespace PitchMetrics.Tests
{
    [TestClass]
    public class UnitTest
    {
        PitchAnalysis pitchAnalysis = new PitchAnalysis();
        [TestMethod]
        public void computeBreak_TestVert()
        {
            List<double> testList = new List<double>() { 7.0, 4.0 };
            double result = 36.00;
            Assert.AreEqual(result, pitchAnalysis.computeBrake(testList));
        }

        [TestMethod]
        public void computeBreak_TestRightHorz()
        {
            List<double> testList = new List<double>() { -1.5 , 1.3};
            double result = -33.60;
            Assert.AreEqual(result, pitchAnalysis.computeBrake(testList));
        }

        [TestMethod]
        public void computeBreak_TestLeftHorz()
        {
            List<double> testList = new List<double>() { 2.0, -0.54 };
            double result = 30.48;
            Assert.AreEqual(result, pitchAnalysis.computeBrake(testList));
        }

        [TestMethod]
        public void brakeString_TestPost()
        {
            double calcBrake = 12.12;
            string result = "12.12\"";
            Assert.AreEqual(result, pitchAnalysis.brakeCalc(calcBrake));
        }

        [TestMethod]
        public void brakeString_TestNeg()
        {
            double calcBrake = -24.10;
            string result = "-24.1\"";
            Assert.AreEqual(result, pitchAnalysis.brakeCalc(calcBrake));
        }

        [TestMethod]
        public void veloCalc_Test1()
        {
            List<double> xPos = new List<double>() { 55.0, 51.3 };
            List<int> fNo = new List<int>() { 1, 2 };
            double result = 75.7;
            Assert.AreEqual(result, pitchAnalysis.veloCalc(xPos, fNo));
        }

        [TestMethod]
        public void veloCalc_Test2()
        {
            List<double> xPos = new List<double>() { 55.0, 50.82 };
            List<int> fNo = new List<int>() { 1, 2 };
            double result = 85.5;
            Assert.AreEqual(result, pitchAnalysis.veloCalc(xPos, fNo));
        }

        [TestMethod]
        public void veloCalc_Test3()
        {
            List<double> xPos = new List<double>() { 55.0, 50.3 };
            List<int> fNo = new List<int>() { 1, 2 };
            double result = 96.1;
            Assert.AreEqual(result, pitchAnalysis.veloCalc(xPos, fNo));
        }

        [TestMethod]
        public void veloString_test()
        {
            double velo = 92.3;
            string result = "92.3 mph";
            Assert.AreEqual(result, pitchAnalysis.veloString(velo));
        }

        [TestMethod]
        public void srString_Test()
        {
            int spinRate = 2350;
            string result = "2350 rpm";
            Assert.AreEqual(result, pitchAnalysis.srString(spinRate));
        }

        [TestMethod]
        public void aucCalc_Test1()
        {
            List<double> xList = new List<double>() {55,44,33,22,11,0};
            List<double> zList = new List<double>() { 7, 6, 5, 4, 3, 2 };
            double result = 247.5;
            Assert.AreEqual(result, pitchAnalysis.aucCalc(xList,zList));
        }

        [TestMethod]
        public void aucCalc_Test2()
        {
            List<double> xList = new List<double>() { 55, 44, 33, 22, 11, 0 };
            List<double> zList = new List<double>() { 7, 6.75, 6.25, 5.5, 4.5, 3.25 };
            double result = 309.38;
            Assert.AreEqual(result, pitchAnalysis.aucCalc(xList, zList));
        }

        [TestMethod]
        public void aucString_Test()
        {
            double AUC = 310.34;
            string result = "310.34 ft^2";
            Assert.AreEqual(result, pitchAnalysis.aucString(AUC));
        }
    }
}
