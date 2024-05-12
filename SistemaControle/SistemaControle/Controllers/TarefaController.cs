using Microsoft.AspNetCore.Mvc;
using SistemaControle.Models;
using System.Collections.Generic;
using System.Linq;

namespace SistemaControle.Controllers
{
    public class TarefaController : Controller
    {
        private static List<Tarefa> _tarefa = new List<Tarefa>();

        public IActionResult Index()
        {
            return View(_tarefa);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Tarefa tarefa)
        {
            if (ModelState.IsValid)
            {
                tarefa.TarefaId = _tarefa.Count > 0 ? _tarefa.Max(c => c.TarefaId) + 1 : 1;
                _tarefa.Add(tarefa);
            }

            return RedirectToAction("TarefaAFazer");
        }

        public IActionResult Delete(int id)
        {
            var tarefa = _tarefa.FirstOrDefault(c => c.TarefaId == id);
            if (tarefa == null)
                return NotFound();
            _tarefa.Remove(tarefa);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var tarefa = _tarefa.FirstOrDefault(c => c.TarefaId == id);
            if (tarefa == null)
                return NotFound();
            return View(tarefa);
        }

        [HttpPost]
        public IActionResult Edit(Tarefa tarefa)
        {
            if (ModelState.IsValid)
            {
                var existingTarefa = _tarefa.FirstOrDefault(c => c.TarefaId == tarefa.TarefaId);
                if (existingTarefa != null)
                {
                    existingTarefa.NomeTarefa = tarefa.NomeTarefa;
                    existingTarefa.DataConclusao = tarefa.DataConclusao;          
                    existingTarefa.Concluida = tarefa.DataConclusao != default;
                }

                return RedirectToAction("TarefaConcluida");
            }
            return View(tarefa);
        }

        public IActionResult TarefaConcluida()
        {
            return View(_tarefa.Where(t => t.Concluida).ToList());
        }

        public IActionResult TarefaAFazer()
        {
            return View(_tarefa.Where(t => !t.Concluida).ToList());
        }

        public IActionResult Detail(int id)
        {
            var tarefa = _tarefa.FirstOrDefault(c => c.TarefaId == id);
            if (tarefa == null)
                return NotFound();
            return View(tarefa);
        }
    }
}
