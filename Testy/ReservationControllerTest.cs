using System.Collections.Generic;
using System.Threading.Tasks;
using Lab4_App_Reservation.Controllers;
using Lab4_App_Reservation.Models.ReservationModels;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Lab4_App_Reservation___UnitTests
{
    public class ReservationControllerTest
    {
        private ReservationController _controller;
        private Mock<IReservationService> _serviceMock;

        public ReservationControllerTest()
        {
            _serviceMock = new Mock<IReservationService>();
            _controller = new ReservationController(_serviceMock.Object);
        }


        [Fact]
        public async Task Create_ValidModel_RedirectsToIndex()
        {
            var validModel = new Reservation();

            var result = await _controller.Create(validModel);

            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);
        }

        [Fact]
        public async Task Update_ValidModel_RedirectsToIndex()
        {
            var validModel = new Reservation();

            var result = await _controller.Update(validModel);

            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);
        }

        [Fact]
        public async Task Delete_ValidModel_RedirectsToIndex()
        {
            var validModel = new Reservation { Id = 1 };

            var result = await _controller.Delete(validModel);

            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);

            _serviceMock.Verify(s => s.DeleteByIdAsync(validModel.Id), Times.Once);
        }

        [Fact]
        public async Task Details_ReturnsViewWithReservation()
        {
            var reservationId = 1;
            var reservation = new Reservation { Id = reservationId };
            _serviceMock.Setup(s => s.FindByIdAsync(reservationId)).ReturnsAsync(reservation);

            var result = await _controller.Details(reservationId);

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<Reservation>(viewResult.ViewData.Model);
            Assert.Equal(reservationId, model.Id);
        }
    }
}   
