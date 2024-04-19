using System;
using System.Collections.Generic;

namespace BrickBreaker
{
    public static class ServiceLocator
    {
        private static readonly Dictionary<Type, object> _listServices = new Dictionary<Type, object>();

        public static void Register<T>(T service)
        {
            _listServices[typeof(T)] = service; // = listServices.Add(typeof(T), service);
        }

        public static T Get<T>()
        {
            return (T)_listServices[typeof(T)];
        }
    }
}
