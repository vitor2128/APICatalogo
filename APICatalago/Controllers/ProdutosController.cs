﻿using APICatalago.Context;
using APICatalago.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICatalago.Controllers
{
  [ApiController]
  [Route("/api/[controller]")]
  public class ProdutosController : ControllerBase
  {
    private readonly AppDbContext _context;

    public ProdutosController(AppDbContext contexto)
    {
      _context = contexto;
    }

    #region Listar todos os produtos
    [HttpGet]
    public ActionResult<IEnumerable<Produto>> Get()
    {
      return _context.Produto.AsNoTracking().ToList();
    }

    #endregion

    #region Buscar produto por id
    [HttpGet("{id}", Name = "ObterProduto")]
    public ActionResult<Produto> Get(int id)
    {
      var produto = _context.Produto.AsNoTracking().FirstOrDefault(p => p.ProdutoId == id);
      if (produto == null)
      {
        return NotFound();
      }
      return produto;
    }

    #endregion

    #region Criar produto
    [HttpPost]
    public ActionResult Post([FromBody] Produto produto)
    {
      _context.Produto.Add(produto);
      _context.SaveChanges();

      return new CreatedAtRouteResult("ObterProduto", new { id = produto.ProdutoId }, produto);
    }
    #endregion

    #region Atualizar produto
    [HttpPut("{id}")]
    public ActionResult Put(int id, [FromBody] Produto produto)
    {
      if (id != produto.ProdutoId)
      {
        return BadRequest();
      }

      _context.Entry(produto).State = EntityState.Modified;
      _context.SaveChanges();
      return Ok();
    }
    #endregion

    #region Deletar produto
    [HttpDelete("{id}")]
    public ActionResult<Produto> Delete(int id)
    {
      var produto = _context.Produto.FirstOrDefault(p => p.ProdutoId == id);
      if (produto == null)
      {
        return NotFound();
      }
      _context.Produto.Remove(produto);
      _context.SaveChanges();
      return produto;
    }
  }
  #endregion
}
