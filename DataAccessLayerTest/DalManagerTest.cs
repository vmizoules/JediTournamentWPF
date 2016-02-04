using System;
using DataAccessLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntitiesLayer;
using System.Collections.Generic;

namespace DataAccessLayerTest {
    [TestClass]

    public class DalManagerTest 
    {
        [TestMethod]
        public void TestAjoutSuppressionJedis() 
        {
            DalManager manager = new DalManager();
            List<Jedi> list1 = manager.getJedis();

            Jedi newJedi = new Jedi(12, "JediTest", true, null);

            manager.UpdateJedi(newJedi);
            List<Jedi> listTemp = list1;
            listTemp.Add(newJedi);

            List<Jedi> list2 = manager.getJedis();
            Assert.AreEqual(list1, list2);

            manager.DeleteJedis(newJedi);
            list2 = manager.getJedis();

            Assert.AreEqual(list1, list2);

        }

        [TestMethod]
        public void TestAjoutSuppressionStades()
        {
            DalManager manager = new DalManager();
            List<Stade> list1 = manager.getStades();

            Stade newStade = new Stade(12, 1000, "PlaneteTest", null);

            manager.UpdateStade(newStade);
            List<Stade> listTemp = list1;
            listTemp.Add(newStade);

            List<Stade> list2 = manager.getStades();
            Assert.AreEqual(list1, list2);

            manager.DeleteStades(newStade);
            list2 = manager.getStades();

            Assert.AreEqual(list1, list2);

        }
    }
}
