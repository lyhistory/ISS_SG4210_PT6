﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CRS_DAL;
using CRS_DAL.Repository;
using CRS_DAL.EF;
using System.Linq;
using System.Collections.Generic;
namespace UnitTest
{
    [TestClass]
    public class UnitOfWorkTests
    {
        [TestMethod]
        public void TestUserRepository()
        {
            UnitOfWork unitOfWork = new UnitOfWork();
            
            var user=unitOfWork.UserService.GetByLoginID("G123456");
            Assert.AreEqual(user.RoleName, "User");
        }
    }
}
