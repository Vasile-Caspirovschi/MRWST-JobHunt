namespace JobHunt.Application.Jobs;

public record JobPostDtoStripped(Guid Id, string JobTitle, DateOnly PublishDate);
