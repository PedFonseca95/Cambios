namespace Cambios.Modelos
{
    public class Rate
    {
        public int RateId { get; set; }

        public string Code { get; set; }

        public double TaxRate { get; set; }

        public string Name { get; set; }

        //public override string ToString()
        //{
        //    return $"{Name}"; // Fazer override do método default ToString() para que apareçam os nomes das várias moedas na comboBox -> Polimorfismo
        //}
    }
}
