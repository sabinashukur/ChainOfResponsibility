namespace ChainOfResponsibility;

//In this example, I have created a IProblemHandler interface which has a single method named HandleRequest.
//This method is for building the chain of handlers.
public interface IProblemHandler
{
    void HandleRequest(int problemID);
}
//In the chain, we have three objects Employee, Manager, and TechArch all implemented the IProblemHandler interface. 
public class Employee : IProblemHandler
{
    IProblemHandler nextHandler;
    public void HandleRequest(int problemID)
    {
        if (problemID > 0 && problemID <= 10)
        {
            Console.WriteLine("Employee handles the request");
        }
        else if (this.nextHandler != null)
        {
            this.nextHandler.HandleRequest(problemID);
        }
    }
    public Employee(IProblemHandler nextHandler)
    {
        this.nextHandler = nextHandler;
    }
}

public class Manager : IProblemHandler
{
    IProblemHandler nextHandler;

    public void HandleRequest(int problemID)
    {
        if (problemID >= 11 && problemID <= 20)
        {
            Console.WriteLine("Manager handles the request");
        }
        else if (this.nextHandler != null)
        {
            this.nextHandler.HandleRequest(problemID);
        }
    }
    public Manager(IProblemHandler nextHandler)
    {
        this.nextHandler = nextHandler;
    }
}

public class TechArch : IProblemHandler
{
    IProblemHandler nextHandler;

    public void HandleRequest(int problemID)
    {
        if (problemID >= 21)
        {
            Console.WriteLine("Technical Architect handles the request");
        }
        else if (this.nextHandler != null)
        {
            this.nextHandler.HandleRequest(problemID);
        }
    }
    public TechArch(IProblemHandler nextHandler)
    {
        this.nextHandler = nextHandler;
    }
}

class Program
{
    static void Main(string[] args)
    {
        //Employee contains a reference to the Manager. Manager contains a reference to the TechArch.
        //Each object don't know about which reference it is taking.  
        // Each object stores reference into the IProblemhandler object named "nextHandler".

        TechArch techArch = new(null);
        Manager manager = new(techArch);
        Employee employee = new(manager);

        //First request comes to the Employee.If employee can not handle the request,
        //then the Employee forward the request to the Manager.
        //If Manager also can not handle the request, then the request go to the TechArch.

        employee.HandleRequest(45); //Request will handle by Tech Arch regarding to our condition
        employee.HandleRequest(15); //Request will handle by Manager regarding to our condition
        employee.HandleRequest(8); //Request will handle by Employee regarding to our condition




    }
}
