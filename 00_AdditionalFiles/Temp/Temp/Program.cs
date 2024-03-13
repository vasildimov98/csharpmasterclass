var sm = new SomeMethod();

sm.OnShowMessage += Console.WriteLine;
sm.OnShowMessage -= Console.WriteLine;

sm.RiseEvent();


public delegate void ShowMessage(string message);

public class SomeMethod
{
    public event ShowMessage OnShowMessage;

    public void RiseEvent() => this.OnShowMessage.Invoke("Hello");
}
