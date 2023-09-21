namespace aspnetefcore.Models{

  public class Product {
    public int Id { get; set; }

    public string Name { get; set; }

    public virtual Categorie Categorie { get; set; } //needs to be virtual to use lazy loading

    public override string ToString()
    {
      return $"Id: {Id}, Name: {Name}, Categorie: [{this.Categorie.ToString()}]";
    }
  }
}