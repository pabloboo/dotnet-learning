Notes on this [tutorial](https://www.youtube.com/watch?v=GRLidsP3O2M&t=224s&ab_channel=Simplilearn).

# What is Dependency Injection

Dependency injection (DI) is a software design patter that enables for loosely coupled software.

DI is a great way to reduce tight coupling between software components.

DI also enables us to better manage future changes and other complexity in our software.

DI's goal is to make code more manageable.

# How to implement dependency injection

There are three ways of implementing dependency injection: constructor DI, property DI and method DI.

# Constructor injection

## Definition

The constructor injection usually has only one parameterized constructor.

There is no default constructor in constructor DI.

We need to pass the specified value during object creation.

We can use the injection component anywhere within the class.

## Implementation example

```c#
public interface text
{
    void print();
}

class format: text
{
    public void print()
    {
        Console.WriteLine("Hello world");
    }
}

public class constructorInjection
{
    private text _text;

    public constructorInjection(text t1)
    {
        this._text=t1;
    }

    public void print()
    {
        _text.print()
    }
}

class constructor
{
    static void Main(string args)
    {
        constructorInjection cs = new constructorInjection(BinaryWriter format());
        cs.print();
        Console.ReadKey();
    }
}

```

In the example before DI is needed because it decouples the "constructorInjection" class from the specific implementation of "text", making it more flexible and allowing it to work with any class implementing the "text" interface.

In the example the "constructorInjection" class relies on the interface "text", and the implementation "format" is passed into the class via its constructor. When the "print" method is called, it calls the "print" method from the "text" interface, which is implemented by "format" to display "Hello world.". The dependency ("text" instance) is passed into the constructor.


# Property injection

## Definition

Property is typically used when we need paraterless constructor.

It could work without changing the object state.

## Implementation example

```c#
public interface INotificationAction
{
    void ActOnNotification(string message);
}

class simple
{
    INotificationAction task = null;
    
    public void notify(INotificationAction at, string messages)
    {
        this.task = at;
        task.ActOnNotification(messages);
    }
}

class EventLogWriter : INotificationAction
{
    public void ActOnNotification(string message)
    {
        Console.WriteLine("Click on the Bell icon to get notifications");
    }
}

class Program
{
    static void Main(string[] args)
    {
        EventLogWriter elw = new EventLogWriter();
        simple at = new simple();
        at.notify(elw, "to log");
        Console.ReadKey();
    }
}
```

In the example before DI is needed because it reduces coupling by allowing the "simple" class to work with any implementation of "INotificationAction", making it flexible for future changes.

In the example the "simple" class has a property-like behavior where the dependency ("INotificationAction") is set through the notify method. The "EventLogWriter" class implements the "INotificationAction" interface, and its "ActOnNotification" method prints a message to the console. The "simple" class depends on "INotificationAction" but does not require it during object creation (constructor), allowing the dependency to be injected later.

This approach is helpful when you want a parameterless constructor or when the dependency might change over the lifetime of the object.

# Method injection

## Definition

We only need to pass the dependency in the method when using method injection.

We do not use constructor injection because it would create a dependent object every time that class is instantiated.

## Implementation example

```c#
public itnerface Iset
{
    void print();
}

public class servic : Iset
{
    public void print()
    {
        Console.WriteLine(print.....);
    }
}

public class client
{
    private Iset _Iset;

    public void run(Iset serv)
    {
        this._Iset=serv;
        Console.WriteLine("Start");
        this._Iset.print();
    }
}

class method
{
    public static void Main()
    {
        client cn = new client();
        cn.run(new servic());
        Console.ReadKey();
    }
}
```

In the example before DI is needed because it ensures that the "client" class can work with any "Iset" implementation, providing loose coupling and ease of modification.

In the example the "client" class has a "run" method that takes a dependency of type "Iset", which is implemented by the "servic" class. The "run" method sets the dependency and uses it to call "print", which outputs a message.

This method demonstrates method injection, where the dependency is passed directly to the method that needs it, rather than being injected at the class level (via constructor or property). This is useful when the dependency is only needed for specific methods and not throughout the class, avoiding unnecessary instantiation of dependent objects and keeping the code flexible.

# Conclusion

In summary, use **constructor injection** when the dependency is essential for the class to function and should be provided at the time of object creation, ensuring the object is fully initialized with its dependencies. **Property injection** is ideal when the dependency can be optional or changeable after object creation, allowing for more flexibility in setting dependencies. **Method injection** is best when the dependency is only needed for specific methods and not throughout the class, reducing unnecessary instantiation and promoting more focused use of dependencies. Each method helps in decoupling components, but the choice depends on when and how the dependency should be provided.

DI helps in reducing class coupling, increases the reusability of code, helps to improve code maintainability and makes it feasible to conduct unit testing.

# Short explanation on how to implement each type of DI

## Constructor Injection
To implement constructor injection, pass the dependency through the class constructor. The dependency is required when the object is created, ensuring the class always has the necessary components to function. For example, in a service class, pass a database or logging service as a constructor parameter to ensure it's available whenever the class is instantiated.

```c#
public class Service
{
    private readonly ILogger _logger;

    public Service(ILogger logger)
    {
        _logger = logger;
    }

    public void PerformAction()
    {
        _logger.Log("Action performed");
    }
}
```

## Property Injection
In property injection, the dependency is provided via a setter property after the object is created. This is useful when the dependency is optional or can change after object creation. For example, a notification service can be set using a property.

```c#
public class NotificationService
{
    public IEmailSender EmailSender { get; set; }

    public void SendNotification(string message)
    {
        EmailSender?.SendEmail(message);
    }
}
```

## Method Injection
Method injection passes the dependency as a parameter to the specific method that needs it, allowing for a more targeted use of dependencies. This is useful when the dependency is only required for certain actions or methods within the class.

```c#
public class ReportGenerator
{
    public void GenerateReport(IReportFormatter formatter)
    {
        string report = formatter.Format("Report data");
        Console.WriteLine(report);
    }
}
```