using System.Collections.Generic;
using Nancy;
using ToDoList.Objects;

namespace ToDoList
{
  public class HomeModule:NancyModule
  {
    public HomeModule()
    {
      Get["/"]=_=>View["add_new_task.cshtml"];
      Get["/tasks"] =_=>{
        List<Task> taskList = Task.GetAll();
        return View["view_all_tasks.cshtml", taskList];
      };
      Post["/tasks"] = _ => {
        Task newTask = new Task (Request.Form["new-task"]);
        List<Task> taskList = Task.GetAll();
        return View["view_all_tasks.cshtml", taskList];
      };
      Post["/tasks_cleared"]=_=>{
        Task.ClearAll();
        return View["tasks_cleared.cshtml"];
      };
      Get["/tasks/{id}"] = parameters => {
        Task task = Task.Find(parameters.id);
        return View["/task_added.cshtml", task];
      };
    }
  }
}
