using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace RealEstateFilters.Pages
{

    

    public class HomePageObjects
    {
        private readonly ILocator _txtHeader;
        private readonly ILocator _txtSearchHeader;
        private readonly ILocator _txtPropertySearchHeader;
        private readonly ILocator _txtPriceSearchHeader;
        private readonly IPage _page;


        public HomePageObjects(IPage page)
        {
            _page = page;
            _txtHeader = _page.Locator("text=Home is where");
            _txtSearchHeader = _page.Locator("text=3 Bedroom Houses For Sale In Blockhouse Bay");
            _txtPropertySearchHeader = _page.Locator("text=41 Dundale Avenue, Blockhouse Bay");
            _txtPriceSearchHeader = _page.Locator("text=Showing");
        }

        //Methods
        public async Task<bool> IsHeaderDetailsExists()
        {
            return await _txtHeader.IsVisibleAsync();
        }



        //Function to select suburb
        public async Task FilterBysuburb(string sName)
        {
            Console.WriteLine("suburb provided : " + sName);
            await _page.GetByPlaceholder("Suburb, address or person", new() { Exact = true }).ClickAsync();
            await _page.GetByPlaceholder("Suburb, address or person", new() { Exact = true }).FillAsync(sName);
            await _page.Locator("//*[@id=\"results\"]/div[1]/bt-autocomplete-suburb-result/div/div[2]/div[1]").ClickAsync();
            
        }

        //Function to select bedrooms and bathroom filters
        public async Task FilterByProperty()
        {
            //Select the Filter, House, bedrooms and bathrooms.
            await _page.GetByText("Filters", new() { Exact = true }).ClickAsync();
            await _page.Locator("bt-residential-property-types").GetByText("House", new() { Exact = true }).ClickAsync();
            await _page.Locator("bt-bedroom-filter").GetByText("3").ClickAsync();
            await _page.Locator("bt-bathroom-filter").GetByText("1").ClickAsync();
            await _page.Locator("a").Filter(new() { HasTextRegex = new Regex("^Search$") }).ClickAsync();
        }

        //Search landing page title
        public async Task<bool> IsHeaderSearchDetailsExists()
        {
            return await _txtSearchHeader.IsVisibleAsync();
        }

        //Searching through the property
        public async Task SearchByProperty()
        {
            //Select the house and check the pictures.
            
            await _page.Locator("//*[@id=\"854317\"]/div[1]/img").HoverAsync();
            await _page.Locator("#control-right-854317 span").ClickAsync();
            await _page.Locator("#control-right-854317 span").ClickAsync();
            await _page.Locator("#control-right-854317 span").ClickAsync();
            await _page.Locator("#control-right-854317 span").ClickAsync();
            await _page.GetByRole(AriaRole.Link, new() { Name = "41 Dundale Avenue, Blockhouse Bay" }).ClickAsync();
            
        }

        //Search landing page title of the search
        public async Task<bool> IsHeaderPropertySearchDetailsExists()
        {
            return await _txtPropertySearchHeader.IsVisibleAsync();
        }

        //Second scenario
        //Function to select bedrooms and bathroom filters
        public async Task FilterByPriceAndLand()
        {
            //Select the Filter, House, bedrooms and bathrooms.
            await _page.GetByText("Filters", new() { Exact = true }).ClickAsync();

            //select the price.
            await _page.Locator("span:nth-child(4) > .rz-bar").First.ClickAsync();
            await _page.GetByRole(AriaRole.Slider).Nth(1).ClickAsync();

            //select the property types
            await _page.Locator("bt-residential-property-types").GetByText("House", new() { Exact = true }).ClickAsync();
            await _page.Locator("bt-residential-property-types").GetByText("Section").ClickAsync();
            await _page.Locator("bt-residential-property-types").GetByText("Apartment").ClickAsync();
            await _page.Locator("bt-residential-property-types").GetByText("Townhouse").ClickAsync();
            await _page.GetByText("Lifestyle", new() { Exact = true }).ClickAsync();

            //Bedrooms and Bathrooms
            await _page.Locator("bt-bedroom-filter").GetByText("4").ClickAsync();
            await _page.Locator("bt-bathroom-filter").GetByText("2").ClickAsync();

            //Select land
            await _page.Locator("bt-land-area-slider > bt-range-slider > .range-slider > .search-filter-slider > span:nth-child(4) > .rz-bar").ClickAsync();
            await _page.GetByRole(AriaRole.Slider).Nth(3).ClickAsync();

            //Press the search button
            await _page.Locator("a").Filter(new() { HasTextRegex = new Regex("^Search$") }).ClickAsync();

        }

        //Search landing page title of the search by price, land
        public async Task<bool> IsPropertySearchDetailsExists()
        {
            return await _txtPriceSearchHeader.IsVisibleAsync();
        }
    }
}
