using QuizApp.Interfaces;
using QuizApp.Models;
using QuizApp.Models.DTOs;

namespace QuizApp.Services
{
        public class QuestionService : IQuestionService
    {
            private readonly IRepository<int, Questions> _questionRepository;
            private readonly IRepository<int, Quiz> _quizRepository;

            public QuestionService(IRepository<int, Questions> QuestionRepository,
                IRepository<int, Quiz> QuizRepository)
            {
            Console.WriteLine("QuestionService constructor called");
            _questionRepository = QuestionRepository;
                _quizRepository = QuizRepository;
            }
            public bool AddToQuiz(QuestionDTO questionDTO)
            {

                var Check = _questionRepository.GetAll().FirstOrDefault(c => c.QuestionId == questionDTO.QuestionId);
                int questionId = 0;
                if (Check == null)
                {
                    var question = _questionRepository.Add(new Questions { Username = questionDTO.Username,
                        QuizId = questionDTO.QuizId,
                        QuestionTxt = questionDTO.QuestionTxt,
                        Option1 = questionDTO.Option1,
                        Option2 = questionDTO.Option2,
                        Option3 = questionDTO.Option3,
                        Option4 = questionDTO.Option4,
                        Answer = questionDTO.Answer,
                    });
                    questionId = questionDTO.QuestionId;
                }
                else
                questionId = Check.QuestionId;
                return true;
            }
            private bool CheckIfQuestionAlreadyPresent(int questionId, int quizId)
            {
                var question = _questionRepository.GetAll()
                    .FirstOrDefault(ci => ci.QuizId == quizId && ci.QuestionId == questionId);
                return question != null ? true : false;
            }
            public bool RemoveFromQuiz(QuestionDTO questionDTO)
            {
                var questionCheck = _questionRepository.GetAll().FirstOrDefault(c => c.QuestionId == questionDTO.QuestionId);
                int quizId = questionDTO.QuizId;
                bool CheckQuizQuestion = CheckIfQuestionAlreadyPresent(questionDTO.QuestionId, questionDTO.QuizId);
                if (CheckQuizQuestion)
                {
                    var result = _questionRepository.Delete(questionDTO.QuestionId);
                    return true;

                }
                return false;
            }
        }
}
