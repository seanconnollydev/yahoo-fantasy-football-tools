using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fantasizer.Proposed
{
    public static class Resource<T> where T : IResource, new()
    {
        // TODO: Add where constraints
        public static T WithKey(string key)
        {
            IResource resource = new T();
            resource.Key = key;
            return (T)resource;
        }
        //public static Game Game(string key)
        //{
        //    return new Game(key);
        //}
    }
}
