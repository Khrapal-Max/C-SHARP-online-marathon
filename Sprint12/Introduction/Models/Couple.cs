namespace Introduction.Models
{
    public class Couple
    {
        public Triangle tr1 { get; set; }
        public Triangle tr2 { get; set; }

        public Couple(Triangle tr1, Triangle tr2)
        {
            this.tr1 = tr1;
            this.tr2 = tr2;
        }
    }
}