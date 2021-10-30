using AutoMapper;
using Domain.DTO.HumanDtos;
using Domain.RepositoryInterfaces;
using FluentAssertions;
using Moq;
using Service;
using Service.Mapping;
using System.Linq;
using Xunit;

namespace WebApiTests.Services
{
    [Collection("DatabaseCollection")]
    public class HumanServiceTests
    {
        private readonly IMapper _mapper;
        private readonly HumanService service;
        private readonly DatabaseFixture _database;

        public HumanServiceTests(DatabaseFixture fixture)
        {
            _database = fixture;
            _database.CreateContext();

            _mapper = new Mapper(new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AuthorMap());
                mc.AddProfile(new BookMap());
                mc.AddProfile(new GenreMap());
                mc.AddProfile(new HumanMap());
            }));

            var mock = new Mock<IHumanRepository>();
            service = new HumanService(mock.Object, _mapper);

            mock.Setup(repo => repo.GetHuman(It.IsAny<int>()))
                                .Returns(_database.HumanEntity.First);

            mock.Setup(repo => repo.GetAllHumans())
                                .Returns(_database.HumanEntity);
        }

        [Fact]
        public void GetHuman_WithExistHuman_ShouldReturn_HumanWithoutBooksDto()
        {
            //Arrange 
            var human = _database.HumanEntity.First();
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
            var human = _database.HumanEntity;
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
            var human = _database.HumanEntity.Where(human => human.FirstName == "Иван");
            var expected = _mapper.ProjectTo<HumanWithoutBooksDto>(human);

            //Act
            var actual = service.GetHumanByQuery("Иван");

            //Assert
            actual.Should().BeEquivalentTo(expected);
        }
    }
}
