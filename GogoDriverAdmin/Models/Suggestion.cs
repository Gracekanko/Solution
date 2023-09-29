using System;
using System.Collections.Generic;

namespace GogoDriver.Models;

public partial class Suggestion
{
    public string IdSuggestion { get; set; } = null!;

    public string IdPersonne { get; set; } = null!;

    public string IdClient { get; set; } = null!;

    public string? LibelleSuggestion { get; set; }

    public DateTime? DateSuggetion { get; set; }

    public virtual Client Id { get; set; } = null!;
}
