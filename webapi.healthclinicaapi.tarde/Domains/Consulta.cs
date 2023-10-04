using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.healthclinica.tarde.Domains
{
    [Table(nameof(Consulta))]
    public class Consulta
    {
        [Key]
        public Guid IdConsulta { get; set; } = Guid.NewGuid();

        [Column(TypeName = "Text")]
        [Required(ErrorMessage = "Data da consulta é obrigatória.")]
        public string ? DataConsulta { get; set; }

        [Column(TypeName = "Text")]
        [Required(ErrorMessage = "Horário da consulta é obrigatória.")]
        public string? HoraConsulta { get; set; }

        [Column(TypeName = "Text")]
        [Required(ErrorMessage = "A descrição da consulta é obrigatória.")]
        public string Descricao { get; set; }

        [Column(TypeName = "Varchar(300)")]
        public string Feedback { get; set; }


        [Required(ErrorMessage = "Necessário Id do médico.")]
        public Guid IdMedico { get; set; }

        [ForeignKey(nameof(IdMedico))]
        public Medico? Medico { get; set; }

        [Required(ErrorMessage = "Necessário Id do paciente")]
        public Guid IdPaciente { get; set; }

        [ForeignKey(nameof(IdPaciente))]
        public Paciente? Paciente { get; set; }
    }
}
