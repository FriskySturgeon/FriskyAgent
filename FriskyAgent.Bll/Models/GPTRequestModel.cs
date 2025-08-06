using System;

namespace FriskyAgent.Bll.Models;

public record GPTRequestModel(
        string Model,
        GPTMessageModel[] Messages,
        double Temperature = 0.2
    );