using OpenQA.Selenium;

namespace NetAutomation_WebDriverTask3;

using BrowserType = BrowserFactory.BrowserType;

[Parallelizable(scope: ParallelScope.Fixtures)]
[TestFixture("Chrome")]
[TestFixture("Firefox")]
[TestFixture("Edge")]
public class CreatePasteTest(string browserTypeString)
{
    private IWebDriver? driver;
    private HomePage? homePage;

    private readonly string browserTypeString = browserTypeString;

    [SetUp]
    public void SetUp()
    {
        var browserFactory = BrowserFactory.Instance;

        if (Enum.TryParse<BrowserType>(browserTypeString, true, out BrowserType browserType))
        {
            driver = browserFactory.GetDriver(browserType);
        }
        else
        {
            throw new ArgumentOutOfRangeException(nameof(browserTypeString), browserTypeString, null);
        }

        homePage = new HomePage(driver, "https://cloud.google.com/products/calculator");

        homePage.NavigateToPage();
    }

    [Test]
    public void CreateNewPaste()
    {
        homePage!.AddToEstimateBtn();
        homePage.SelectComputeEngineBtn();
        homePage.SelectNumOfInstances();
        homePage.SelectOperatingSystem();
        homePage.ScrollDown(600);
        homePage.SelectProvisioning();
        homePage.ScrollDown(100);
        homePage.SelectMachineSeries();
        homePage.SelectMachineFamily();
        homePage.SelectMachineType();
        homePage.ScrollDown(700);
        homePage.AddGPUs();
        homePage.ScrollDown(100);
        homePage.SetGPUModel();
        homePage.SetNumOfGPUs();
        homePage.SetTypeOfSSD();
        homePage.ScrollDown(200);
        homePage.SetLocation();
        homePage.ShareEstimate();
        homePage.OpenEstimate();
        homePage.Verify();
    }

    [TearDown]
    public void TearDown()
    {
        driver?.Dispose();
    }
}