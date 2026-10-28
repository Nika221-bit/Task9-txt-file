namespace Task9_txt_file;

public class Product
{
    public  int Id { get; set; }
    public  string Name { get; set; }
    public  decimal Price { get; set; }
    public  string Description { get; set; }
    public override string ToString()
    {
        return $"{Id}|{Name}|{Price}|{Description}";
        
    }
}