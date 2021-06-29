//using NUnit.Framework;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Remote;
//using OpenQA.Selenium.Chrome;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;
//using NUnit.Framework.Interfaces;
//using AventStack.ExtentReports;
//using AventStack.ExtentReports.Reporter;
//using OpenQA.Selenium.Edge;
//using OpenQA.Selenium.Firefox;
//using OpenQA.Selenium.IE;
//using FluentAssertions;
//using Newtonsoft.Json;
//using System.IO;
//using Newtonsoft.Json.Linq;
////using SeleniumFramwork.Src.PageObjects;
////using SeleniumFramwork.Src.PageObjects.Pages;
//using System.Text.RegularExpressions;

//namespace SeleniumFramwork
//{
//    //  [TestFixture]
//    [TestFixture("chrome")]

//    class ExtentManager
//    {


//        private static IWebDriver driver;
//        private static ExtentReports extent;
//        private static ExtentHtmlReporter htmlReporter;
//        private static ExtentTest test;
//        private string browser;
//        private string jsonFileData;
//        private string testcasename;
//        private string jsonFilePath;




//        string timeStamp = DateTime.Now.ToString("MMddyyyyHHmmss");
//        ThreadLocal<ExtentTest> extenttest = new ThreadLocal<ExtentTest>();

//        public object orderDto { get; private set; }

//        //private ExtentTest test;

//        [OneTimeSetUp]
//        public void SetupReporting()
//        {
//            htmlReporter = new ExtentHtmlReporter(@"C:\Users\Ashrith\source\repos\SeleniumFramwork\SeleniumFramwork\reports" + timeStamp + "extentreport1.html");

//            extent = new ExtentReports();
//            extent.AttachReporter(htmlReporter);
//        }


//        public ExtentManager()
//        {

//        }
//        public ExtentManager(string browser)
//        {
//            this.browser = browser;
//        }
//        [SetUp]
//        public void InitBrowser()
//        {

//            testcasename = NUnit.Framework.TestContext.CurrentContext.Test.Name;

//            jsonFilePath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\.." + "\\" + "TestData" + "\\" + testcasename + ".json"));
//            jsonFileData = File.ReadAllText(jsonFilePath);


//            switch (browser)
//            {

//                ////    case "chrome":
//                ////        driver = new ChromeDriver();
//                ////        break;
//                case "ie":
//                    driver = new InternetExplorerDriver();
//                    break;
//                    ////    case "edge":
//                    ////        /*
//                    ////      var options = new EdgeOptions();
//                    ////      options.UseChromium = true;
//                    ////       driver = new EdgeDriver(options);
//                    ////       */
//                    ////        EdgeOptions edgeOptions = new EdgeOptions()
//                    ////        {
//                    ////            UseInPrivateBrowsing = true,
//                    ////        };
//                    ////        driver = new EdgeDriver(edgeOptions);

//                    ////        //   driver = new EdgeDriver();
//                    ////        break;
//                    ////    case "firefox":
//                    ////        driver = new FirefoxDriver();
//                    ////        break;
//                    ////    default:
//                    ////        driver = new ChromeDriver();
//                    ////        break;
//            }





//            //   FirefoxDriverService service = FirefoxDriverService.CreateDefaultService();
//            //   service.FirefoxBinaryPath = @"C:\Program Files (x86)\Mozilla Firefox\firefox.exe";
//            // FirefoxDriver driver = new FirefoxDriver(service);
//            //  driver = new FirefoxDriver(service);
//            //driver = new ChromeDriver();
//            //  driver = new FirefoxDriver();
//            //  driver = new InternetExplorerDriver();
//            // driver = new EdgeDriver();
//            //  Thread.Sleep(1000);
//            // driver.Manage().Window.Maximize();
//        }

//        [Test]
//        public void PassingTest()
//        {
//            test = extent.CreateTest("Passing test").Info("Test Started");
//            test.Log(Status.Info, "Url is entered");


//            Console.WriteLine("1-Facebook Page opened");
//            test.Log(Status.Info, "Website is opened");

//            try
//            {

//                Assert.IsTrue(true);
//                test.Pass("Assertion passed");
//                test.Log(Status.Pass, "Assertion is passed and logged");
//            }
//            catch (AssertionException)
//            {
//                test.Fail("Assertion failed");
//                throw;
//            }
//        }

//        [Test]
//        public void FailingTest()
//        {
//            test = extent.CreateTest("Failing test");
//            jasondata j = new jasondata();
//            var jsondatatest = j.jasontestdata<Result>("responseData.results", jsonFileData);
//            var cnt = jsondatatest.Count;
//            Console.WriteLine("2-Facebook Page opened");
//            try
//            {
//                jsondatatest[0].Should().BeEquivalentTo(jsondatatest[0], option => option.ThrowingOnMissingMembers());
//                jsondatatest[1].Should().BeEquivalentTo(jsondatatest[1]);
//                //CollectionAssert.AreEqual(expected, atcual);
//                Assert.IsTrue(true);
//                test.Pass("Assertion passed");
//                test.Log(Status.Pass, "Assertion is passed and logged");
//                var upDateJsonData = j.SerializeJasonData(jsonFileData, jsonFilePath,1234);
//            }
//            catch (AssertionException ae)
//            {
//                test.Fail("Assertion failed");
//                test.Log(Status.Fail, "Assertion is failed and logged");
//                test.Log(Status.Fail, ae.ToString());
//                throw;
//            }
//        }




//        [Test]
//        public void SecondPassingTest()
//        {
//            test = extent.CreateTest(" Second Passing test");

//            //driver.Navigate().GoToUrl("http://www.facebook.com");
//            Console.WriteLine("3-Facebook Page opened");

//            try
//            {
//                Assert.IsTrue(true);
//                test.Pass("Assertion passed");
//                test.Pass("Assertion passed");
//                test.Pass("Assertion passed");


//            }
//            catch (AssertionException)
//            {
//                test.Fail("Assertion failed");
//                throw;
//            }
//        }

//        /*
//                [Test]
//                public void CaptureScreenshot()
//                {
//                    test = extent.CreateTest("CaptureScreenshot");    
//                    driver = new FirefoxDriver();
//                    driver.Navigate().GoToUrl("http://www.automationtesting.in");
//                    string title = driver.Title;
//                    Assert.AreEqual("Home - Automation Test", title);
//                    test.Log(Status.Pass, "Test Passed");
//                }
//        */





//        /*
//        publicstaticstringTakeScreenshot()
//        {
//            string path1 = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "");
//            string path = path1 + "Screenshot\\" + Utility.RandomString(4, true) + ".png";
//            Screenshot screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
//            screenshot.SaveAsFile(path, ScreenshotImageFormat.Png);
//            return path;

//            //Call method will return a path as string.
//            string path = LoginPage.GetShot();
//            //Pass this path in the ”AddScreenCaptureFromPath”
//            scenario.AddScreenCaptureFromPath(path);
//*/


//        [TearDown]
//        public void CloseBrowser()
//        {
//            //  driver.Quit();
//            var status = TestContext.CurrentContext.Result.Outcome.Status;
//            var stackTrace = "<pre>" + TestContext.CurrentContext.Result.StackTrace + "</pre>";
//            var errorMessage = TestContext.CurrentContext.Result.Message;

//            if (status == TestStatus.Failed)
//            {
//                //string screenShotPath = GetScreenshot.Capture(driver, "ScreenShotName");
//                test.Log(Status.Fail, stackTrace + errorMessage);
//                //test.Log(Status.Fail, "Snapshot below: " + test.AddScreenCaptureFromBase64String(screenShotPath));
//            }
//            // extent.EndTest(test);                                                                                                                                                                                                                                                                                                                                                                                                            extent.EndTest(test);

//        }

//        [OneTimeTearDown]
//        public void GenerateReport()
//        {
//            extent.Flush();
//        }
//    }
//    class jasondata
//    {
//        public List<T> jasontestdata<T>(string rootpath, string jfiledata)
//        {
//            Newtonsoft.Json.Linq.JObject resultobject = Newtonsoft.Json.Linq.JObject.Parse(jfiledata);
//            var testdata = resultobject.SelectToken(rootpath).ToString();
//            return JsonConvert.DeserializeObject<List<T>>(testdata);

//        }
//        public T jasontestdata1<T>(string rootpath, string jfiledata)
//        {

//            Newtonsoft.Json.Linq.JObject resultobject = Newtonsoft.Json.Linq.JObject.Parse(jfiledata);
//            var testdata = resultobject.SelectToken(rootpath).ToString();
//            return JsonConvert.DeserializeObject<T>(testdata);

//        }
//        public string SerializeJasonData(string jfiledata, string jsonFilePath,int LoanNumber)
//        {
//            string json = File.ReadAllText(jsonFilePath);
//            //string jsonstring = json.Replace("\r\n  ", "");
//            //string jsonstring1 = Regex.Replace(jsonstring, @"\s+", "");
//            dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
//            jsonObj.loanNumber = LoanNumber;
//            string updatedJsonString = jsonObj.ToString();
//            File.WriteAllText(jsonFilePath, updatedJsonString);
//            //string output = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
//            return updatedJsonString;
//        }
//    }
//    public class Result
//    {
//        public string GsearchResultClass { get; set; }
//        public string unescapedUrl { get; set; }
//        public string url { get; set; }
//        public string visibleUrl { get; set; }
//        public string cacheUrl { get; set; }
//        public string title { get; set; }
//        public string titleNoFormatting { get; set; }
//        public string content { get; set; }
//    }

//    public class Page
//    {
//        public string start { get; set; }
//        public int label { get; set; }
//    }

//    public class Cursor
//    {
//        public List<Page> pages { get; set; }
//        public string estimatedResultCount { get; set; }
//        public int currentPageIndex { get; set; }
//        public string moreResultsUrl { get; set; }
//    }

//    public class ResponseData
//    {
//        public List<Result> results { get; set; }
//        public Cursor cursor { get; set; }
//    }

//    public class Root
//    {
//        public ResponseData responseData { get; set; }
//        public object responseDetails { get; set; }
//        public int responseStatus { get; set; }
//        public string loanNumber { get; set; }
//    }
//}