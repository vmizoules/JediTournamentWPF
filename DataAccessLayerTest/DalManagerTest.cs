using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccessLayer;
using System.Collections.Generic;
using EntitiesLayer;

namespace DataAccessLayerTest {
    [TestClass]
    public class DalManagerTest {
        [TestMethod]
        public void TestMethod1() {
            DalManager manager = new DalManager();

            List<Jedi> jedilist = manager.getJedis();

            foreach(Jedi j in jedilist) {
                Console.WriteLine(j.Nom);
            }

        }
    }
}
