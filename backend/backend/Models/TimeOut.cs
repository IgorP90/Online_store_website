using backend.CRUD;

namespace exMethod;
public static class TimeOut
{
    public static void HoldBackTime(this Read read)
    {
        Thread.Sleep(1000);
    }
}

