/*
// See https://aka.ms/new-console-template for more information
using System.Reflection.Metadata;

Console.WriteLine("Hello, World!");
Console.WriteLine("Hello, World!");
Console.WriteLine("Hello, World!");
Console.WriteLine("Hello, World!");
Console.WriteLine("Hello, World!");
Console.WriteLine("Hello, World!");
Console.WriteLine("Hello, World!");
Console.WriteLine("Hello, World!");
Console.WriteLine("Hello, World!");
Console.WriteLine("Hello, World!");


var person = new Person   ("Pablo", Nationality.Mexican );

person.SayHi();
person.ChangeNationality("American");

person.SayHi();

var person2 = new Person { Name = "John", Lang = "en", Nationality = "American" };
person2.SayHi();


enum Nationality
{
    American,
    Mexican
}

enum Language
{
    English,
    Spanish
}

class Person
{
    public string Lang { get; private set; }
    public string Name { get; set; }
    public string Nationality { get; private set; }

    public Person(string name, Nationality nationality)
    {
        Name = name;
        ChangeNationality(nationality);
    }

    public void ChangeNationality(Nationality newNationality)
    {
        Nationality = newNationality;
        if (newNationality == "American")
        {
            Lang = "en";
        }
        else if (newNationality == "Mexican")
        {
            Lang = "es";
        }
    }
    public string SayHi()
    {
        if (Lang == "en")
            return "Hi!";
        if (Lang == "es")
            return "¡Hola!";

        return "Hi!";
    }


}
*/

