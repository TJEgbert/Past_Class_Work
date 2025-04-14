using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RSPGApplication.Data;
using RSPGApplication.Models;
using RSPGApplication.Pages.RSPGFormRelated;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace UnitTestsProject
{
    [TestClass]
    public class RSPGSummaryFinalReportModelTests
    {
        // Creates a fresh in-memory EF Core context for isolation between tests
        private RSPGApplicationContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<RSPGApplicationContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            return new RSPGApplicationContext(options);
        }

        [TestMethod]
        public void OnGet_ShouldRedirectToLogin_WhenUserNotLoggedIn()
        {
            // Arrange
            var dbContext = GetInMemoryDbContext();
            var logger = new LoggerFactory().CreateLogger<RSPGSummaryFinalReportModel>();
            var model = new RSPGSummaryFinalReportModel(dbContext, logger);

            // Simulate empty session (no _UserID)
            var httpContext = new DefaultHttpContext();
            httpContext.Features.Set<ISessionFeature>(new SessionFeature { Session = new FakeSession() });
            model.PageContext = new PageContext { HttpContext = httpContext };

            // Act
            var result = model.OnGet();

            // Assert: user should be redirected to the login page
            Assert.IsInstanceOfType(result, typeof(RedirectToPageResult));
            var redirect = result as RedirectToPageResult;
            Assert.AreEqual("/UserRelated/Login", redirect?.PageName);
        }

        [TestMethod]
        public async Task OnPostAsync_ShouldReturnPage_WhenModelStateIsInvalid()
        {
            // Arrange
            var dbContext = GetInMemoryDbContext();
            var logger = new LoggerFactory().CreateLogger<RSPGSummaryFinalReportModel>();
            var model = new RSPGSummaryFinalReportModel(dbContext, logger);

            // Simulate a logged-in user by setting session
            var context = new DefaultHttpContext();
            var session = new FakeSession();
            session.SetInt32("_UserID", 1);
            context.Features.Set<ISessionFeature>(new SessionFeature { Session = session });
            model.PageContext = new PageContext { HttpContext = context };

            // Simulate model binding failure (e.g., Email is missing)
            model.ModelState.AddModelError("Email", "Required");

            // Act
            var result = await model.OnPostAsync();

            // Assert: should return the same page (not redirect) due to validation error
            Assert.IsInstanceOfType(result, typeof(PageResult));
        }

        // Helper class to fake session support in unit tests
        private class SessionFeature : ISessionFeature
        {
            public ISession Session { get; set; }
        }

        // Minimal fake session implementation for testing session access
        private class FakeSession : ISession
        {
            private readonly Dictionary<string, byte[]> _sessionStorage = new();

            public bool IsAvailable => true;
            public string Id => "FakeSessionId";
            public IEnumerable<string> Keys => _sessionStorage.Keys;

            public void Clear() => _sessionStorage.Clear();
            public Task CommitAsync(CancellationToken cancellationToken = default) => Task.CompletedTask;
            public Task LoadAsync(CancellationToken cancellationToken = default) => Task.CompletedTask;
            public void Remove(string key) => _sessionStorage.Remove(key);
            public void Set(string key, byte[] value) => _sessionStorage[key] = value;
            public bool TryGetValue(string key, out byte[] value) => _sessionStorage.TryGetValue(key, out value);

            // Helper for setting int session values
            public void SetInt32(string key, int value) => Set(key, BitConverter.GetBytes(value));
            public int? GetInt32(string key) =>
                _sessionStorage.TryGetValue(key, out var value) ? BitConverter.ToInt32(value, 0) : (int?)null;
        }
    }
}
