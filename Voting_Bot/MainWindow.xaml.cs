using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using System.Collections;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.Security.Policy;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace Voting_Bot
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            Thread seleniumThread = new Thread(RunSeleniumScript);
            seleniumThread.Start();
        }

        private void RunSeleniumScript()
        {
            string url_ = "";
            string xPath_Code = "";
            string Submit = "";

            Dispatcher.Invoke(() =>
            {
                url_ = InputBox.Text;
                xPath_Code = XPath_Code.Text;
                Submit = Button_XPath.Text;
            });

            IWebDriver driver = new ChromeDriver();

            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl(url_);

            bool continueLoop = true;

            while (continueLoop)
            {
                driver.Navigate().GoToUrl(url_);

                Thread.Sleep(2000);

                IWebElement element = driver.FindElement(By.XPath(xPath_Code));
                element.Click();

                IWebElement submitButton = driver.FindElement(By.XPath(Submit));
                submitButton.Click();

                driver.Navigate().Refresh();

                continueLoop = LoopyLoop();
            }

            driver.Quit();
        }

        private bool LoopyLoop()
        {
            return true;
        }
    }
}