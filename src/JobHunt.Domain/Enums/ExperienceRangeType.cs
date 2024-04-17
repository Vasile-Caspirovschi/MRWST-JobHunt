using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace JobHunt.Domain.Enums;

public enum ExperienceRangeType
{
    [Display(Name = "0-1 Years")]
    ZeroToOneYears,
    [Display(Name = "1-2 Years")]
    OneToTwoYears,
    [Display(Name = "2-3 Years")]
    TwoToThreeYears,
    [Display(Name = "3-6 Years")]
    ThreeToSixYears,
    [Display(Name = "6-more..")]
    SixOrMoreYears
}
