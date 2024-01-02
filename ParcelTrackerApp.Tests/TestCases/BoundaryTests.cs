
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
    public class BoundaryTests
    {
        private readonly ITestOutputHelper _output;
        private readonly IParcelTrackerService _ParcelService;
        public readonly Mock<IParcelTrackerRepository> Parcelservice = new Mock<IParcelTrackerRepository>();

        private readonly Parcel _Parcel;

        private static string type = "Boundary";

        public BoundaryTests(ITestOutputHelper output)
        {
            _ParcelService = new ParcelTrackerService(Parcelservice.Object);

            _output = output;

            _Parcel = new Parcel
            {
                Id= 1,
                TrackingNumber="1234",
                Destination="Mumbai",
                LastUpdated= DateTime.Now,
                Status="Pending"
            };
        }

        [Fact]
        public async Task<bool> Testfor_TrackingNumber_NotEmpty()
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
                var actualLength = _Parcel.TrackingNumber.ToString().Length;
                if (result.TrackingNumber.ToString().Length == actualLength)
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
        public async Task<bool> Testfor_ParcelId_NotEmpty()
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
                var actualLength = _Parcel.Id.ToString().Length;
                if (result.Id.ToString().Length == actualLength)
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
        public async Task<bool> Testfor_ParcelDate_NotEmpty()
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
                var actualLength = _Parcel.LastUpdated.ToString().Length;
                if (result.LastUpdated.ToString().Length == actualLength)
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
        public async Task<bool> Testfor_Destination_NotEmpty()
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
                var actualLength = _Parcel.Destination.ToString().Length;
                if (result.Destination.ToString().Length == actualLength)
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