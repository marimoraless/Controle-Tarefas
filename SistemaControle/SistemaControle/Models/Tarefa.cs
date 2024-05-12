using System;
using System.ComponentModel.DataAnnotations;
using SistemaControle.Models;
namespace SistemaControle.Models
{
    public class Tarefa
    {
        public int TarefaId { get; set; }
        public string? NomeTarefa { get; set; } = string.Empty;
        public DateOnly DataInicio { get; set; }
        public DateOnly? DataConclusao { get; set; } 
        public string? Observação { get; set; }
        public string? StatusTarefa { get; set; } 
        public string? TarefaAFazer { get; set; }
        public bool Concluida { get; set; } 
    }
} 
