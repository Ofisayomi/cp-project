using cp.Web.Application.Dto;
using cp.Web.Application.Interface;
using Moq;


namespace cp.Tests;

public class CustomQuestionTests
{
    public CustomQuestionTests(){
        
    }
    
    [Theory]
    [InlineData("Please tell me about yourself in less than 500 words", "Paragraph", null)]
    [InlineData("Year of Graduation", "Dropdown", new []{ "2010", "2011", "2012", "2013", "2014", "2015"})]
    public async Task TestCreateCustomQuestion(string question, string questionType, string[]? values)
    {
        var serviceMock = new Mock<IProgramConfigServices>();
        serviceMock.Setup(x => x.CreateCustomQuestion(It.IsAny<CustomQuestionDto>()).Result).Returns(new ResponseDto<string> {
            Status = true,
            Message = ""
         });

        var customQuestion= new CustomQuestionDto{
            Question = question,
            QuestionType = questionType,
            QuestionValues = values?.ToList()
        };

        var result = await serviceMock.Object.CreateCustomQuestion(customQuestion);
        
        Assert.True(result.Status);
    }

    [Fact]
    public async Task TestGetCustomQuestions(){
        var serviceMock = new Mock<IProgramConfigServices>();
        serviceMock.Setup(x=> x.GetCustomQuestions().Result).Returns(new ResponseDto<List<GetCustomQuestionDto>>() {
            Status = true,
            Message = ""
        });

        var result  = await serviceMock.Object.GetCustomQuestions();
        Assert.True(result.Status);
    }
}