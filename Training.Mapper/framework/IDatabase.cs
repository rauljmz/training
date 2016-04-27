using System;
namespace Training.framework
{
    public interface IDatabase
    {
        void Create(object obj, string path, string name);
        T GetItem<T>(string path) where T : new();
        string GetName();
        void Save(object obj, string path);
    }
}
