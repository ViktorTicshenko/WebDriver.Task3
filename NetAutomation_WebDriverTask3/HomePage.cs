using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;

namespace NetAutomation_WebDriverTask3
{
    public class HomePage : BasePage
    {
        private readonly By addToEstimateBtnLocator = By.XPath("//span[text()='Add to estimate']");
        private readonly By computeEngineBtnLocator = By.XPath("//h2[text()='Compute Engine']");
        private readonly By numOfInstancesLocator = By.XPath("//input[@type = 'number' and @min = '0' and @max = '50000']");
        private readonly By operatingSystemLocator = By.XPath("//span[text()='Operating System / Software']/ancestor::*[@role='combobox']");
        private readonly By operatingSystemChoiceLocator = By.XPath("//ul[@aria-label='Operating System / Software']//li[@data-value = 'free-debian-centos-coreos-ubuntu-or-byol-bring-your-own-license']");
        private readonly By provisioningModelSelector = By.XPath("//label[text()='Regular']/preceding-sibling::input[@type='radio']/parent::div");
        private readonly By machineFamilyLocator = By.XPath("//span[text()='Machine Family']/ancestor::*[@role='combobox']");
        private readonly By machineFamilyChoiceLocator = By.XPath("//ul[@aria-label='Machine Family']//li[@data-value = 'general-purpose']");
        private readonly By machineSeriesLocator = By.XPath("//span[text()='Series']/ancestor::*[@role='combobox']");
        private readonly By machineSeriesChoiceLocator = By.XPath("//ul[@aria-label='Series']//li[@data-value = 'n1']");
        private readonly By machineTypeLocator = By.XPath("//span[text()='Machine type']/ancestor::*[@role='combobox']");
        private readonly By machineTypeChoiceLocator = By.XPath("//ul[@aria-label='Machine type']//li[@data-value = 'n1-standard-8']");
        private readonly By addGPUsLocator = By.XPath("//div[text()='Add GPUs']/../..//button[@type='button' and @role='switch']");
        private readonly By gpuModelLocator = By.XPath("//span[text()='GPU Model']/ancestor::*[@role='combobox']");
        private readonly By gpuModelChoiceLocator = By.XPath("//ul[@aria-label='GPU Model']//li[@data-value = 'nvidia-tesla-v100']");
        private readonly By numberOfGPUsLocator = By.XPath("//span[text()='Number of GPUs']/ancestor::*[@role='combobox']");
        private readonly By numberOfGPUsChoiceLocator = By.XPath("//ul[@aria-label='Number of GPUs']//li[@data-value = '1']");
        private readonly By localSSDTypeLocator = By.XPath("//span[text()='Local SSD']/ancestor::*[@role='combobox']");
        private readonly By localSSDTypeChoiceLocator = By.XPath("//ul[@aria-label='Local SSD']//li[@data-value = '2']");
        private readonly By regionTypeLocator = By.XPath("//span[text()='Region']/ancestor::*[@role='combobox']");
        private readonly By regionTypeChoiceLocator = By.XPath("//ul[@aria-label='Region']//li[@data-value = 'europe-west4']");
        private readonly By openShareBtnLocator = By.XPath("//span[text()='Share']/ancestor::button[@aria-label='Open Share Estimate dialog']");
        private readonly By openShareLink = By.XPath("//a[text()='Open estimate summary']");
        private readonly Lazy<By> machineTypeResultLocator = new(By.XPath("//span[text()='Machine type']"));
        private readonly Lazy<By> gpuModelResultLocator = new(By.XPath("//span[text()='GPU Model']"));
        private readonly Lazy<By> numOfGPUsResultLocator = new(By.XPath("//span[text()='Number of GPUs']"));
        private readonly Lazy<By> localSSDsResultLocator = new(By.XPath("//span[text()='Local SSD']"));
        private readonly Lazy<By> numOfInstancesResultLocator = new(By.XPath("//span[text()='Number of Instances']"));
        private readonly Lazy<By> osTypeResultLocator = new(By.XPath("//span[text()='Operating System / Software']"));
        private readonly Lazy<By> provisioningModelResultLocator = new(By.XPath("//span[text()='Provisioning Model']"));
        private readonly Lazy<By> addGPUsResultLocator = new(By.XPath("//span[text()='Add GPUs']"));

        public HomePage(IWebDriver driver, string url = "") : base(driver, url)
        {
            //
        }

        public void AddToEstimateBtn()
        {
            driver.FindElement(addToEstimateBtnLocator).Click();
        }

        private bool IsElementLoaded(By locator, int milliSecondsToWait = 2000)
        {
            ReadOnlyCollection<IWebElement>? elements = null;

            WebDriverWait wait = new(driver, TimeSpan.FromMilliseconds(milliSecondsToWait));
            
            return wait.Until
            (
                driver => 
                { 
                    elements = driver.FindElements(locator); 
                    return elements.Count > 0 && elements[0].Displayed; 
                }
            );
        }

        IWebElement FindParentWithRole(IWebElement element, string role)
        {
            IWebElement parent = (IWebElement)((IJavaScriptExecutor)driver).ExecuteScript("return arguments[0].parentNode;", element);
            while (parent != null)
            {
                if (parent.GetAttribute("role") == role)
                {
                    return parent;
                }
                parent = (IWebElement)((IJavaScriptExecutor)driver).ExecuteScript("return arguments[0].parentNode;", parent);
            }
            return null;
        }

        public void SelectComputeEngineBtn()
        {
            if(IsElementLoaded(computeEngineBtnLocator))
                driver.FindElement(computeEngineBtnLocator).Click();
        }
        
        public void SelectNumOfInstances(int num = 4)
        {
            if(IsElementLoaded(numOfInstancesLocator))
            {
                var elem = driver.FindElement(numOfInstancesLocator);
                elem.Clear();
                elem.SendKeys(num.ToString());
            }
        }
        
        public void SelectOperatingSystem()
        {
            if(IsElementLoaded(numOfInstancesLocator))
            {
                var elem = driver.FindElement(operatingSystemLocator);
                elem.Click();

                var selectedElem = driver.FindElement(operatingSystemChoiceLocator);
                selectedElem.Click();
            }
        }

        public void SelectProvisioning()
        {
            if(IsElementLoaded(numOfInstancesLocator))
            {
                var elem = driver.FindElement(provisioningModelSelector);
                elem.Click();
            }
        }

        public void SelectMachineFamily()
        {
            if(IsElementLoaded(numOfInstancesLocator))
            {
                var elem = driver.FindElement(machineFamilyLocator);
                elem.Click();

                var selectedElem = driver.FindElement(machineFamilyChoiceLocator);
                selectedElem.Click();
            }
        }

        public void SelectMachineSeries()
        {
            if(IsElementLoaded(numOfInstancesLocator))
            {
                var elem = driver.FindElement(machineSeriesLocator);
                elem.Click();

                var selectedElem = driver.FindElement(machineSeriesChoiceLocator);
                selectedElem.Click();
            }
        }

        public void SelectMachineType()
        {
            if(IsElementLoaded(numOfInstancesLocator))
            {
                var elem = driver.FindElement(machineTypeLocator);
                elem.Click();

                var selectedElem = driver.FindElement(machineTypeChoiceLocator);
                selectedElem.Click();
            }
        }

        public void AddGPUs()
        {
            if(IsElementLoaded(numOfInstancesLocator))
            {
                var elem = driver.FindElement(addGPUsLocator);
                elem.Click();
            }
        }

        public void SetGPUModel()
        {
            if(IsElementLoaded(numOfInstancesLocator))
            {
                var elem = driver.FindElement(gpuModelLocator);
                elem.Click();

                var selectedElem = driver.FindElement(gpuModelChoiceLocator);
                selectedElem.Click();
            }
        }

        public void SetNumOfGPUs()
        {
            if(IsElementLoaded(numOfInstancesLocator))
            {
                var elem = driver.FindElement(numberOfGPUsLocator);
                elem.Click();

                var selectedElem = driver.FindElement(numberOfGPUsChoiceLocator);
                selectedElem.Click();
            }
        }

        public void SetTypeOfSSD()
        {
            if(IsElementLoaded(numOfInstancesLocator))
            {
                var elem = driver.FindElement(localSSDTypeLocator);
                elem.Click();

                var selectedElem = driver.FindElement(localSSDTypeChoiceLocator);
                selectedElem.Click();
            }
        }

        public void SetLocation()
        {
            if(IsElementLoaded(numOfInstancesLocator))
            {
                var elem = driver.FindElement(regionTypeLocator);
                elem.Click();

                var selectedElem = driver.FindElement(regionTypeChoiceLocator);
                selectedElem.Click();
            }
        }

        public void ShareEstimate()
        {
            if(IsElementLoaded(numOfInstancesLocator))
            {
                var elem = driver.FindElement(openShareBtnLocator);
                elem.Click();
            }
        }

        public void OpenEstimate()
        {
            if(IsElementLoaded(openShareLink))
            {
                var elem = driver.FindElement(openShareLink);
                elem.Click();
            }
        }

        public void Verify()
        {
            IList<string> windowHandles = new List<string>(driver.WindowHandles);
            driver.SwitchTo().Window(windowHandles[1]);

            if(IsElementLoaded(machineTypeResultLocator.Value, 6000))
            {
                var elem = driver.FindElement(machineTypeResultLocator.Value);
                Assert.That(elem.FindElement(By.XPath("following-sibling::span")).Text, Does.Contain("n1-standard-8, vCPUs: 8, RAM: 30 GB"));

                elem = driver.FindElement(gpuModelResultLocator.Value);
                Assert.That(elem.FindElement(By.XPath("following-sibling::span")).Text, Does.Contain("NVIDIA V100"));

                elem = driver.FindElement(numOfGPUsResultLocator.Value);
                Assert.That(elem.FindElement(By.XPath("following-sibling::span")).Text, Does.Contain("1"));

                elem = driver.FindElement(numOfInstancesResultLocator.Value);
                Assert.That(elem.FindElement(By.XPath("following-sibling::span")).Text, Does.Contain("4"));

                elem = driver.FindElement(localSSDsResultLocator.Value);
                Assert.That(elem.FindElement(By.XPath("following-sibling::span")).Text, Does.Contain("2x375 GB"));

                elem = driver.FindElement(osTypeResultLocator.Value);
                Assert.That(elem.FindElement(By.XPath("following-sibling::span")).Text, Does.Contain("Free: Debian, CentOS, CoreOS, Ubuntu or BYOL (Bring Your Own License)"));

                elem = driver.FindElement(provisioningModelResultLocator.Value);
                Assert.That(elem.FindElement(By.XPath("following-sibling::span")).Text, Does.Contain("Regular"));

                elem = driver.FindElement(addGPUsResultLocator.Value);
                Assert.That(elem.FindElement(By.XPath("following-sibling::span")).Text, Does.Contain("true"));
            }
        }

        // public void SelectSyntaxHighlighting(string type)
        // {
        //     driver.FindElement(highlightingTypeDropdownLocator).Click();
        //     var elements = driver.FindElement(highlightingTypeOptionLocator.Value);

        //     foreach(var child in elements.FindElements(syntaxHighlightingLocator.Value))
        //     {
        //         if(child.Text.Contains(type, StringComparison.CurrentCultureIgnoreCase))
        //         {
        //             child.Click();
        //             break;
        //         }
        //     }
        // }

        // public void SelectPasteExpiration(string expiration)
        // {
        //     driver.FindElement(pasteExpirationDropdownLocator).Click();
        //     var elements = driver.FindElement(pasteExpirationOptionLocator.Value);

        //     foreach(var child in elements.FindElements(pasteExpirationElementLocator.Value))
        //     {
        //         //TestContext.Out.WriteLine($"Child Text: {child.Text}");
        //         if(child.Text.Contains(expiration, StringComparison.CurrentCultureIgnoreCase))
        //         {
        //             child.Click();
        //             break;
        //         }
        //     }
        // }

        // public void EnterPasteName(string pasteName)
        // {
        //     driver.FindElement(pasteNameTextBoxLocator).SendKeys(pasteName);
        // }

        // public void ClickCreateNewPaste()
        // {
        //     driver.FindElement(createNewPasteButtonLocator).Click();
        // }
    }
}