namespace OOBeer
{
    public class Beer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Abv { get; set; }
        public void ValidateName() 
        { 
            if (Name == null) 
                throw new ArgumentNullException("Name needs to be filled.");
            if (Name.Length < 3) 
                throw new ArgumentOutOfRangeException("Name of beer must cointain atleast 4 characters.");
        }
        public void ValidateAbv() 
        {
            if (Abv < 0 || Abv > 67)
                throw new ArgumentOutOfRangeException("Alcohol % must be between 0 and 67");
        }
        public override string ToString()
        {
            return $"{Id}, {Name}, {Abv}";
        }
    }
}