using System.ComponentModel.DataAnnotations;

public class Price_Items
{
    [Key]
    public int prit_id { get; set; }
    [Required]
    public string prit_name { get; set; }
    [Required]
    public decimal prit_price { get; set; }

    public string prit_description { get; set; }
    private string _prit_type;
    [Required]
    public string prit_type
    {
        get { return _prit_type; }
        set
        {
            if (value == "SNACK" || value == "FACILITY" || value == "SOFTDRINK" || value == "FOOD" || value == "SERVICE")
            {
                _prit_type = value;
            }
            else
            {
                throw new ArgumentException("Input harus berupa SNACK,FACILITY,SOFTDRINK, FOOD, atau SERVICE.");
            }
        }
    }

    public DateTime prit_modified_date { get; set; }
}