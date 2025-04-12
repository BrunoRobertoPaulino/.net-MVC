using MVC.Forms;
using PuppeteerSharp;

namespace MVC.Services
{
    public class ContatoService
    {

        public async Task PuppeterTest(ContatoForm obj)
        {  

            var browserFetcher = new BrowserFetcher();
            await browserFetcher.DownloadAsync();

            var browser = await Puppeteer.LaunchAsync(new LaunchOptions
            {
                Headless = true
            });

            await Event(browser, obj);
        }

        public string CreateDirectory()
        {
            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "screenshots");

            Directory.CreateDirectory(folderPath);

            return Path.Combine(folderPath, "screenshot.png");
        }

        public async Task Event(IBrowser browser, ContatoForm obj)
        {
            var page = await browser.NewPageAsync();
            await page.GoToAsync("https://github.com/login");
            await page.WaitForSelectorAsync("#login_field");
            await page.TypeAsync("#login_field", obj.Email);
            await page.TypeAsync("#password", obj.Senha);


            await Task.WhenAll
                (
                page.ClickAsync(".btn-primary"),
                page.WaitForSelectorAsync(".AppHeader-context-item-label")
               );

            await page.ScreenshotAsync(CreateDirectory());
            await page.CloseAsync();
        }
    }
}
