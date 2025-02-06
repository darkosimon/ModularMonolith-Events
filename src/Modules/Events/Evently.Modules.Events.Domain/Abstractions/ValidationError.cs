﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Evently.Modules.Events.Domain.Abstractions;
public sealed record ValidationError : Error
{
    public ValidationError(Error[] errors) : base( "General.Validation", "One or more validation errors occurred", ErrorType.Validation)
    {
        Errors = errors;
    }

    public Error[] Errors { get; }

    public static ValidationError FromResults(IEnumerable<Result> results) => new(results.Where(r => r.IsFailure).Select(r => r.Error).ToArray());
}
