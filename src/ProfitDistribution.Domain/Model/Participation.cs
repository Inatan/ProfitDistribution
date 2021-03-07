namespace ProfitDistribution.Domain.Model
{
    public class Participation
    {
        public Participation(string matricula, string nome, decimal valor_da_participação)
        {
            this.matricula = matricula;
            this.nome = nome;
            this.valor_da_participação = valor_da_participação;
        }

        
        public Participation(Employee employee, int timeWeight, int areaWeight, int wageWeight)
        {
            matricula = employee.matricula;
            nome = employee.nome;
            valor_da_participação = Calculate(employee.salario_bruto, timeWeight, areaWeight, wageWeight);
        }

        public Participation() { }

        public string matricula { get; set; }
        public string nome { get; set; }
        public decimal valor_da_participação { get; set; }

        public decimal Calculate(decimal salario_bruto, int TimeWeight, int AreaWeight, int WageWeight)
        {
            return (((salario_bruto * TimeWeight) + (salario_bruto * AreaWeight)) / WageWeight) * 12;
        }

    }
}
