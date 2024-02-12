namespace Exam_TOP_Academy.DataAccess.Entities;
public partial class Promotion
{
    public Promotion()
    {
        Salebooks = new HashSet<Salebook>();
    }

    public int PromotionId { get; set; }
    public string PromotionName { get; set; }
    public string Description { get; set; }
    public int DiscountPercentage { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool IsActivePromotion { get; set; }

    public virtual ICollection<Salebook> Salebooks { get; set; }
}