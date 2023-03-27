using System.ComponentModel.DataAnnotations;

namespace CmacPartnerApi.Model;

public class CancelRequest
{
    [Required, StringLength(255)]
    public string Id { get; set; } = null!;
}