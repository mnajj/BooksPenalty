namespace BooksPenalty.Api.Dtos;

public sealed record PenaltyReadDto(Guid bookId, DateTime StartDate, DateTime EndDate, string Country);