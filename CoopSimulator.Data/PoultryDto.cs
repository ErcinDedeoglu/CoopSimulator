namespace CoopSimulator.Data
{
    public class PoultryDto
    {
        public System.DateTime BirthDate { get; set; }
        public Enums.PoultrySex Sex { get; set; }
        public bool Pregnant { get; set; }
        public System.DateTime? PregnantDate { get; set; }
    }
}