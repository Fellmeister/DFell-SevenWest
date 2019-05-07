namespace SevenWest.Core
{
    public interface IPerson
    {
        int Age { get; set; }
        string First { get; set; }
        char Gender { get; set; }
        int Id { get; set; }
        string Last { get; set; }
    }
}