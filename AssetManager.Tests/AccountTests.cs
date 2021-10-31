
using System;
using System.Linq;
using AssetManager.Data;
using AssetManager.Data.Repositories;
using AssetManager.Data.RepositoriesInterface;
using AssetManager.Models.Accounting;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace AssetManager.Tests {

    public class AccountRepositoryTests : IDisposable {

        private readonly AssetManagerDbContext _context;
        private readonly IAccountRepository _accountRepository;

        public AccountRepositoryTests() {
            var connection = new SqliteConnection("Filename=:memory:");

            connection.Open();

            var options = new DbContextOptionsBuilder<AssetManagerDbContext>()
                .UseSqlite(connection)
                .Options;
            
            _context = new AssetManagerDbContext(options);
            _context.Database.EnsureCreated();
            _accountRepository = new AccountRepository(_context);
        }

        public void Dispose() {
            _context.Dispose();
        }

        [Fact]
        public void ShouldAddAccount() {

            var account = new Account {
                Name = "Test",
                Code = "1001",
                Type = AccountType.Asset,
            };
            _accountRepository.Create(account);
            _accountRepository.Commit();
            var results = _accountRepository.GetQuerySet().Where(acc => acc.Code == "1001");
            Assert.True(results.Count() == 1);
        }

        [Fact]
        public void ShouldNotAllowAccountsWithSameCode() {

            var account1 = new Account {
                Name = "Test",
                Code = "1001",
                Type = AccountType.Asset,
            };

            var account2 = new Account {
                Name = "Test2",
                Code = "1001",
                Type = AccountType.Asset,
            };

            _accountRepository.Create(account1);
            _accountRepository.Create(account2);
            _accountRepository.Commit();
            var results = _accountRepository.GetQuerySet().Where(acc => acc.Code == "1001");
            Console.WriteLine(results.Count());
        }
    }
}