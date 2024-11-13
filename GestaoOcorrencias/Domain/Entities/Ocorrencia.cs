namespace GestaoOcorrencias.Domain.Entities
{
    public class Ocorrencia
    {
        public int Id { get; set; }
        public DateTime DataAbertura { get; set; }
        public DateTime DataOcorrencia { get; set; }
        public string Descricao { get; set; }
        public Cliente ResponsavelAbertura { get; set; }
        public Cliente ResponsavelOcorrencia { get; set; }
        public string Conclusao { get; set; }
        public List<Etapa> Etapas { get; set; }
    }
}
