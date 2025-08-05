namespace FriskyAgent.Bll.Models;

public record GPTRequestModel(
    string model,
    GPTMessageModel[] messages,
    double temperature = 0.2
);