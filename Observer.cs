public interface IWeatherStation {
    void Register(IObserver observer);
    void Unregister(IObserver observer);
    void NotifyObservers();
}

public interface IObserver {
    void Update(float temperature);
}


public class WeatherStation : IWeatherStation {
    private List<IObserver> observers = new List<IObserver>();
    private float temperature;

    public void Register(IObserver observer) {
        observers.Add(observer);
    }

    public void Unregister(IObserver observer) {
        observers.Remove(observer);
    }

    public void SetTemperature(float temp) {
        temperature = temp;
        NotifyObservers();
    }

    public void NotifyObservers() {
        foreach (var observer in observers) {
            observer.Update(temperature);
        }
    }
}



public class MobileApp : IObserver {
    private string _name;

    public MobileApp(string name) {
        _name = name;
    }

    public void Update(float temperature) {
        Console.WriteLine($"{_name} received new temperature: {temperature}°C");
    }
}



class Program {
    static void Main() {
        var station = new WeatherStation();

        var app1 = new MobileApp("Ahmed's Phone");
        var app2 = new MobileApp("Mona's Phone");

        station.Register(app1);
        station.Register(app2);

        station.SetTemperature(30.5f);
        station.SetTemperature(32.0f);

        station.Unregister(app2);
        station.SetTemperature(29.0f);
    }
}



Ahmed's Phone received new temperature: 30.5°C  
Mona's Phone received new temperature: 30.5°C  
Ahmed's Phone received new temperature: 32°C  
Mona's Phone received new temperature: 32°C  
Ahmed's Phone received new temperature: 29°C
