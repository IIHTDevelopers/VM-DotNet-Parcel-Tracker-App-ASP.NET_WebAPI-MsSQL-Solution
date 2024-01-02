using ParcelTrackerApp.DAL.Interrfaces;
using ParcelTrackerApp.DAL.Services;
using ParcelTrackerApp.DAL.Services.Repository;
using ParcelTrackerApp.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace ParcelTrackerApp.Tests.TestCases
{
    public class ExceptionalTests
    {
        private readonly ITestOutputHelper _output;
        private readonly IParcelTrackerService _ParcelService;
        public readonly Mock<IParcelTrackerRepository> Parcelservice = new Mock<IParcelTrackerRepository>();

        private readonly Parcel _Parcel;

        private static string type = "Exception";

        public ExceptionalTests(ITestOutputHelper output)
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
        public async Task<bool> Testfor_Validate_ifInvalidParcelIdIsPassed()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                Parcelservice.Setup(repo => repo.CreateParcel(_Parcel)).ReturnsAsync(_Parcel);
                var result = await _ParcelService.CreateParcel(_Parcel);
                if (result != null || result.Id != 0)
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
        public async Task<bool> Testfor_Status_NotEmpty()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                Parcelservice.Setup(repo => repo.CreateParcel(_Parcel)).ReturnsAsync(_Parcel);
                var result = await _ParcelService.CreateParcel(_Parcel);
                var actualLength = _Parcel.Status.ToString().Length;
                if (result.Status.ToString().Length == actualLength)
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