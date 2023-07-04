// <copyright file="ClientPrincipal.cs" company="Simon Stanford">
// Copyright (c) Simon Stanford. All rights reserved.
// </copyright>

using System.Collections.Generic;

namespace MonthlyExpenses.Api.Models;

public class ClientPrincipal
{
    public string IdentityProvider { get; set; }

    public string UserId { get; set; }

    public string UserDetails { get; set; }

    public IEnumerable<string> UserRoles { get; set; }
}