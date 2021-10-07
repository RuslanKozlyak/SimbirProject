using AutoMapper;
using Domain.DTO.HumanDtos;
using Domain.RepositoryInterfaces;
using FluentAssertions;
using Moq;
using Service;
using Service.Mapping;
using System.Linq;
using Xunit;

namespace WebApiTests.Servieces
{
    [Collection("DatabaseCollection")]
    public class HumanServiceTests
    {
        private IMapper _mapper;
        private Mock<IHumanRepository> mock;
        private HumanService service;
        private DatabaseFixture _database;

        public HumanServiceTests(DatabaseFixture fixture)
        {
            if (_mapper == null)
            {
                _database = fixture;
                var context = _database.CreateContext();

                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new AuthorMap());
                    mc.AddProfile(new BookMap());
                    mc.AddProfile(new GenreMap());
                    mc.AddProfile(new HumanMap());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;

                mock = new Mock<IHumanRepository>();
                service = new HumanService(mock.Object, _mapper);

                mock.Setup(repo => repo.GetHuman(1))
                                    .Returns(_database.humanEntity.First);

                mock.Setup(repo => repo.GetAllHumans())
                                    .Returns(_database.humanEntity);
            }
        }

        [Fact]
        public void GetHuman_WithExistHuman_ShouldReturn_HumanWithoutBooksDto()
        {
            //Arrange 
            var human = _database.humanEntity.First();
            var expected = _mapper.Map<HumanWithoutBooksDto>(human);

            //Act
            var actual = service.GetHuman(1);

            //Assert
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void GetAllHumans_WithExistHuman_ShouldReturn_HumanWithoutBooksDto()
        {
            //Arrange 
            var human = _database.humanEntity;
            var expected = _mapper.ProjectTo<HumanWithoutBooksDto>(human);

            //Act
            var actual = service.GetAllHumans();

            //Assert
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void GetHumanByQuery_WithExistHuman_ShouldReturn_HumanWithoutBooksDto()
        {
            //Arrange 
            var human = _database.humanEntity;
            var expected = _mapper.ProjectTo<HumanWithoutBooksDto>(human);

            //Act
            var actual = service.GetHumanByQuery("Иван");

            //Assert
            actual.Should().BeEquivalentTo(expected);
        }
    }
}
