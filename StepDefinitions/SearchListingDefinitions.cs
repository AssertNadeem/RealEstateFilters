using NUnit.Framework;
using RealEstateFilters.Drivers;
using RealEstateFilters.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateFilters.StepDefinitions
{
    [Binding]
    public class SearchListingDefinitions
    {
        private readonly Driver _driver;
        private readonly HomePageObjects _homePageObjects;

        public SearchListingDefinitions(Driver driver)
        {
            _driver = driver;
            _homePageObjects = new HomePageObjects(_driver.Page);
        }


        [Given(@"the barfoot and thompson website is launched")]
        public async Task GivenTheBarfootAndThompsonWebsiteIsLaunched()
        {
            await _driver.Page.GotoAsync("https://www.barfoot.co.nz/");

            var isExist = await _homePageObjects.IsHeaderDetailsExists();
            Assert.IsTrue(isExist);            

        }

        [Given(@"search listings using ""([^""]*)""")]
        public async Task GivenSearchListingsUsing(string sName)
        {
           await _homePageObjects.FilterBysuburb(sName);
        }

        [When(@"the bedroom and bathroom filters are applied")]
        public async Task WhenTheBedroomAndBathroomFiltersAreApplied()
        {
            await _homePageObjects.FilterByProperty();
        }

        [Then(@"the result should show the results")]
        public async Task ThenTheResultShouldShowTheResults()
        {
            
            var isExist1 = await _homePageObjects.IsHeaderSearchDetailsExists();
            Assert.IsTrue(isExist1);
            
        }

        [Then(@"the property can be viewed")]
        public async Task ThenThePropertyCanBeViewed()
        {
            await _homePageObjects.SearchByProperty();
            /* var isExist2 = await _homePageObjects.IsHeaderPropertySearchDetailsExists();
            Assert.IsTrue(isExist2); */
            
        }

        //Scenario 2
        [When(@"the price property and land area filters are applied")]
        public async Task WhenThePricePropertyAndLandAreaFiltersAreApplied()
        {
            await _homePageObjects.FilterByPriceAndLand();
        }

        [Then(@"the filter should show appropriate results")]
        public async Task ThenTheFilterShouldShowAppropriateResults()
        {
            
            var isExist3 = await _homePageObjects.IsPropertySearchDetailsExists();
            Assert.IsTrue(isExist3);
        }


    }
}
