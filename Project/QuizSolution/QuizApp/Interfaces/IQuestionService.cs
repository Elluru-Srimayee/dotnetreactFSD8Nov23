﻿using QuizApp.Models.DTOs;

namespace QuizApp.Interfaces
{
    public interface IQuestionService
    {
        bool AddToQuiz(QuestionDTO questionDTO);
        bool RemoveFromQuiz(QuestionDTO questionDTO);
    }
}
