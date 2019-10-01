using System;
using System.Collections.Generic;
using System.Net;
using ABE_Auditoria.Controllers;
using ABE_Auditoria.Models;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace ABE_Auditoria.Tests
{
    public class TransacoesTest
    {
        [Fact]
        public void AdicionarTransacaoCorreta()
        {
            // Arrange
            var controller = new TransacoesController();
            var novaTransacao = new Transacao
            {
                Data = DateTime.Now,
                PedidoId = 32,
                UsuarioId = 54,
                Valor = 342.56m
            };

            // Act
            var response = controller.Post(novaTransacao).Value as Transacao;

            // Assert
            Assert.NotEqual(0, response.Id);
        }

        [Fact]
        public void AdicionarTransacaoInvalida()
        {
            // Arrange
            var controller = new TransacoesController();
            var novaTransacao = new Transacao
            {
                Data = DateTime.Now,
                UsuarioId = 54,
                Valor = 342.56m
            };

            // Act
            var response = controller.Post(novaTransacao).Result as BadRequestResult;
            var expected = (int)HttpStatusCode.BadRequest;

            // Assert
            Assert.NotNull(response);
            Assert.Equal(expected, response.StatusCode);
        }

        [Fact]
        public void ObterTodasTransacoes()
        {
            // Arrange
            var controller = new TransacoesController();
            var itensCount = TransacoesController.transacoes.Count;

            // Act
            var response = controller.Get().Value as ICollection<Transacao>;

            // Assert
            Assert.Equal(itensCount, response.Count);
        }
    }
}