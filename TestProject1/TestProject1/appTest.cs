using System.Collections.Generic;
using Xunit;
using TinderApp;

namespace TinderApp.Tests
{
    public class TinderTests
    {
        [Fact]
        public void MatchAconteceQuandoCurtidasSaoMutuas()
        {
            // Arrange
            var alice = new Perfil(
                "Alice",
                25,
                new List<string> { "música", "cinema" },
                "São Paulo");
            var bob = new Perfil(
                "Bob",
                30,
                new List<string> { "música", "esportes" },
                "São Paulo");

            // Act
            alice.Curtir(bob);
            bool houveMatch = bob.Curtir(alice); // agora há curtida mútua

            // Assert
            Assert.True(houveMatch);
            Assert.True(alice.TemMatchCom(bob));
            Assert.True(bob.TemMatchCom(alice));
        }

        [Fact]
        public void SemMatchQuandoApenasUmLadoCurte()
        {
            // Arrange
            var alice = new Perfil(
                "Alice",
                25,
                new List<string> { "música" },
                "Rio");
            var bob = new Perfil(
                "Bob",
                30,
                new List<string> { "esportes" },
                "Rio");

            // Act
            alice.Curtir(bob); // Bob não curte Alice

            // Assert
            Assert.False(alice.TemMatchCom(bob));
            Assert.False(bob.TemMatchCom(alice));
        }

        [Fact]
        public void CompatibilidadeExigeInteresseEmComumEMesmaLocalizacao()
        {
            // Arrange
            var maria = new Perfil(
                "Maria",
                28,
                new List<string> { "música", "viagem" },
                "Curitiba");
            var joao = new Perfil(
                "João",
                29,
                new List<string> { "viagem", "esportes" },
                "Curitiba");
            var carla = new Perfil(
                "Carla",
                27,
                new List<string> { "viagem" },
                "São Paulo");

            // Act / Assert
            // Maria e João: mesmo local e interesse em comum ("viagem")
            Assert.True(maria.EhCompatívelCom(joao));

            // Maria e Carla: interesse em comum, mas cidades diferentes
            Assert.False(maria.EhCompatívelCom(carla));
        }

        // Opcional: teste que falha de propósito, apenas se você quiser demonstrar um teste com falha.
        // Se não quiser ver falha no Gerenciador de Testes, remova este método.
        [Fact]
        public void MatchErradoDeveFalhar_ExemploDidatico()
        {
            var alice = new Perfil(
                "Alice",
                25,
                new List<string> { "música" },
                "SP");
            var bob = new Perfil(
                "Bob",
                30,
                new List<string> { "dança" },
                "SP");

            alice.Curtir(bob);

            // Este Assert está errado de propósito: não há curtida mútua.
            Assert.True(alice.TemMatchCom(bob));
        }
    }
}