using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApi;
using WebApi.Controllers;
using Business.Entitie;

namespace WebApi.Tests.Controllers
{
    [TestClass]
    public class PostControllerTest
    {
        [TestMethod]
        public void Get()
        {
            PostController controller = new PostController();

            List<Post> result = controller.GetAll() as List<Post>;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(4, result.Count());

        }

        [TestMethod]
        public void GetById()
        {
            PostController controller = new PostController();

            Post post = new Business.Entitie.Post();
            post.Id = Guid.Parse("E8C4D859-EB0D-4795-A012-2B75E8D1F200");
            post.Titulo = "titulo teste";
            post.Corpo = "corpo Teste";

            // Assert
            Assert.IsNotNull(post);
            Assert.IsNotNull(post.Titulo);
            Assert.IsNotNull(post.Corpo);
            Assert.AreEqual(Guid.Parse("E8C4D859-EB0D-4795-A012-2B75E8D1F200"), post.Id);

        }

        [TestMethod]
        public void Post()
        {
            // Arrange
            PostController controller = new PostController();

            Post post = new Post();
            post.Titulo = "Titulo Teste";

            controller.Save(post);

            Assert.IsNotNull(post);
        }

    }
}
