namespace ProfitDistribution.Domain.Model
{
    public class Participation
    {
        public Participation(string matricula, string nome, decimal valor_da_participação)
        {
            this.Matricula = matricula;
            this.Nome = nome;
            this.Valor_da_participacao = valor_da_participação;
        }

        
        public Participation(Employee employee, int timeWeight, int areaWeight, int wageWeight)
        {
            Matricula = employee.Matricula;
            Nome = employee.Nome;
            Valor_da_participacao = Calculate(employee.Salario_bruto, timeWeight, areaWeight, wageWeight);
        }

        public Participation() { }

        public string Matricula { get; set; }
        public string Nome { get; set; }
        public decimal Valor_da_participacao { get; set; }

        public decimal Calculate(decimal salario_bruto, int timeWeight, int areaWeight, int wageWeight)
        {
            return (((salario_bruto * timeWeight) + (salario_bruto * areaWeight)) / wageWeight) * 12;
        }

    }
}
