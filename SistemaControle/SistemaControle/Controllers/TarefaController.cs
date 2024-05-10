using Microsoft.AspNetCore.Mvc;
using SistemaControle.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaControle.Controllers
{
    public class TarefaController : Controller
    {
        private static List<Tarefa> _tarefas = new List<Tarefa>()
        {
            new Tarefa { TarefaId = 1, NomeTarefa = "Lavar a Louça" },
            new Tarefa { TarefaId = 2, NomeTarefa = "Lavar o Banheiro" },
            new Tarefa { TarefaId = 3, NomeTarefa = "Arrumar a cama" },
            new Tarefa { TarefaId = 4, NomeTarefa = "Estudar" }
        };

        //CREATEEEEE

//new Tarefa{TarefaId = 1, NomeTarefa = "Entregar exercício da sexta-feira", DataInicioTarefa = new DateTime(2024-05-01), StatusTarefa = "Concluído", DataFinalTarefa = new DateTime(2024-05-10)},

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Tarefa tarefa)
        {
            if (ModelState.IsValid)
            {
                //tarefa.DataInicio = DateTime.Today; // Definindo a data de início como a data atual

                _tarefas.Add(tarefa);
                tarefa.StatusTarefa = "Por Fazer";
                tarefa.DataInicio = DateTime.Now;
                return RedirectToAction("Index");
            }
            return View(tarefa);
        }

        public IActionResult Index()
        {
            return View(_tarefas);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Delete(int id)
        {
            var tarefa = _tarefas.FirstOrDefault(c => c.TarefaId == id);
            if (tarefa == null)
                return NotFound();
            _tarefas.Remove(tarefa);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var tarefa = _tarefas.FirstOrDefault(c => c.TarefaId == id);
            if (tarefa == null)
            {
                return NotFound();
            }
            return View(tarefa);
        }

        [HttpPost]
        public IActionResult Edit(Tarefa tarefa)
        {
            if (ModelState.IsValid)
            {
                var existingTarefa = _tarefas.FirstOrDefault(c => c.TarefaId == tarefa.TarefaId);
                if (existingTarefa != null)
                {
                    existingTarefa.NomeTarefa = tarefa.NomeTarefa;

                    existingTarefa.Descricao = tarefa.Descricao;

                    if (tarefa.StatusTarefa == "Concluída") ;

                    // tinha antes existingTarefa.DataInicio = tarefa.DataInicio;

                    {
                        existingTarefa.DataConclusao = DateTime.Now;
                    }
                    {
                        existingTarefa.DataConclusao = DateTime.Now;
                    }
                    return RedirectToAction("Index");
                }
                return View(tarefa);
            }
            return View(tarefa);
        }


        public IActionResult Detail(int id)
        {
            var tarefa = _tarefas.FirstOrDefault(c => c.TarefaId == id);
            if (tarefa == null)
                return NotFound();
            return View(tarefa);
        }

        //public IActionResult TarefasPorFazer()
      //  {
            //var tarefasPorFazer = _tarefas.Where(t => t.StatusTarefa == StatusTarefa.TarefaPorFazer).ToList();
            //return View(tarefasPorFazer);
        }


    }