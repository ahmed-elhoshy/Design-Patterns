public class Singleton {
    private static Singleton _instance;

    // Step 1: Private constructor
    private Singleton() {
        Console.WriteLine("Singleton Created!");
    }

    // Step 2 + 3: Static property to access the instance
    public static Singleton Instance {
        get {
            if (_instance == null) {
                _instance = new Singleton();
            }
            return _instance;
        }
    }

    public void ShowMessage() {
        Console.WriteLine("Hello from Singleton!");
    }
}



class Program {
    static void Main(string[] args) {
        var s1 = Singleton.Instance;
        var s2 = Singleton.Instance;

        s1.ShowMessage();

        Console.WriteLine(s1 == s2); // true => نفس الـ object
    }
}
