using System.Collections.Generic;

namespace ToDoList.Objects
{
  public class Task
  {
    private string _description;
    private static List<Task> _instances = new List<Task>{};
    private int _id;
    public Task(string description)
    {
      _description = description;
      _instances.Add(this);
      _id=_instances.Count;
    }
    public string GetDescription()
    {
      return _description;
    }
    public void SetDescription(string newDescription)
    {
      _description = newDescription;
    }
    public static List<Task> GetAll()
    {
      return _instances;
    }
    public static void ClearAll()
    {
      _instances.Clear();
    }
    public int GetID()
    {
      return _id;
    }
    public static Task Find(int searchID)
    {
      return _instances[searchID-1];
    }
  }
}
