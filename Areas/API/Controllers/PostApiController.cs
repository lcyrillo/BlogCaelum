using System.Collections.Generic;
using Blog.DAO;
using Blog.Models;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Areas.API.Controllers
{
    [Area("API")]
    [Route("/api/post")]
    [ApiController]
    public class PostApiController : ControllerBase
    {
        public readonly PostDAO _dao;
        public PostApiController(PostDAO dao)
        {
            _dao = dao;
        }

        [Route("lista")]
        [HttpGet]
        public IActionResult BuscaTodosOsPost()
        {
            IList<Post> posts = _dao.Lista();
            return Ok(posts);
        } 

        [Route("{id}")]
        [HttpGet]
        public IActionResult BuscaPorId(int id)
        {
            Post post = _dao.ListaPorId(id);
            return Ok(post);
        }

        [Route("novo")]
        [HttpPost]
        public IActionResult CadastraPost([FromBody] Post post)
        {
            _dao.Adiciona(post);
            return CreatedAtAction("BuscaPorId", new {id = post.Id}, post);
        }

        [Route("{id}")]
        [HttpPut]
        public IActionResult AtualizaPost(int id, [FromBody] Post post)
        {
            Post postAtualiza = _dao.ListaPorId(id);

            if(postAtualiza == null)
            {
                return NotFound();
            }

            postAtualiza.Categoria = post.Categoria;
            postAtualiza.Titulo = post.Titulo;
            postAtualiza.Resumo = post.Resumo;
            postAtualiza.Publicado = post.Publicado;
            postAtualiza.DataPublicacao = post.DataPublicacao;
            
            _dao.Atualiza(postAtualiza);

            return NoContent();
        }

        [Route("{id}")]
        [HttpDelete]
        public IActionResult DeletaPost(int id)
        {
            Post post = _dao.ListaPorId(id);

            if(post == null)
            {
                return NotFound();
            }

            _dao.Remove(id);
            
            return NoContent();
        }
    }
}