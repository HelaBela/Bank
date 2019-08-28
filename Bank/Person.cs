namespace Bank
{
    public class Person
    {
        public string Name { get; }
        public string Address { get; }
        public int Age { get; }
        public string Email { get; }

        public Person(string name, string address, int age, string email)
        {
            Name = name;
            Address = address;
            Age = age;
            Email = email;
        }
    }
}