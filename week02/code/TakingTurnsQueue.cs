/// <summary>

/// This queue is circular. When people are added via AddPerson, then they are added to the
/// back of the queue (per FIFO rules). When GetNextPerson is called, the next person
/// in the queue is saved to be returned and then they are placed back into the back of the queue.
/// Each person stays in the queue while they still have turns.
/// A turns value of 0 or less means they have infinite turns.
/// </summary>
public class TakingTurnsQueue
{
    private readonly PersonQueue _people = new();

    public int Length => _people.Length;

    /// <summary>
    /// Add new people to the queue with a name and number of turns
    /// </summary>
    /// <param name="name">Name of the person</param>
    /// <param name="turns">Number of turns remaining</param>
    public void AddPerson(string name, int turns)
    {
        var person = new Person(name, turns);
        _people.Enqueue(person);
    }

    /// <summary>
    /// Get the next person in the queue and return them.
    /// People with turns remaining return to the back of the queue.
    /// A turns value of 0 or less represents infinite turns.
    /// </summary>
    public Person GetNextPerson()
    {
        if (_people.IsEmpty())
        {
            throw new InvalidOperationException("No one in the queue.");
        }

        var person = _people.Dequeue();

        // Positive values represent a finite number of turns.
        if (person.Turns > 0)
        {
            person.Turns--;

            // Put the person back only if they still have turns remaining.
            if (person.Turns > 0)
            {
                _people.Enqueue(person);
            }
        }
        else
        {
            // Zero or negative means infinite turns.
            // Do not modify the value.
            _people.Enqueue(person);
        }

        return person;
    }

    public override string ToString()
    {
        return _people.ToString();
    }
}