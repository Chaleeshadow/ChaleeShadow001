using UnityEngine;
using Zenject;
using UniRx;
namespace ProjectR.MVC
{
    public class ErrorCenter 
    {
        public bool ishasError;


        public  void IsError()
        {
            if (!ishasError)
            {
                ishasError = !ishasError;

            }
        }

    }
}