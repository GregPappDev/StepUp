using AutoMapper;
using Microsoft.Identity.Client;
using NSubstitute;
using StepUpApi.Data;
using StepUpApi.Services;

namespace StepUpApi.Tests
{
    public class AppointmentTests
    {
        private readonly AppointmentService _sut;
        private readonly ApiDbContext _context = Substitute.For<ApiDbContext>();
        private readonly IMapper _mapper = Substitute.For<IMapper>();

        public AppointmentTests()
        {
            _sut = new AppointmentService(_context, _mapper);
        }

        [Fact]
        public void Test1()
        {
            // Arrange

            // Act

            // Assert

        }
    }
}