using System.ComponentModel.DataAnnotations;

namespace Moj.Keshet.Domain.ExampleModels.CodeTables
{
    public interface IExtendedCodeTables
    {
        int Key { get; }
        string Value { get; }
        [Required]
        bool? IsActive { get; }
    }
}
