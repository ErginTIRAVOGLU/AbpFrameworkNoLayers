using BookStore.Interfaces.Authors;
using BookStore.Services.Authors;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;

namespace BookStore
{
    public class BookStoreDataSeederContributor : IDataSeedContributor, ITransientDependency
    {
        public AuthorManager _authorManager { get; }
        public IAuthorRepository _authorRepository { get; }

        public BookStoreDataSeederContributor(IAuthorRepository authorRepository,
            AuthorManager authorManager)
        {
            _authorRepository = authorRepository;
            _authorManager = authorManager;
            
        }



        public async Task SeedAsync(DataSeedContext context)
        {
            if(await _authorRepository.GetCountAsync() >0)
            {
                return;
            }

            var orwell = await _authorRepository.InsertAsync(
                await _authorManager.CreateAsync(
                    "George Orwell",
                    new DateTime(1903, 06, 25),
                    "Orwell produced literary criticism and poetry, fiction and polemical journalism"
                    )
                );

            var douglas = await _authorRepository.InsertAsync(
                await _authorManager.CreateAsync(
                    "Douglas Adams",
                    new DateTime(1952, 03, 11),
                    "Douglas Adams as an English author, scriptwriter, essayist, humorist, satirist and dramatist."
                    )
                );
        }
    }
}
