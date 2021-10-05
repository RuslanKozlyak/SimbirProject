using AutoMapper;
using Domain.Data;
using Domain.DTO.AuthorDtos;
using Domain.DTO.BookDtos;
using Domain.DTO.GenreDtos;
using Domain.DTO.HumanDtos;
using Domain.RepositoryInterfaces;
using Moq;
using Service;
using Service.Mapping;
using System.Collections.Generic;
using Xunit;

namespace WebApiTests.Servieces
{
    public class HumanServiceTests
    {
        private static IMapper _mapper;

        public HumanServiceTests()
        {
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new AuthorMap());
                    mc.AddProfile(new BookMap());
                    mc.AddProfile(new GenreMap());
                    mc.AddProfile(new HumanMap());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }
        }

        [Fact]
        public void GetHuman_WithExistHuman_ShouldReturn_HumanWithoutBooksDto()
        {
            var mock = new Mock<IRepository<Human>>();
            var service = new HumanService(mock.Object, _mapper);
            var human = new Human
            {
                Id = 1,
                FirstName = "Руслан",
                LastName = "Козляк",
                MiddleName = "Владимирович",
                Birthday = "14.08.2001",
                Books = new List<Book>()
            };
            mock.Setup(repo => repo.Get(1)).Returns(human);
            var expected = new HumanWithoutBooksDto
            {
                FirstName = "Руслан",
                LastName = "Козляк",
                MiddleName = "Владимирович",
                Birthday = "14.08.2001",
            };

            var actual = service.GetHuman(1);

            Assert.Equal(expected.FirstName, actual.FirstName);
            Assert.Equal(expected.LastName, actual.LastName);
            Assert.Equal(expected.MiddleName, actual.MiddleName);
            Assert.Equal(expected.Birthday, actual.Birthday);
        }

        [Fact]
        public void GetAllHumans_WithExistHuman_ShouldReturn_HumanWithoutBooksDto()
        {
            var mock = new Mock<IRepository<Human>>();
            var service = new HumanService(mock.Object, _mapper);
            var human = new Human
            {
                Id = 1,
                FirstName = "Руслан",
                LastName = "Козляк",
                MiddleName = "Владимирович",
                Birthday = "14.08.2001",
                Books = new List<Book>()
            };
            var humans = new List<Human>();
            humans.Add(human);
            mock.Setup(repo => repo.GetAll()).Returns(humans);
            var expected = new HumanWithoutBooksDto
            {
                FirstName = "Руслан",
                LastName = "Козляк",
                MiddleName = "Владимирович",
                Birthday = "14.08.2001",
            };

            var actualBooks = service.GetAllHumans();
            var actual = new List<HumanWithoutBooksDto>();
            foreach (var a in actualBooks)
                actual.Add(a);

            Assert.Equal(expected.FirstName, actual[0].FirstName);
            Assert.Equal(expected.LastName, actual[0].LastName);
            Assert.Equal(expected.MiddleName, actual[0].MiddleName);
            Assert.Equal(expected.Birthday, actual[0].Birthday);
        }

        [Fact]
        public void GetHumanByQuery_WithExistHuman_ShouldReturn_HumanWithoutBooksDto()
        {
            var mock = new Mock<IRepository<Human>>();
            var service = new HumanService(mock.Object, _mapper);
            var human = new Human
            {
                Id = 1,
                FirstName = "Руслан",
                LastName = "Козляк",
                MiddleName = "Владимирович",
                Birthday = "14.08.2001",
                Books = new List<Book>()
            };
            var humans = new List<Human>();
            humans.Add(human);
            mock.Setup(repo => repo.GetAll()).Returns(humans);
            var expected = new HumanWithoutBooksDto
            {
                FirstName = "Руслан",
                LastName = "Козляк",
                MiddleName = "Владимирович",
                Birthday = "14.08.2001",
            };

            var actualBooks = service.GetHumanByQuery("Руслан");
            var actual = new List<HumanWithoutBooksDto>();
            foreach (var a in actualBooks)
                actual.Add(a);

            Assert.Equal(expected.FirstName, actual[0].FirstName);
            Assert.Equal(expected.LastName, actual[0].LastName);
            Assert.Equal(expected.MiddleName, actual[0].MiddleName);
            Assert.Equal(expected.Birthday, actual[0].Birthday);
        }
    }
}
