//using AutoMapper;
//using Domain.Data;
//using Domain.DTO.AuthorDtos;
//using Service.Mapping;
//using Xunit;

//namespace WebApiTests.RepositoryTest
//{
//    [Collection("DatabaseCollection")]
//    public class RepositoryTests
//    {
//        private DatabaseFixture _database;
//        private static IMapper _mapper;
//        public RepositoryTests(DatabaseFixture fixture)
//        {
//            _database = fixture;

//            if (_mapper == null)
//            {
//                var mappingConfig = new MapperConfiguration(mc =>
//                {
//                    mc.AddProfile(new AuthorMap());
//                    mc.AddProfile(new BookMap());
//                    mc.AddProfile(new GenreMap());
//                    mc.AddProfile(new HumanMap());
//                });
//                IMapper mapper = mappingConfig.CreateMapper();
//                _mapper = mapper;
//            }
//        }
//        [Fact]
//        public void GetAuthor_WithExistAuthor_ShouldReturn_AuthorWithoutBooksDto()
//        {
//            using var transaction = _database.Connection.BeginTransaction();
//            using var context = _database.CreateContext();
//            var repository = new Repository.GenericRepository<Author>(context);
//            var actual = repository.Get(1);

//            var expected = new AuthorWithoutBooksDto
//            {
//                FirstName = "Александр",
//                MiddleName = "Сергеевич",
//                LastName = "Пушкин"
//            };
//            Assert.Equal(expected.FirstName, actual.FirstName);
//        }
//    }
//}
