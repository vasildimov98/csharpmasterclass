namespace Multithreading_asynchrony_Assignment.DTOs;

public record Root(
int statusCode,
string message,
Pagination pagination,
int totalQuotes,
IReadOnlyList<Datum> data
);