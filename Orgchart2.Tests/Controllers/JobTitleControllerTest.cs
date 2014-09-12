using Moq;
using NUnit.Framework;
using Orgchart2.Controllers;
using Orgchart2.Infrastructure;
using Orgchart2.Models;

namespace Orgchart2.Tests.Controllers
{
    [TestFixture]
    class JobTitleControllerTest
    {
        private Mock<JobTitleRepository> _mockDb;
        private JobTitleController _systemUnderTest;

        [SetUp]
        public void Setup()
        {
            _mockDb = new Mock<JobTitleRepository>(new OrgChartDbContext());
            _systemUnderTest = new JobTitleController(_mockDb.Object);
        }

        [Test]
        public void TestControllerIndexAction()
        {
            var view = _systemUnderTest.Index();
            Assert.That(view, Is.Not.Null);
        }

        [Test]
        public void IndexActionSendsAllTitlesToView()
        {
            _mockDb.Setup(_ => _.SelectAll()).Verifiable();

            _systemUnderTest.Index();

            _mockDb.Verify(_ => _.SelectAll());
        }

        [Test]
        public void AddActionSendsTitleToRegistry()
        {
            _mockDb.Setup(_ => _.Add(It.IsAny<JobTitle>())).Verifiable();

            _systemUnderTest.Add(null);

            _mockDb.Verify(_ => _.Add(It.IsAny<JobTitle>()));
        }
    }
}
