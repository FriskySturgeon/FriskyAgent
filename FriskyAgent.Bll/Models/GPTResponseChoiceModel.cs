namespace FriskyAgent.Bll.Models;

public record GPTResponseChoiceModel(
        GPTMessageModel Message,
        string FinishReason
    );
