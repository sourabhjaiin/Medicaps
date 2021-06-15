
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using MediCaps.BusinessLogic;

namespace MediCaps.BusinessLogic.Test
{
    [TestFixture]
    public class MenuItemService_Should
    {
        private MenuItemService service;
        [OneTimeSetUp]
        public void Init()
        {
            service = new MenuItemService();
        }
        [OneTimeTearDown]
        public void Cleanup()
        {
            service.Dispose();
        }

        [Test]
        public void Return_All_MenuItems()
        {
            var items = service.GetAll();
            CollectionAssert.IsNotEmpty(items);
        }
    }
}
