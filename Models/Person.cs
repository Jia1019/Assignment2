using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text.Json.Serialization;

namespace Models {
public class Person {
    public int Id { get; set; }
    
    [NotNull]
    public string FirstName { get; set; }
    [NotNull]
    public string LastName { get; set; }
    [ValidHairColor]
    public string HairColor { get; set; }
    [NotNull]
    [ValidEyeColor]
    public string EyeColor { get; set; }
    [NotNull, Range(0, 125)]
    [JsonPropertyName("Age")]
    public int Age { get; set; }
    [NotNull, Range(1, 250)]
    [JsonPropertyName("Weight")]
    public float Weight { get; set; }
    [NotNull, Range(30, 250)]
    [JsonPropertyName("Height")]
    public int Height { get; set; }
    [NotNull][ValidSex]
    [JsonPropertyName("Sex")]
    public string Sex { get; set; }

    public void Update(Person toUpdate) {
        Age = toUpdate.Age;
        Height = toUpdate.Height;
        HairColor = toUpdate.HairColor;
        Sex = toUpdate.Sex;
        Weight = toUpdate.Weight;
        EyeColor = toUpdate.EyeColor;
        FirstName = toUpdate.FirstName;
        LastName = toUpdate.LastName;
    }
}

public class ValidHairColor : ValidationAttribute {
    protected override ValidationResult IsValid(object value, ValidationContext validationContext) {
        List<string> valid = new[] {"blond", "red", "brown", "black",
            "white", "grey", "blue", "green", "leverpostej"}.ToList();
        if (valid == null || valid.Contains(value.ToString().ToLower())) {
            return ValidationResult.Success;
        }
        return new ValidationResult("Valid hair colors are: Blond, Red, Brown, Black, White, Grey, Blue, Green, Leverpostej");
    }
}

public class ValidEyeColor : ValidationAttribute {
    protected override ValidationResult IsValid(object value, ValidationContext validationContext) {
        List<string> valid = new[] {"black","brown", "grey", "green", "blue",
            "amber", "hazel"}.ToList();
        if (valid != null && valid.Contains(value.ToString().ToLower())) {
            return ValidationResult.Success;
        }
        return new ValidationResult("Valid hair colors are: Black, Brown, Grey, Green, Blue, Amber, Hazel");
    }
}

public class ValidSex : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        List<string> valid = new[]
        {
            "male", "female"
        }.ToList();
        if (valid != null && valid.Contains(value.ToString().ToLower()))
        {
            return ValidationResult.Success;
        }

        return new ValidationResult("Valid sexes are: Male, Female");
    }
}

}