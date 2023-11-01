// Deze mag niet in een Namespace, op deze manier een Setup voor de gehele test library

[SetUpFixture]
public class Setup
{

    [OneTimeSetUp]
    public static void OneTimeSetUp()
    {
        // Dingen die éénmalig geinitialiseerd moeten worden
    }
}