namespace FriskyAgent.Bll.Models;

public record GPTResponseModel(
        GPTResponseChoiceModel[] choices
    );