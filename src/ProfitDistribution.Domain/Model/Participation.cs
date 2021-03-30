namespace ProfitDistribution.Domain.Model
{
    public class Participation
    {
        public Participation(string registrationID, string name, decimal participationValue)
        {
            this.RegistrationID = registrationID;
            this.Name = name;
            this.ParticipationValue = participationValue;
        }
        
        public Participation(Employee employee, int timeWeight, int areaWeight, int wageWeight)
        {
            RegistrationID = employee.Matricula;
            Name = employee.Nome;
            ParticipationValue = Calculate(employee.Salario_bruto, timeWeight, areaWeight, wageWeight);
        }

        public Participation() { }

        public string RegistrationID { get; set; }
        public string Name { get; set; }
        public decimal ParticipationValue { get; set; }

        public decimal Calculate(decimal salario_bruto, int timeWeight, int areaWeight, int wageWeight)
        {
            return (((salario_bruto * timeWeight) + (salario_bruto * areaWeight)) / wageWeight) * 12;
        }

    }
}
