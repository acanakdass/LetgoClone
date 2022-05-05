namespace Service.Constants;

public static class Messages
{
    public static string Added(string fieldName) => $"{fieldName} added successfully";
    public static string Listed(string fieldName) => $"{fieldName} listed successfully";
    public static string Updated(string fieldName) => $"{fieldName} updated successfully.";
    public static string FailedUpdate(string fieldName) => $"An error occured while updating {fieldName}";
    public static string Deleted(string fieldName) => $"{fieldName} deleted successfully.";
    public static string FailedDelete(string fieldName) => $"An error occured while deleting {fieldName}";
    public static string NotFound(string fieldName) => $"{fieldName} not found";
}