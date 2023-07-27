using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BrainstormSessions.Api;
using BrainstormSessions.Controllers;
using BrainstormSessions.Core.Interfaces;
using BrainstormSessions.Core.Model;
using log4net.Appender;
using log4net.Config;
using Moq;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.Email;
using Serilog.Sinks.InMemory;
using Xunit;

namespace BrainstormSessions.Test.UnitTests
{
    public class LoggingTests : IDisposable
    {
        private readonly MemoryAppender _appender;
        public List<string> selfLogMessages = new List<string>();

        public LoggingTests()
        {
            var emailInfo = new EmailConnectionInfo
            {
                EmailSubject = "Serilog Email Bug",
                EnableSsl = true,
                Port = 465,
                FromEmail = "test12076133@gmail.com",
                MailServer = "smtp.gmail.com",
                ToEmail = "nikolayoliver815@gmail.com",

                // Use app password, check Port and SSL
                NetworkCredentials = new NetworkCredential("test12076133@gmail.com", "ofatoleojxomjjtf")
            };

            Log.Logger = new LoggerConfiguration()
               .WriteTo.File("C:\\Users\\Mikalai_Karaliou\\Work\\MentoringDevelopment\\MentoringDev\\Task9_Version2\\log.txt")
               .WriteTo.Console()
               .WriteTo.InMemory()
               .WriteTo.Email(emailInfo)
               .MinimumLevel.Verbose()
               .CreateLogger();

            _appender = new MemoryAppender();
            BasicConfigurator.Configure(_appender);

            var file = File.CreateText("C:\\Users\\Mikalai_Karaliou\\Work\\MentoringDevelopment\\MentoringDev\\Task9_Version2\\SelfLogs.txt");
            Serilog.Debugging.SelfLog.Enable(TextWriter.Synchronized(file));
        }

        public void Dispose()
        {
            // Использовать это, для того, чтобы Логи точно можно было получить по Email.
            // При запуске тестов программа отрабатывает быстрее, чем логгер успеать записать логи ( в файл из Serilog и через Email)
            Log.CloseAndFlush();
            _appender.Clear();
        }

        [Fact]
        public async Task HomeController_Index_LogInfoMessages()
        {
            // Arrange
            var mockRepo = new Mock<IBrainstormSessionRepository>();
            mockRepo.Setup(repo => repo.ListAsync())
                .ReturnsAsync(GetTestSessions());
            var controller = new HomeController(mockRepo.Object);

            // Act
            var result = await controller.Index();

            // Assert
            Assert.True(InMemorySink.Instance.LogEvents.Any(l => l.Level == LogEventLevel.Information), "Expected Info messages in the logs");
        }

        [Fact]
        public async Task HomeController_IndexPost_LogWarningMessage_WhenModelStateIsInvalid()
        {
            // Arrange
            var mockRepo = new Mock<IBrainstormSessionRepository>();
            mockRepo.Setup(repo => repo.ListAsync())
                .ReturnsAsync(GetTestSessions());
            var controller = new HomeController(mockRepo.Object);
            controller.ModelState.AddModelError("SessionName", "Required");
            var newSession = new HomeController.NewSessionModel();

            // Act
            var result = await controller.Index(newSession);

            // Assert
            var logEntries = _appender.GetEvents();
            Assert.True(InMemorySink.Instance.LogEvents.Any(l => l.Level == LogEventLevel.Warning), "Expected Warn messages in the logs");
        }

        [Fact]
        public async Task IdeasController_CreateActionResult_LogErrorMessage_WhenModelStateIsInvalid()
        {
            // Arrange & Act
            var mockRepo = new Mock<IBrainstormSessionRepository>();
            var controller = new IdeasController(mockRepo.Object);
            controller.ModelState.AddModelError("error", "some error");

            // Act
            var result = await controller.CreateActionResult(model: null);

            // Assert
            var logEntries = _appender.GetEvents();
            Assert.True(InMemorySink.Instance.LogEvents.Any(l => l.Level == LogEventLevel.Error), "Expected Error messages in the logs");
        }

        [Fact]
        public async Task SessionController_Index_LogDebugMessages()
        {
            // Arrange
            int testSessionId = 1;
            var mockRepo = new Mock<IBrainstormSessionRepository>();
            mockRepo.Setup(repo => repo.GetByIdAsync(testSessionId))
                .ReturnsAsync(GetTestSessions().FirstOrDefault(
                    s => s.Id == testSessionId));
            var controller = new SessionController(mockRepo.Object);

            // Act
            var result = await controller.Index(testSessionId);

            // Assert
            var logEntries = _appender.GetEvents();
            Assert.True(InMemorySink.Instance.LogEvents.Count(l => l.Level == LogEventLevel.Debug) == 2, "Expected 2 Debug messages in the logs");
        }

        private List<BrainstormSession> GetTestSessions()
        {
            var sessions = new List<BrainstormSession>();
            sessions.Add(new BrainstormSession()
            {
                DateCreated = new DateTime(2016, 7, 2),
                Id = 1,
                Name = "Test One"
            });
            sessions.Add(new BrainstormSession()
            {
                DateCreated = new DateTime(2016, 7, 1),
                Id = 2,
                Name = "Test Two"
            });
            return sessions;
        }

    }
}
