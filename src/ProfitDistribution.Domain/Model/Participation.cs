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
            RegistrationID = employee.RegistrationId;
            Name = employee.Name;
            ParticipationValue = Calculate(employee.GrossSalary, timeWeight, areaWeight, wageWeight);
        }

        public Participation() { }

        public readonly string RegistrationID;
        public readonly string Name;
        public readonly decimal ParticipationValue;

        public decimal Calculate(decimal salario_bruto, int timeWeight, int areaWeight, int wageWeight)
        {
            return (((salario_bruto * timeWeight) + (salario_bruto * areaWeight)) / wageWeight) * 12;
        }

    }
}
