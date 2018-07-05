using System;
namespace ProjectR.MVC
{

    public interface IClock
    {
        DateTime Now { get; }
    }
}