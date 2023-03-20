namespace DefiningClasses
{
    public class StartUp
    {
        static void Main()
        {
            Person peter = new Person();
            Person george = new Person(15);
            Person pavel = new Person("Pavel", 12);
        }
    }
}