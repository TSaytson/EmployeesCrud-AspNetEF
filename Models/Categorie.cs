namespace aspnetefcore.Models
{
  public class Categorie
  {
    public int Id { get; set; }

    public string Name { get; set; }

    public override string ToString()
    {
      return "Id: " + this.Id + " Name: " + this.Name;
    }
  }
}