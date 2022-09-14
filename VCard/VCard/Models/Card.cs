
public class Card
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Country { get; set; }
    public string City { get; set; }

    public override string ToString()
    {
        return $"Id: {Id} {Environment.NewLine} FisrtName: {FirstName} {Environment.NewLine} LastName: {LastName} {Environment.NewLine} Email: {Email} {Environment.NewLine}  Phone: {Phone} {Environment.NewLine} Country: {Country} {Environment.NewLine} City: {City} {Environment.NewLine}";
    }
}

