using System;

namespace FriskyAgent.Bll.Models;

public record GPTMessageModel(
        string Role,
        string Content
    );
