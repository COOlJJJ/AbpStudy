namespace AbpModuleDemo.WebApi
{
    public record Teacher(int Age, int Id, string description, string name)
    {
        public Teacher(int Age, int ID) : this(Age, ID, "", "") { }

        //internal string description { get; set; } = description;

        //internal string name { get; set; } = name;

    }
}
