using System.Data.Common;


namespace ClassLib.Entities;
public class MyTaskDTO
{
    public int Id {get; set;}
    public string Name {get; set;}
    public string Description {get; set;}
    public string Status {get; set;}
}