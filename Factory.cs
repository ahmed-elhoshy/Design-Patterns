public interface INotification {
    void Send(string to, string message);
}

-----------------------------------------------------------------------------
public class EmailNotification : INotification {
    public void Send(string to, string message) {
        Console.WriteLine($"Sending EMAIL to {to}: {message}");
    }
}

public class SmsNotification : INotification {
    public void Send(string to, string message) {
        Console.WriteLine($"Sending SMS to {to}: {message}");
    }
}

public class PushNotification : INotification {
    public void Send(string to, string message) {
        Console.WriteLine($"Sending PUSH to {to}: {message}");
    }
}

-----------------------------------------------------------------------------
public static class NotificationFactory {
    public static INotification CreateNotification(string type) {
        switch (type.ToLower()) {
            case "email":
                return new EmailNotification();
            case "sms":
                return new SmsNotification();
            case "push":
                return new PushNotification();
            default:
                throw new ArgumentException("Invalid notification type");
        }
    }
}

  -----------------------------------------------------------------------------
class Program {
    static void Main() {
        Console.WriteLine("Enter notification type (email/sms/push):");
        string type = Console.ReadLine();

        INotification notifier = NotificationFactory.CreateNotification(type);
        notifier.Send("user@example.com", "Hello from Factory Pattern!");
    }
}

-----------------------------------------------------------------------------
Enter notification type (email/sms/push):
push
=> Sending PUSH to user@example.com: Hello from Factory Pattern!


