using ParcelTrackerApp.DAL.Interrfaces;
using ParcelTrackerApp.DAL.Services;
using ParcelTrackerApp.DAL.Services.Repository;
using ParcelTrackerApp.Models;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace ParcelTrackerApp.Tests.TestCases
{
    public class FunctionalTests
    {
        private readonly ITestOutputHelper _output;
        private readonly IParcelTrackerService _ParcelService;
        public readonly Mock<IParcelTrackerRepository> Parcelservice = new Mock<IParcelTrackerRepository>();

        private readonly Parcel _Parcel;

        private static string type = "Functional";

        public FunctionalTests(ITestOutputHelper output)
        {
            _ParcelService = new ParcelTrackerService(Parcelservice.Object);
            _output = output;

            _Parcel = new Parcel
            {
                Id = 1,
                TrackingNumber = "1234",
                Destination = "Mumbai",
                LastUpdated = DateTime.Now,
                Status = "Pending"
            };
        }


        [Fact]
        public async Task<bool> Testfor_Create_Parcel()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                Parcelservice.Setup(repos => repos.CreateParcel(_Parcel)).ReturnsAsync(_Parcel);
                var result = await _ParcelService.CreateParcel(_Parcel);
                //Assertion
                if (result != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }


        [Fact]
        public async Task<bool> Testfor_Update_Parcel()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                Parcelservice.Setup(repos => repos.UpdateParcel(_Parcel)).ReturnsAsync(_Parcel);
                var result = await _ParcelService.UpdateParcel(_Parcel);
                if (result != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");

            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

        [Fact]
        public async Task<bool> Testfor_GetParcelById()
        {
            //Arrange
            var res = false;
            int id = 1;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                Parcelservice.Setup(repos => repos.GetParcelById(id)).ReturnsAsync(_Parcel);
                var result = await _ParcelService.GetParcelById(id);
                //Assertion
                if (result != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

        [Fact]
        public async Task<bool> Testfor_DeleteParcelById()
        {
            //Arrange
            var res = false;
            int id = 1;
            bool response = true;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                Parcelservice.Setup(repos => repos.DeleteParcelById(id)).ReturnsAsync(response);
                var result = await _ParcelService.DeleteParcelById(id);
                //Assertion
                if (result != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

    }
}