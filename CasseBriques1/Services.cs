using System;
using System.Collections.Generic;

namespace CasseBriques
{
    public static class Services
    {
        public static Dictionary<Type, object> listServices = new Dictionary<Type, object>();

        public static void Register<T>(T service)
        {
            listServices[typeof(T)] = service; // = listServices.Add(typeof(T), service);
        }

        // Retourner le service
        public static T Get<T>()
        {
            return (T)listServices[typeof(T)];
        }
    }
}
