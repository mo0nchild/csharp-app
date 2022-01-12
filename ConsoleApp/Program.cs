namespace MyProgram;
using static Console;

using System.Collections;
using System.Collections.Generic;

class Company : IEnumerable<Person>
{
    Person[] people;
    public Person? this[int index] 
    {
        get 
        {
            if (index >= people.Length || index < 0) return null;
            return people[index];
        }
        set 
        {
            if (index >= people.Length || index < 0) throw new ArgumentOutOfRangeException();
            people[index] = value ?? new Person("None", -1);
        }
    }

    public Company(Person[] people)
    {
        this.people = people;
    }

    public IEnumerator<Person> GetEnumerator()
    {
        return new CompanyEnumerator(people);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// iterator GetEnum
    /// </summary>
    /// <returns>element of people array</returns>
    public IEnumerable<Person> GetEnum()
    {
        Console.WriteLine("asdasdas");
        for (int i = 0; i < 2; i++)
        {
            yield return people[i];
        }
    }
}

internal class CompanyEnumerator : IEnumerator<Person>
{
    Person[] people;
    int position = -1;
    public CompanyEnumerator(Person[] people)
    {
        this.people = people;
    }

    public Person Current
    {
        get
        {
            if (position == -1 || position >= people.Length)
                throw new ArgumentException();
            return people[position];
        }
    }

    object IEnumerator.Current => throw new Exception("Уебак?");

    public void Dispose()
    { }

    public bool MoveNext()
    {
        if (position < people.Length - 1)
        {
            position++;
            return true;
        }
        else
            return false;
    }

    public void Reset() => position = -1;
}

public record Person(string Name, int Id);

public class Program
{
    public static void Main(string[] args) 
    {
        Company facebook = new(new Person[] { 
            new("Mike", 1),
            new("Tom", 2),
            new("Kate", 3),
            new("Adolf", 4),
        });

        foreach (var person in facebook) WriteLine($"{person.Name}\t->\t{person.Id}");
        foreach (var person in facebook.GetEnum()) WriteLine($"{person.Name}\t->\t{person.Id}");
    }

}
