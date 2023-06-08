namespace Presentation.Rest.Models.Result;

public sealed record ErrorDto(string Message, string? Code);
