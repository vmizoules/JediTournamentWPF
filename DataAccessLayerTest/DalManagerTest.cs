using System;
using DataAccessLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntitiesLayer;
using System.Collections.Generic;

namespace DataAccessLayerTest {
    [TestClass]

    public class DalManagerTest 
    {
        private void Initialize() {
            DalManager manager = new DalManager();

            // TODO : to continue
        }

        [TestMethod]
        public void getJediTest() {
            DalManager manager = new DalManager();

            List<Jedi> list = manager.getJedis();

            Console.WriteLine(list.Count);
        }

        [TestMethod]
        public void getStadeTest() {
            DalManager manager = new DalManager();

            List<Stade> list = manager.getStades();

            Console.WriteLine(list.Count);
        }

        [TestMethod]
        public void TestCreateDeleteJedis() 
        {
            DalManager manager = new DalManager();
            List<Jedi> list1 = manager.getJedis();
            
            Jedi newJedi = new Jedi(12, "JediTest", true, null);

            manager.InsertJedi(newJedi);
            List<Jedi> listTemp = list1;
            listTemp.Add(newJedi);

            List<Jedi> list2 = manager.getJedis();
            Assert.AreEqual(list1, list2);

            manager.DeleteJedis(newJedi);
            list2 = manager.getJedis();

            Assert.AreEqual(list1, list2);

        }

        [TestMethod]
        public void TestCreateDeleteStades()
        {
            DalManager manager = new DalManager();
            List<Stade> list1 = manager.getStades();

            Stade newStade = new Stade(12, 1000, "PlaneteTest", null);

            manager.InsertStade(newStade);
            List<Stade> listTemp = list1;
            listTemp.Add(newStade);

            List<Stade> list2 = manager.getStades();
            Assert.AreEqual(list1, list2);

            manager.DeleteStades(newStade);
            list2 = manager.getStades();

            Assert.AreEqual(list1, list2);
        }

        [TestMethod]
        public void TestUpdateJedis()
        {
            DalManager manager = new DalManager();
            List<Jedi> list1 = manager.getJedis();

            Jedi updatedJedi = list1[0];
            updatedJedi.IsSith = true;
            updatedJedi.Nom = "JediTest";

            manager.UpdateJedi(updatedJedi); //Modification du premier Jedi

            List<Jedi> list2 = manager.getJedis();
            Assert.AreEqual(updatedJedi, list2[0]); //Test si le premier Jedi à bien été modifié

            updatedJedi.IsSith = list1[0].IsSith;
            updatedJedi.Nom = list1[0].Nom;

            manager.UpdateJedi(updatedJedi); //Reinitialisation du premier Jedi
            list2 = manager.getJedis();

            Assert.AreEqual(list1, list2); //Test si le jedi est bien réinitialisé
        }

        [TestMethod]
        public void TestUpdateStades()
        {
            DalManager manager = new DalManager();
            List<Stade> list1 = manager.getStades();

            Stade updatedStade = list1[0];
            updatedStade.NbPlaces = 1000;
            updatedStade.Planete = "PlanetTest";

            manager.UpdateStade(updatedStade); //Modification du premier Stade

            List<Stade> list2 = manager.getStades();
            Assert.AreEqual(updatedStade, list2[0]); //Test si le premier Stade à bien été modifié

            updatedStade.NbPlaces = list1[0].NbPlaces;
            updatedStade.Planete = list1[0].Planete;

            manager.UpdateStade(updatedStade); //Reinitialisation du premier Stade
            list2 = manager.getStades();

            Assert.AreEqual(list1, list2); //Test si le stade est bien réinitialisé
        }
    }
}
