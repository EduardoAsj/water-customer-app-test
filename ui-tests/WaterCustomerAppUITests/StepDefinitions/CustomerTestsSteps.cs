using System.Threading.Tasks;
using Microsoft.Playwright;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace WaterCustomerAppUITests.StepDefinitions
{
    [Binding]
    public class CustomerSizeCategorizationSteps
    {
        private IPlaywright _playwright;
        private IBrowser _browser;
        private IBrowserContext _context;
        private IPage _page;

        [BeforeScenario]
        public async Task Setup()
        {
            _playwright = await Playwright.CreateAsync();
            _browser = await _playwright.Chromium.LaunchAsync(
                new BrowserTypeLaunchOptions { Headless = false }
            );
            _context = await _browser.NewContextAsync();
            _page = await _context.NewPageAsync();
        }

        [AfterScenario]
        public async Task Teardown()
        {
            await _browser.CloseAsync();
        }

        [Given(@"I am on the welcome screen")]
        public async Task WelcomeScreen()
        {
            await _page.GotoAsync("http://localhost:3000");
        }

        [When(@"I enter my name")]
        public async Task EnterName()
        {
            await _page.FillAsync("#name", "Eduardo Afonso");
        }

        [When(@"submit the form")]
        public async Task SubmitForm()
        {
            await _page.ClickAsync("input[value='Submit']");
        }

        [When(@"check the customer ""(.*)""")]
        public async Task CheckCustomer(string customerName)
        {
            var customerExists = await _page.IsVisibleAsync($"text={customerName}");
            Assert.IsTrue(
                customerExists,
                $"Customer '{customerName}' is not visible on the screen."
            );
        }

        [Then(@"I should see the size categorized correctly for ""(.*)"" with (.*) employees")]
        public async Task SizeCategorizedCorrectly(string customerName, int employeeCount)
        {
            string expectedSize = DetermineSizeCategory(employeeCount);

            // Locate the row for the specific customer
            var customerRow = _page.Locator($"//tr[td/a[text()=\"{customerName}\"]]");

            // Get the size text from the third column of the located row
            var sizeText = await customerRow.Locator("td:nth-child(3)").InnerTextAsync();

            Assert.AreEqual(
                expectedSize,
                sizeText,
                $"Size for customer '{customerName}' is not displayed correctly."
            );
        }

        [When(@"I click on the customer ""(.*)""")]
        public async Task ClickOnTheCustomer(string customerName)
        {
            await _page.ClickAsync($"text={customerName}");
        }

        // Unable to determine the exact selector for the message, so replace ".No contact info" with the actual selector when it is known
        [Then(@"I should see a message ""(.*)""")]
        public async Task MessageNoContactInfo(string expectedMessage)
        {
            var messageText = await _page.InnerTextAsync(
                ".No contact info",
                new PageInnerTextOptions { Timeout = 1000 }
            ); // Replace selector
            Assert.AreEqual(expectedMessage, messageText);
        }

        [Then(@"I should see the Contacts Detail Screen for ""(.*)""")]
        public async Task ContactsDetailScreen(string customerName)
        {
            var detailScreenVisible = await _page.IsVisibleAsync($"text={customerName}");
            Assert.IsTrue(
                detailScreenVisible,
                $"Contacts Detail Screen for '{customerName}' is not displayed."
            );
        }

        private string DetermineSizeCategory(int employeeCount)
        {
            if (employeeCount <= 2500)
                return "Small";
            else if (employeeCount <= 5000)
                return "Medium";
            else
                return "Big";
        }
    }
}
