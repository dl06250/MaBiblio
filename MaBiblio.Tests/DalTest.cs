﻿using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MaBiblio.Models;

namespace MaBiblio.Tests
{
    /// <summary>
    /// Tests de la DAL
    /// </summary>
    [TestClass]
    public class DalTest
    {
        private IDal dal;

        [TestInitialize()]
        public void MyTestInitialize() 
        {
            dal = new DalEnDur();
        }
        
        [TestCleanup()]
        public void MyTestCleanup() 
        {
            dal.Dispose();
        }
        
        [TestMethod]
        public void ObtenirTousLesLivresRenvoieCinqLivres()
        {
            List<Livres> listeDesLivres = dal.ObtenirTousLesLivres();
            Assert.IsNotNull(listeDesLivres);
            Assert.AreEqual(5, listeDesLivres.Count);
        }

        [TestMethod]
        public void ObtenirTousLesAuteursRenvoieTroisAuteurs()
        {
            List<Auteurs> listeDesAuteurs = dal.ObtenirTousLesAuteurs();
            Assert.IsNotNull(listeDesAuteurs);
            Assert.AreEqual(3, listeDesAuteurs.Count);
        }

        [TestMethod]
        public void ObtenirTousLesLivresDeCamusRenvoieDeuxLivres()
        {
            List<Livres> listeDesLivresDeCamus = dal.ObtenirTousLesLivres(3);
            Assert.IsNotNull(listeDesLivresDeCamus);
            Assert.AreEqual(2, listeDesLivresDeCamus.Count);
            bool existe=listeDesLivresDeCamus.Exists(l => l.Titre=="L'étranger");
            Assert.IsTrue(existe, "L'étranger");
            existe = listeDesLivresDeCamus.Exists(l => l.Titre == "La peste");
            Assert.IsTrue(existe, "La peste");
        }

        [TestMethod]
        public void ObtenirLeLivreLesMiserables()
        {
            Livres lesMiserables = dal.ObtenirUnLivre(3);
            Assert.IsNotNull(lesMiserables);
            Assert.AreEqual("Les misérables", lesMiserables.Titre);
        }
    }
}
