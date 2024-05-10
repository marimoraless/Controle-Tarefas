using System;

namespace SistemaControle.Models
{
    public class Tarefa
    {
        public int TarefaId { get; set; }
        public string? NomeTarefa { get; set; } = string.Empty;
        public DateTime DataInicio { get; set; }

        public string Descricao { get; set; }

        public DateTime DataConclusao { get; set; } 
        public string? StatusTarefa { get; set; }

        public string? TarefaPorFazer { get; set; }
    }

    public enum StatusTarefa
    {
        Pendente,
        Concluída
    }
}
