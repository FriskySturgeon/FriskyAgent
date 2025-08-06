using System;

namespace FriskyAgent.Bll.Models;
public record GPTResponseModel(
    GPTResponseChoiceModel[] Choices,
    string Id,
    string Object,
    long Created,
    string Model
);
