using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Performance", "CA1515:Because an application's API isn't typically referenced from outside the assembly, types can be made internal", Justification = "Test classes must be public for MSTest runner", Scope = "module")]
