using Rix.Mediator.Abstractions;

namespace Rix.Mediator.Tests.Models;

internal record SimpleRequest(bool Valid) : IRixRequest;