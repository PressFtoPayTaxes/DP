// TODO: привести логику работы программы в сооветствии с выводом в консоль приведенным внизу файла

using System;

public interface IClone
{
    object Clone();
}

public class Person : IClone
{
    public int Age;
    public DateTime BirthDate;
    public string Name;
    public IdInfo IdInfo;
    public string SecondName;
    public Address Address;

    public Person ShallowCopy()
    {
        return (Person)this.MemberwiseClone();
    }

    public object Clone()
    {
        Person clone = (Person)this.MemberwiseClone();
        clone.IdInfo = new IdInfo(IdInfo.IdNumber);
        clone.Name = String.Copy(Name);
        clone.SecondName = string.Copy(SecondName);
        clone.Address = new Address(Address.Street, Address.House);
        return clone;
    }
}

public class IdInfo
{
    public int IdNumber;

    public IdInfo(int idNumber)
    {
        this.IdNumber = idNumber;
    }
}

public class Address
{
    public string Street;
    public int House;

    public Address(string street, int house)
    {
        Street = string.Copy(street);
        House = house;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Person p1 = new Person();
        p1.Age = 42;
        p1.BirthDate = Convert.ToDateTime("1977-01-01");
        p1.Name = "Jack";
        p1.SecondName = "Daniels";
        p1.IdInfo = new IdInfo(666);
        p1.Address = new Address("Kings Road", 15);

        Person p2 = p1.ShallowCopy();
        Person p3 = (Person)p1.Clone();

        Console.WriteLine("Original values of p1, p2, p3:");
        Console.WriteLine("   p1 instance values: ");
        DisplayValues(p1);
        Console.WriteLine("   p2 instance values:");
        DisplayValues(p2);
        Console.WriteLine("   p3 instance values:");
        DisplayValues(p3);

        p1.Age = 32;
        p1.BirthDate = Convert.ToDateTime("1900-01-01");
        p1.Name = "Frank";
        p1.SecondName = "Simpson";
        p1.IdInfo.IdNumber = 7878;
        p1.Address = new Address("Wall street", 10);
        Console.WriteLine("\nValues of p1, p2 and p3 after changes to p1:");
        Console.WriteLine("   p1 instance values: ");
        DisplayValues(p1);
        Console.WriteLine("   p2 instance values (reference values have changed):");
        DisplayValues(p2);
        Console.WriteLine("   p3 instance values (everything was kept the same):");
        DisplayValues(p3);

        Console.ReadLine();
    }

    public static void DisplayValues(Person p)
    {
        Console.WriteLine("      Name: {0:s}, Second Name: {1:s} Age: {2:d}, BirthDate: {3:MM/dd/yy}",
            p.Name, p.SecondName, p.Age, p.BirthDate);
        Console.WriteLine("      ID#: {0:d}", p.IdInfo.IdNumber);
        Console.WriteLine("      Full Address: {0:d} {1:s}", p.Address.House, p.Address.Street);
    }
}


/*
Original values of p1, p2, p3:
   p1 instance values:
      Name: Jack, Second Name: Daniels, Age: 42, BirthDate: 01/01/77
      ID#: 666
      Full Address: 15 Kings Road
   p2 instance values:
      Name: Jack, Second Name: Daniels, Age: 42, BirthDate: 01/01/77
      ID#: 666
      Full Address: 15 Kings Road
   p3 instance values:
      Name: Jack, Second Name: Daniels, Age: 42, BirthDate: 01/01/77
      ID#: 666
      Full Address: 15 Kings Road

Values of p1, p2 and p3 after changes to p1:
   p1 instance values:
      Name: Frank, Second Name: Simpson, Age: 32, BirthDate: 01/01/00
      ID#: 7878
      Full Address: 10 Wall street
   p2 instance values (reference values have changed):
      Name: Jack, Second Name: Daniels, Age: 42, BirthDate: 01/01/77
      ID#: 7878
      Full Address: 10 Wall street
   p3 instance values (everything was kept the same):
      Name: Jack, Second Name: Daniels, Age: 42, BirthDate: 01/01/77
      ID#: 666
      Full Address: 15 Kings Road
 */
