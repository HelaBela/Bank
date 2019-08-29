namespace Bank
{
    public class Person
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int Age { get; }

        public string Email { get; set; }

        public Person(string name, string address, int age, string email)
        {
            Name = name;
            Address = address;
            Age = age;
            Email = email;
        }

        
    }
}

/*get
{
int year;
int age = this.Age;
                
System.DateTime moment = new System.DateTime(
    2019);
{
    year = moment.Year;
}

if (year == year + 1)
{
                    
    age++;

}

return age;
}
set { throw new System.NotImplementedException(); } */